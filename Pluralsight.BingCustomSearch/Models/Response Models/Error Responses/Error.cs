using System;
using System.Collections.Generic;
using System.Text;

namespace Pluralsight.BingCustomSearch.Models.Response_Models.Error_Responses
{
    public class Error
    {
        public string code { get; set; }
        public string message { get; set; }
        public string moreDetails { get; set; }
        public string parameter { get; set; }
        public string subCode { get; set; }
        public string value { get; set; }

    }
}
