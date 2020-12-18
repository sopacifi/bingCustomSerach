using Pluralsight.BingCustomSearch.Models.Response_Models.Image_Search_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pluralsight.BingCustomSearch.Models.Response_Models.General_Models
{
    public class Query
    {
        public string displayText { get; set; }
        public string searchLink { get; set; }
        public string text { get; set; }
        public Thumbnail thumbnail { get; set; }
        public string webSearchUrl { get; set; }

    }
}
