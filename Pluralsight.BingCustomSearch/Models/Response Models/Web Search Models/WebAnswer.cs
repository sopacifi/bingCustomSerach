using System;
using System.Collections.Generic;
using System.Text;

namespace Pluralsight.BingCustomSearch.Models.Response_Models.Web_Search_Models
{
    public class WebAnswer
    {
        public long totalEstimatedMatches { get; set; }
        public Webpage[] value { get; set; }
        public string webSearchUrl { get; set; }
    }
}
