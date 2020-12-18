using Pluralsight.BingCustomSearch.Models.Response_Models.General_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pluralsight.BingCustomSearch.Models.Response_Models.Video_Search_Models
{
    public class Video
    {
        public Boolean allowHttpsEmbed { get; set; }
        public Boolean allowMobileEmbed { get; set; }
        public Publisher creator { get; set; }
        public string contentUrl { get; set; }
        public string datePublished { get; set; }
        public string description { get; set; }
        public string duration { get; set; }
        public string embedHtml { get; set; }
        public string encodingFormat { get; set; }
        public int? height { get; set; }
        public string hostPageDisplayUrl { get; set; }
        public string hostPageUrl { get; set; }
        public Boolean isAccessibleForFree { get; set; }
        public Boolean isSuperfresh { get; set; }
        public Thing mainEntity { get; set; }
        public string motionThumbnailUrl { get; set; }
        public string name { get; set; }
        public Publisher[] publisher { get; set; }
        public MediaSize thumbnail { get; set; }
        public string thumbnailUrl { get; set; }
        public string videoId { get; set; }
        public int? viewCount { get; set; }
        public string webSearchUrl { get; set; }
        public int? width { get; set; }


    }
}
