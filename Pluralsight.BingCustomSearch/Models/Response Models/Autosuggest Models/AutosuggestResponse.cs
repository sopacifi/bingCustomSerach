using Pluralsight.BingCustomSearch.Models.Response_Models.General_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pluralsight.BingCustomSearch.Models.Response_Models.Autosuggest_Models
{
    public class AutosuggestResponse
    {
        public string _type { get; set; }
        public QueryContext queryContext { get; set; }
        public SuggestionGroup[] suggestionGroups { get; set; }
    }
}
