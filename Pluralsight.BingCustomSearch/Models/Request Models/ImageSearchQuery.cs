using System;
using System.Collections.Generic;
using System.Text;

namespace Pluralsight.BingCustomSearch.Models.Request_Models
{
    public class ImageSearchQuery : BaseQuery
    {
        public ImageSearchQuery()
        {
        }

        public string aspect { get; set; }
        public string color { get; set; }
        public short? height { get; set; }
        public string imageContent { get; set; }
        public string imageType { get; set; }
        public string license { get; set; }
        public int? maxFileSize { get; set; }
        public int? maxHeight { get; set; }
        public int? maxWidth { get; set; }
        public int? minFileSize { get; set; }
        public int? minHeight { get; set; }
        public int? minWidth { get; set; }
        public string size { get; set; }
        public short? width { get; set; }
    }
}
