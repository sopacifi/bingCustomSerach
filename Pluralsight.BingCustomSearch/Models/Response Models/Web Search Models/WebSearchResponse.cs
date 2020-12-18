using Pluralsight.BingCustomSearch.Models.Response_Models.General_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pluralsight.BingCustomSearch.Models.Response_Models.Web_Search_Models
{
    public class WebSearchResponse
    {
        public string _type { get; set; }
        public QueryContext queryContext { get; set; }
        public WebAnswer webPages { get; set; }
    }
}

