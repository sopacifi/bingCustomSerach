using Pluralsight.BingCustomSearch.Models.Response_Models.General_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pluralsight.BingCustomSearch.Models.Response_Models.Image_Search_Models
{
    public class Image
    {
        public string accentColor { get; set; }
        public string contentSize { get; set; }
        public string contentUrl { get; set; }
        public string datePublished { get; set; }
        public string encodingFormat { get; set; }
        public short height { get; set; }
        public string hostPageDisplayUrl { get; set; }
        public string hostPageUrl { get; set; }
        public string imageId { get; set; }
        public string name { get; set; }
        public MediaSize thumbnail { get; set; }
        public string thumbnailUrl { get; set; }
        public string webSearchUrl { get; set; }
        public short width { get; set; }
        public string imageInsightsToken { get; set; }

    }
}
