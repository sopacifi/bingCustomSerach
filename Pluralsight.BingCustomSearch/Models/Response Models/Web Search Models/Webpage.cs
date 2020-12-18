using System;
using System.Collections.Generic;
using System.Text;

namespace Pluralsight.BingCustomSearch.Models.Response_Models.Web_Search_Models
{
    public class Webpage
    {
        public string dateLastCrawled { get; set; }
        public Webpage[] deepLinks { get; set; }
        public string displayUrl { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public MetaTag[] searchTags { get; set; }
        public string snippet { get; set; }
        public string url { get; set; }
        public OpenGraphImage openGraphImage { get; set; }
    }
}
