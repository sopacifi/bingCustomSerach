using System;
using System.Collections.Generic;
using System.Text;

namespace Pluralsight.BingCustomSearch.Models.Request_Models
{
    public class BaseQuery
    {
        public BaseQuery()
        {
            this.cc = "en-US";
            this.count = 10;
            this.customConfig = Constants.CUSTOM_CONFIG_ID;
            this.mkt = "en-US";
            this.offset = 0;
            this.q = "";
            this.safeSearch = "Off";
        }

        public string cc { get; set; }
        public short count { get; set; }
        public string customConfig { get; set; }
        public string mkt { get; set; }
        public short offset { get; set; }
        public string q { get; set; }
        public string safeSearch { get; set; }
        public string setLang { get; set; }
    }
}
