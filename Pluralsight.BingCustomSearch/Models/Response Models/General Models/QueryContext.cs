using System;
using System.Collections.Generic;
using System.Text;

namespace Pluralsight.BingCustomSearch.Models.Response_Models.General_Models
{
    public class QueryContext
    {
        public Boolean adultIntent { get; set; }
        public string alterationOverrideQuery { get; set; }
        public string alteredQuery { get; set; }
        public string originalQuery { get; set; }
    }
}
