using System;
using System.Collections.Generic;
using System.Text;

namespace Pluralsight.BingCustomSearch.Models.Request_Models
{
    public class AutosuggestQuery
    {
        public AutosuggestQuery()
        {}
        public string customConfig { get; set; }
        public string q { get; set; }
    }
}
