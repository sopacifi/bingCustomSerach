using System;
using System.Collections.Generic;
using System.Text;

namespace Pluralsight.BingCustomSearch.Models.Request_Models
{
    public class WebSearchQuery : BaseQuery
    {
        public WebSearchQuery()
        {
            this.textDecorations = false;
            this.textFormat = "HTML";
        }
        public Boolean textDecorations { get; set; }
        public string textFormat { get; set; }

    }
}
