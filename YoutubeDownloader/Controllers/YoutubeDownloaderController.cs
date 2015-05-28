using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using YoutubeDownloader.Models;
using System.Net;
using System.Web;
using System.Drawing;
using System.Xml.Linq;

namespace YoutubeDownloader.Controllers
{
    public class YoutubeDownloaderController
    {
        private readonly BindingList<YoutubeVideoModel> m_bindingList;

        public YoutubeDownloaderController()
        {
            m_bindingList = new BindingList<YoutubeVideoModel>();
        }

        public BindingList<YoutubeVideoModel> GetList()
        {
            return m_bindingList;
        }

        public YoutubeVideoModel Add(string videoUrl)
        {
            if (string.IsNullOrWhiteSpace(videoUrl))
                throw new ArgumentException("videoUrl must be provided");

            var videoId = getVideoIdFromUrl(videoUrl);

            if (string.IsNullOrWhiteSpace(videoId))
                throw new Exception("Video Url could not be determined, you must provide a proper Youtube url");

            var video = getVideoByVidId(videoUrl, videoId);
            
            m_bindingList.Add(video);

            return video;
        }

        public bool ShowQualityChooser(YoutubeVideoModel model)
        {
            using(var dlg = new FrmChooseQuality(model))
            {
                if(dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    model.SelectedQuality = dlg.GetSelectedQuality();
                    m_bindingList.ResetBindings();
                    return true;
                }
            }

            return false;
        }

        public bool ShowSearchDialog(string searchQuery)
        {
            var uriSearchTerm = HttpUtility.UrlEncode(searchQuery);
            var searchUrl = "http://gdata.youtube.com/feeds/videos?q=" + uriSearchTerm;
            var ns = XNamespace.Get("http://www.w3.org/2005/Atom");

            var searchNode = XElement.Load(searchUrl);
            var searchResultList = new List<SearchVideoModel>();
            foreach(var entryNode in searchNode.Descendants(ns + "entry"))
            {
                var searchResult = new SearchVideoModel();
                var idNode = entryNode.Element(ns + "id");
                var titleNode = entryNode.Element(ns + "title");
                var authorNode = entryNode.Descendants(ns + "author").Descendants(ns + "name").FirstOrDefault();

                if (idNode != null)
                    searchResult.Id = idNode.Value.Split('/').LastOrDefault();

                if (titleNode != null)
                    searchResult.Title = titleNode.Value;

                if (authorNode != null)
                    searchResult.Author = authorNode.Value;

                searchResultList.Add(searchResult);
            }

            using (var dlg = new FrmPickSearchResult(searchResultList))
            {
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var selectedVid = dlg.GetSelectedVideo();
                    if (selectedVid != null)
                    {
                        var vidModel = getVideoByVidId("http://www.youtube.com/watch?v=" + selectedVid.Id, selectedVid.Id);
                        PickBestFlvQualityOrShow(vidModel);
                        m_bindingList.Add(vidModel);
                        m_bindingList.ResetBindings();
                        return true;
                    }
                }
            }

            return false;
        }
        
        public void PickBestFlvQualityOrShow(YoutubeVideoModel model)
        {
            var bestFlvQuality = model.AvailableQualities.Where(x => x.Extension.ToLower() == "flv").OrderByDescending(x => x.Dimensions.Width).FirstOrDefault();
            if (bestFlvQuality == null)
                ShowQualityChooser(model);
            else
                model.SelectedQuality = bestFlvQuality;
        }

        public void Remove(string videoUrl)
        {
            Remove(m_bindingList.FirstOrDefault(x => getVideoIdFromUrl(x.VideoUrl) == getVideoIdFromUrl(videoUrl)));
        }

        public void Remove(YoutubeVideoModel video)
        {
            if (video == null || !m_bindingList.Contains(video))
                throw new Exception("Video cannot be found");

            m_bindingList.Remove(video);
        }

        public bool Exists(string videoUrl)
        {
            return m_bindingList.Any(x => getVideoIdFromUrl(x.VideoUrl) == getVideoIdFromUrl(videoUrl));
        }

        private static string getVideoIdFromUrl(string url)
        {
            char[] delimiters = { '&', '#' };

            url = url.Substring(url.IndexOf("?", StringComparison.Ordinal) + 1);
            var props = url.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            var videoid = string.Empty;
            foreach (var prop in props)
            {
                if (prop.StartsWith("v="))
                    videoid = prop.Substring(prop.IndexOf("v=", StringComparison.Ordinal) + 2);
            }

            return videoid;
        }
        
        private YoutubeVideoModel getVideoByVidId(string videoUrl, string videoId)
        {
            var infoUrl = string.Format("http://www.youtube.com/get_video_info?&video_id={0}&el=detailpage&ps=default&eurl=&gl=US&hl=en", videoId);
            var client = new WebClient { Proxy = null };
            var infoText = client.DownloadString(infoUrl);
            var infoValues = HttpUtility.ParseQueryString(infoText);

            var vidModel = new YoutubeVideoModel
            {
                Title = infoValues["title"],
                Duration = TimeSpan.FromSeconds(double.Parse(infoValues["length_seconds"])),
                VideoUrl = videoUrl,
                Rating = Convert.ToDouble(infoValues["avg_rating"].Replace('.', ',')),
                ViewCount = Convert.ToInt64(infoValues["view_count"]),
                Uploader = infoValues["author"]
            };

            var thumbUrl = infoValues["thumbnail_url"];
            var imgRequest = WebRequest.CreateHttp(thumbUrl);
            imgRequest.Proxy = null;
            var imgResponseStream = imgRequest.GetResponse().GetResponseStream();
            if (imgResponseStream != null)
                vidModel.Thumbnail = Image.FromStream(imgResponseStream);

            var videoInfos = infoValues["url_encoded_fmt_stream_map"].Split(',');
            foreach (var item in videoInfos)
            {
                try
                {
                    var data = HttpUtility.ParseQueryString(item);
                    var server = Uri.UnescapeDataString(data["fallback_host"]);
                    var url = Uri.UnescapeDataString(data["url"]) + "&fallback_host=" + server;

                    var itag = Uri.UnescapeDataString(data["itag"]);
                    var qualityItem = new VideoQualityModel();
                    qualityItem.DownloadUrl = url;
                    qualityItem.FillById(Convert.ToInt32(itag));
                    vidModel.AvailableQualities.Add(qualityItem);
                }
                catch { }
            }
            return vidModel;
        }
    }
}
