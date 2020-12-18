using System;
using System.Collections.Generic;
using System.Text;

namespace Pluralsight.BingCustomSearch.Models.Response_Models.Autosuggest_Models
{
    public class SearchAction
    {
        public string displayText { get; set; }
        public string query { get; set; }
        public string searchKind { get; set; }
    }
}
