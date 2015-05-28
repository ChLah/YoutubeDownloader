using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeDownloader.Models;

namespace YoutubeDownloader.Controllers
{
    public class ChooseQualityController
    {
        private YoutubeVideoModel m_model;
                
        public ChooseQualityController(YoutubeVideoModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model must not be null");

            m_model = model;
        }

        public List<VideoQualityModel> GetQualities()
        {
            return m_model.AvailableQualities.OrderBy(x => x.Extension).ThenBy(x => x.Dimensions.Width).ToList();
        }

        public VideoQualityModel GetSelectedQuality()
        {
            return m_model.SelectedQuality;
        }
    }
}
