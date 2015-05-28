using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeDownloader.Models
{
    public class SearchVideoModel
    {
        [Browsable(false)]
        public string Id { get; set; }

        [DisplayName("Autor")]
        public string Author { get; set; }

        [DisplayName("Titel")]
        public string Title { get; set; }
    }
}
