using Id3;
using JDP;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeDownloader.Controllers;
using YoutubeDownloader.Models;

namespace YoutubeDownloader
{
    public partial class FrmMain : Form
    {
        private readonly YoutubeDownloaderController m_controller;

        public FrmMain()
        {
            InitializeComponent();

            m_controller = new YoutubeDownloaderController();
            dgvVideos.DataSource = m_controller.GetList();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            txtDestPath.Text = Properties.Settings.Default.DestinationPath;
            ckConvertFlvToMp3.Checked = Properties.Settings.Default.ConvertToMp3;
            ckPersistVideo.Checked = Properties.Settings.Default.PersistVideoFile;
            ckAddIdeTags.Checked = Properties.Settings.Default.AddIdeTags;
        }

        private void txtVidUrl_TextChanged(object sender, EventArgs e)
        {
            var videoUrlRegex = new Regex(@"\Ahttps?:\/\/(?:www\.)?youtube.com\/watch\?(?=.*v=\w+)(?:\S+)?\z", RegexOptions.Compiled);
            if (videoUrlRegex.IsMatch(txtVidUrl.Text) && !m_controller.Exists(txtVidUrl.Text))
            {
                var model = m_controller.Add(txtVidUrl.Text);
                txtVidUrl.Clear();
                m_controller.PickBestFlvQualityOrShow(model);
            }
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
                txtVidUrl.Text = Clipboard.GetText();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            m_controller.ShowSearchDialog(txtVidUrl.Text);
        }

        private void btnChooseDestPath_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Zielpfad wählen";
                dlg.ShowNewFolderButton = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                    txtDestPath.Text = dlg.SelectedPath;
            }
        }

        private async void btnStartDownload_Click(object sender, EventArgs e)
        {
            if (!m_controller.GetList().Any())
            {
                MessageBox.Show("Keine Videos in der Liste!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDestPath.Text))
            {
                MessageBox.Show("Kein Zielpfad gewählt!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(txtDestPath.Text))
            {
                MessageBox.Show("Zielpfad existiert nicht!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (m_controller.GetList().Any(x => x.SelectedQuality == null))
            {
                MessageBox.Show("Nicht alle Videos haben eine Qualität ausgewählt!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Properties.Settings.Default.ConvertToMp3 = ckConvertFlvToMp3.Checked;
            Properties.Settings.Default.PersistVideoFile = ckPersistVideo.Checked;
            Properties.Settings.Default.AddIdeTags = ckAddIdeTags.Checked;
            Properties.Settings.Default.DestinationPath = txtDestPath.Text;
            Properties.Settings.Default.Save();

            btnStartDownload.Enabled = false;
            pbProgressCurrentFile.Visible = lblAdditionalInfo.Visible = true;
            await processFilesAsync(m_controller.GetList().ToList(), txtDestPath.Text, ckConvertFlvToMp3.Checked, ckPersistVideo.Checked, ckAddIdeTags.Checked);
            btnStartDownload.Enabled = true;
            pbProgressCurrentFile.Visible = lblAdditionalInfo.Visible = false;
        }

        private Stopwatch m_downloadSpeedStopwatch;
        private async Task processFilesAsync(IEnumerable<YoutubeVideoModel> vidsToDownload, string destinationPath, bool convertToMp3, bool persistVideo, bool addIdeTag)
        {
            m_downloadSpeedStopwatch = new Stopwatch();
            foreach (var video in vidsToDownload)
            {
                m_downloadSpeedStopwatch.Reset();

                var fileName = video.Title;
                foreach (var invalidChar in Path.GetInvalidFileNameChars())
                    fileName = fileName.Replace(invalidChar.ToString(), "");

                var filePath = Path.Combine(destinationPath, fileName + "." + video.SelectedQuality.Extension);

                var uri = new Uri(video.SelectedQuality.DownloadUrl);
                var client = new WebClient { Proxy = null };
                client.DownloadProgressChanged += downloadProgress_Changed;
                m_downloadSpeedStopwatch.Start();
                await client.DownloadFileTaskAsync(uri, filePath);
                m_downloadSpeedStopwatch.Stop();

                if (convertToMp3 && video.SelectedQuality.Extension.ToLower() == "flv")
                {
                    extractStream(filePath, persistVideo);

                    if (addIdeTag)
                    {
                        var mp3Path = Path.ChangeExtension(filePath, ".mp3");
                        using (var ms = new MemoryStream())
                        {
                            video.Thumbnail.Save(ms, video.Thumbnail.RawFormat);
                            addId3Tags(mp3Path, video.Title, ms.ToArray());
                        }
                    }
                }
            }
        }

        private void downloadProgress_Changed(object sender, DownloadProgressChangedEventArgs e)
        {
            var speed = getHumanReadableSize((long)(e.BytesReceived / m_downloadSpeedStopwatch.Elapsed.TotalSeconds));
            pbProgressCurrentFile.Value = e.ProgressPercentage;
            lblAdditionalInfo.Text = getHumanReadableSize(e.BytesReceived) + " / " + getHumanReadableSize(e.TotalBytesToReceive) + " (" + speed + "/s" + ")";
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (dgvVideos.SelectedRows.Count != 1)
                return;

            var selectedItem = dgvVideos.SelectedRows[0].DataBoundItem as YoutubeVideoModel;
            if (selectedItem != null)
                m_controller.Remove(selectedItem);
        }

        private void tsmiChooseQuality_Click(object sender, EventArgs e)
        {
            if (dgvVideos.SelectedRows.Count != 1)
                return;

            var selectedItem = dgvVideos.SelectedRows[0].DataBoundItem as YoutubeVideoModel;
            if (selectedItem != null)
                m_controller.ShowQualityChooser(selectedItem);
        }

        private void txtVidUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                m_controller.ShowSearchDialog(txtVidUrl.Text);
        }

        private static void addId3Tags(string filePath, string songName, byte[] picture)
        {
            var split = songName.Split('-').Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            using (var fs = new FileStream(filePath, FileMode.Open))
            using (var mp3Stream = new Mp3Stream(fs, Mp3Permissions.ReadWrite))
            {
                var tag = new Id3Tag();
                tag.Artists.Value = split.Length > 1 ? split[0] : null;
                tag.Title.Value = split.Length > 1 ? split[1] : split[0];
                tag.Pictures.Add(new Id3.Frames.PictureFrame { PictureData = picture, Description = "YT Thumbnail", PictureType = Id3.Frames.PictureType.FrontCover });
                tag.Comments.Add(new Id3.Frames.CommentFrame { Comment = "Downloaded and converted by Mocki's Youtube Downloader", Description = "Downloaded and converted by Mocki's Youtube Downloader", Language = Id3Language.eng });
                mp3Stream.WriteTag(tag, 1, 0, WriteConflictAction.Replace);
            }
        }

        private static void extractStream(string uri, bool persistVideo)
        {
            using (var flvFile = new FLVFile(uri))
                flvFile.ExtractStreams(true, false, false, null);

            if (!persistVideo)
                File.Delete(uri);
        }

        private static string getHumanReadableSize(Int64 value)
        {
            var sizeSuffixes = new[] { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

            if (value < 0) { return "-" + sizeSuffixes[-value]; }
            if (value == 0) { return "0.0 bytes"; }

            var mag = (int)Math.Log(value, 1024);
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            return string.Format("{0:n1} {1}", adjustedSize, sizeSuffixes[mag]);
        }
    }
}
