using Pluralsight.BingCustomSearch.Models;
using Pluralsight.BingCustomSearch.Models.Request_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pluralsight.BingCustomSearch.Models.Request_Models
{
    public class VideoSearchQuery : BaseQuery
    {
        public VideoSearchQuery()
        {

        }

        public string freshness { get; set; }
        public string pricing { get; set; }
        public string resolution { get; set; }
        public string videoLength { get; set; }

    }
}
