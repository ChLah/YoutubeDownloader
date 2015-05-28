using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeDownloader.Models
{
    public class VideoQualityModel
    {
        public int Id { get; set; }
        public string QualityAnnotation { get; set; }
        public int QualityInPoints { get; set; }
        public string Extension { get; set; }
        public Size Dimensions { get; set; }
        public string DownloadUrl { get; set; }

        public void FillById(int id)
        {
            switch (id)
            {
                case 5:
                    QualityAnnotation = "Low Quality";
                    QualityInPoints = 240;
                    Extension = "FLV";
                    Dimensions = new Size(400, 240);
                    break;

                case 17:
                    QualityAnnotation = "Low Quality";
                    QualityInPoints = 144;
                    Extension = "3G";
                    Dimensions = new Size(0, 0);
                    break;

                case 18:
                    QualityAnnotation = "Medium Quality";
                    QualityInPoints = 360;
                    Extension = "MP4";
                    Dimensions = new Size(480, 60);
                    break;

                case 22:
                    QualityAnnotation = "High Quality";
                    QualityInPoints = 720;
                    Extension = "MP4";
                    Dimensions = new Size(1280, 20);
                    break;

                case 34:
                    QualityAnnotation = "Medium Quality";
                    QualityInPoints = 360;
                    Extension = "FLV";
                    Dimensions = new Size(640, 60);
                    break;

                case 35:
                    QualityAnnotation = "Standard Definition";
                    QualityInPoints = 480;
                    Extension = "FLV";
                    Dimensions = new Size(854, 80);
                    break;

                case 36:
                    QualityAnnotation = "Low Quality";
                    QualityInPoints = 240;
                    Extension = "3G";
                    Dimensions = new Size(0, 0);
                    break;

                case 37:
                    QualityAnnotation = "Full High Quality";
                    QualityInPoints = 1080;
                    Extension = "MP4";
                    Dimensions = new Size(1920, 080);
                    break;

                case 38:
                    QualityAnnotation = "Original Definition";
                    QualityInPoints = 1080;
                    Extension = "MP4";
                    Dimensions = new Size(4096, 072);
                    break;

                case 43:
                    QualityAnnotation = "Medium Quality";
                    QualityInPoints = 360;
                    Extension = "WebM";
                    Dimensions = new Size(640, 60);
                    break;

                case 44:
                    QualityAnnotation = "Standard Definition";
                    QualityInPoints = 480;
                    Extension = "WebM";
                    Dimensions = new Size(854, 80);
                    break;

                case 45:
                    QualityAnnotation = "High Quality";
                    QualityInPoints = 720;
                    Extension = "WebM";
                    Dimensions = new Size(1280, 20);
                    break;

                case 46:
                    QualityAnnotation = "Full High Quality";
                    QualityInPoints = 1080;
                    Extension = "WebM";
                    Dimensions = new Size(1280, 20);
                    break;

                case 82:
                    QualityAnnotation = "Medium Quality 3D";
                    QualityInPoints = 360;
                    Extension = "MP4";
                    Dimensions = new Size(640, 60);
                    break;

                case 84:
                    QualityAnnotation = "High Quality 3D";
                    QualityInPoints = 720;
                    Extension = "MP4";
                    Dimensions = new Size(1280, 20);
                    break;

                case 100:
                    QualityAnnotation = "Medium Quality 3D";
                    QualityInPoints = 360;
                    Extension = "WebM";
                    Dimensions = new Size(640, 60);
                    break;

                case 102:
                    QualityAnnotation = "High Quality 3D";
                    QualityInPoints = 720;
                    Extension = "WebM";
                    Dimensions = new Size(1280, 20);
                    break;

                default: throw new NotImplementedException();

            }
        }

        public override string ToString()
        {
            return Extension + " (" + QualityAnnotation + ", " + QualityInPoints + "p, " + Dimensions.Width + "x" + Dimensions.Height;
        }
    }
}
