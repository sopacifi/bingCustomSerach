using Pluralsight.BingCustomSearch.Models;
using Pluralsight.BingCustomSearch.Models.Request_Models;
using Pluralsight.BingCustomSearch.Services;
using System;

namespace Pluralsight.BingCustomSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            callAutosuggestQuery(true);
        }


        public static void callAutosuggestQuery(bool useAPI)
        {
            var autosuggestQuery = new AutosuggestQuery();
            autosuggestQuery.q = "d";
            autosuggestQuery.customConfig = Constants.CUSTOM_CONFIG_ID;

            if (useAPI)
                AutosuggestService.callAutosuggestSearchAPI(autosuggestQuery);
            else
                Console.WriteLine("No SDK Available...");
        }

        public static void callVideoQuery(bool useAPI)
        {
            var videoQuery = new VideoSearchQuery();
            videoQuery.q = "a";
            videoQuery.customConfig = Constants.CUSTOM_CONFIG_ID;


            if (useAPI)
                VideoSearchService.callVideoSearchAPI(videoQuery);
            else
                Console.WriteLine("No SDK Available...");
        }

        public static void callWebQuery(bool useAPI)
        {
            var webQuery = new WebSearchQuery();
            webQuery.q = "chatbots";
            webQuery.customConfig = Constants.CUSTOM_CONFIG_ID;

            if (useAPI)
                WebSearchService.callWebSearchAPI(webQuery);
            else
                WebSearchService.callWebSearchSDK(webQuery);
        }
        public static void callImageQuery(bool useAPI)
        {
            var imageQuery = new ImageSearchQuery();
            imageQuery.q = "chatbots";
            imageQuery.customConfig = Constants.CUSTOM_CONFIG_ID;

            if (useAPI)
                ImageSearchService.callImageSearchAPI(imageQuery);
            else
                ImageSearchService.callImageSearchSDK(imageQuery);
        }

    }
}
