using System;
using System.Collections.Generic;
using System.Text;

namespace Pluralsight.BingCustomSearch.Models.Response_Models.Autosuggest_Models
{
    public class SuggestionGroup
    {
        public string name { get; set; }
        public SearchAction[] searchSuggestions { get; set; }

    }
}
