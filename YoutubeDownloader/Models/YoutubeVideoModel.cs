using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeDownloader.Models
{
    public class YoutubeVideoModel
    {
        [DisplayName("Titelbild")]
        [ReadOnly(true)]
        public Image Thumbnail { get; set; }

        [DisplayName("Titel")]
        public string Title { get; set; }

        [Browsable(false)]
        public string VideoUrl { get; set; }

        [DisplayName("Dauer")]
        [ReadOnly(true)]
        public TimeSpan Duration { get; set; }

        [Browsable(false)]
        public VideoQualityModel SelectedQuality { get; set; }

        [DisplayName("Durchschnittliche Bewertung")]
        [ReadOnly(true)]
        public double Rating { get; set; }

        [DisplayName("Gesehen")]
        [ReadOnly(true)]
        public long ViewCount { get; set; }

        [DisplayName("Autor")]
        [ReadOnly(true)]
        public string Uploader { get; set; }

        [DisplayName("Gewählte Qualität")]
        [ReadOnly(true)]
        public string QualitySelectionString { get { return SelectedQuality == null ? "Keine Quali gewählt" : SelectedQuality.ToString(); } }

        public List<VideoQualityModel> AvailableQualities { get; set; }

        public YoutubeVideoModel()
        {
            AvailableQualities = new List<VideoQualityModel>();
        }
    }
}
