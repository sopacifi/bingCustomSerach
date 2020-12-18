using Pluralsight.BingCustomSearch.Models.Response_Models.General_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pluralsight.BingCustomSearch.Models.Response_Models.Image_Search_Models
{
    public class ImagesResponse
    {
        public string _type { get; set; }
        public int nextOffset { get; set; }
        public Pivot pivotSuggestions { get; set; }
        public Query queryExpansions { get; set; }
        public Query similarTerms { get; set; }
        public long totalEstimatedMatches { get; set; }
        public string webSearchUrl { get; set; }
        public Image[] value { get; set; }
        public Instrumentation instrumentation { get; set; }
        public string readLink { get; set; }
        
        
    }
}
