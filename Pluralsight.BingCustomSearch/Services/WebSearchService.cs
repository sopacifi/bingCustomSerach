using Microsoft.Azure.CognitiveServices.Search.CustomSearch;
using Newtonsoft.Json;
using Pluralsight.BingCustomSearch.Models;
using Pluralsight.BingCustomSearch.Models.Request_Models;
using Pluralsight.BingCustomSearch.Models.Response_Models.Error_Responses;
using Pluralsight.BingCustomSearch.Models.Response_Models.Web_Search_Models;
using System;
using System.Net.Http;

namespace Pluralsight.BingCustomSearch.Services
{
    public static class WebSearchService
    {
        public static void callWebSearchAPI(WebSearchQuery query)
        {

            var url = Constants.WEB_SEARCH_URL +
                "cc=" + query.cc +
                "&count=" + query.count +
                "&customConfig=" + query.customConfig +
                "&mkt=" + query.mkt +
                "&offset=" + query.offset +
                "&q=" + query.q +
                "&safeSearch=" + query.safeSearch +
                "&setLang=" + query.setLang +
                "&textDecorations=" + query.textDecorations +
                Helpers.AddParameter("textFormat", query.textFormat);

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Constants.SUBSCRIPTION_KEY);
            var httpResponseMessage = client.GetAsync(url).Result;
            var responseContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
            WebSearchResponse response = JsonConvert.DeserializeObject<WebSearchResponse>(responseContent);
            ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(responseContent);


            Console.WriteLine("************************************************************************");
            Console.WriteLine("*** Query Parameters                                                 ***");
            Console.WriteLine("************************************************************************");
            Console.WriteLine(" url: " + url);
            Console.WriteLine(" cc:" + query.cc);
            Console.WriteLine(" count:" + query.count);
            Console.WriteLine(" customConfig:" + query.customConfig);
            Console.WriteLine(" mkt:" + query.mkt);
            Console.WriteLine(" offset:" + query.offset);
            Console.WriteLine(" q:" + query.q);
            Console.WriteLine(" safeSearch:" + query.safeSearch);
            Console.WriteLine(" setLang:" + query.setLang);
            Console.WriteLine(" textDecorations:" + query.textDecorations);
            Console.WriteLine(" textFormat:" + query.textFormat);
            Console.WriteLine("");

            if (errorResponse.errors != null)
            {
                for (int i = 0; i < errorResponse.errors.Length; i++)
                {
                    var error = errorResponse.errors[i];

                    Console.WriteLine("code:" + error.code);
                    Console.WriteLine("message: " + error.message);
                    Console.WriteLine("parameter: " + error.parameter);
                    Console.WriteLine("value: " + error.value);
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("************************************************************************");
                Console.WriteLine("*** Response Parameters                                              ***");
                Console.WriteLine("************************************************************************");
                Console.WriteLine(" _type:" + response._type);
                Console.WriteLine(" queryContext:");
                Console.WriteLine("     adultIntent:" + response.queryContext.adultIntent);
                Console.WriteLine("     alterationOverrideQuery:" + response.queryContext.alterationOverrideQuery);
                Console.WriteLine("     alteredQuery:" + response.queryContext.alteredQuery);
                Console.WriteLine("     originalQuery:" + response.queryContext.originalQuery);
                Console.WriteLine(" webPages:");
                Console.WriteLine("     totalEstimatedMatches:" + response.webPages.totalEstimatedMatches);
                Console.WriteLine("     webSearchUrl:" + response.webPages.webSearchUrl);
                Console.WriteLine("     value:");
                for (int i = 0; i < response.webPages.value.Length; i++)
                {
                    var webPage = response.webPages.value[i];
                    Console.WriteLine("         ***************************************************************");
                    Console.WriteLine("         name:" + webPage.name);
                    Console.WriteLine("         dateLastCrawled:" + webPage.dateLastCrawled);
                    Console.WriteLine("         displayUrl:" + webPage.displayUrl);
                    Console.WriteLine("         id:" + webPage.id);                    
                    Console.WriteLine("         snippet:" + webPage.snippet);
                    Console.WriteLine("         url:" + webPage.url);
                    if (webPage.openGraphImage != null)
                    {
                        Console.WriteLine("         openGraphImage:");
                        Console.WriteLine("             contentUrl:" +webPage.openGraphImage.contentUrl);
                        Console.WriteLine("             width:" + webPage.openGraphImage.width);
                        Console.WriteLine("             height:" + webPage.openGraphImage.height);
                    }
                    if (webPage.searchTags != null)
                    {
                        Console.WriteLine("         searchTags:");
                        for (int j = 0; j < webPage.searchTags.Length; j++)
                        {
                            var meta = webPage.searchTags[j];
                            Console.WriteLine("             name:" + meta.name);
                            Console.WriteLine("             content:" + meta.content);
                        }
                    }
                    Console.WriteLine("         ***************************************************************");
                    Console.WriteLine("");
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public static void callWebSearchSDK(WebSearchQuery query)
        {
            var client = new CustomSearchAPI(new ApiKeyServiceClientCredentials(Constants.SUBSCRIPTION_KEY));

            try
            {
                Console.WriteLine("************************************************************************");
                Console.WriteLine("*** Query Parameters                                                 ***");
                Console.WriteLine("************************************************************************");
                Console.WriteLine(" cc:" + query.cc);
                Console.WriteLine(" count:" + query.count);
                Console.WriteLine(" customConfig:" + query.customConfig);
                Console.WriteLine(" mkt:" + query.mkt);
                Console.WriteLine(" offset:" + query.offset);
                Console.WriteLine(" q:" + query.q);
                Console.WriteLine(" safeSearch:" + query.safeSearch);
                Console.WriteLine(" setLang:" + query.setLang);
                Console.WriteLine(" textDecorations:" + query.textDecorations);
                Console.WriteLine(" textFormat:" + query.textFormat);
                Console.WriteLine("");

                var webData = client.CustomInstance.SearchAsync(
                    customConfig:query.customConfig, 
                    query:query.q,
                    countryCode:query.cc, 
                    count:query.count, 
                    market:query.mkt, 
                    offset:query.offset, 
                    safeSearch:query.safeSearch, 
                    setLang:query.setLang, 
                    textDecorations:query.textDecorations, 
                    textFormat: query.textFormat
                   ).Result;

                Console.WriteLine("************************************************************************");
                Console.WriteLine("*** Response Parameters                                              ***");
                Console.WriteLine("************************************************************************");
                Console.WriteLine(" _type:N/A");
                Console.WriteLine(" (webSearchURL):" + webData.WebSearchUrl);
                Console.WriteLine(" queryContext:");
                Console.WriteLine("     adultIntent:" + webData.QueryContext.AdultIntent);
                Console.WriteLine("     alterationOverrideQuery:" + webData.QueryContext.AlterationOverrideQuery);
                Console.WriteLine("     alteredQuery:" + webData.QueryContext.AlteredQuery);
                Console.WriteLine("     originalQuery:" + webData.QueryContext.OriginalQuery);
                Console.WriteLine(" webPages:");
                Console.WriteLine("     (id):" + webData.WebPages.Id);
                Console.WriteLine("     (isFamilyFriendly):" + webData.WebPages.IsFamilyFriendly);
                Console.WriteLine("     (someResultsRemoved):" + webData.WebPages.SomeResultsRemoved);
                Console.WriteLine("     totalEstimatedMatches:" + webData.WebPages.TotalEstimatedMatches);
                Console.WriteLine("     webSearchUrl:" + webData.WebPages.WebSearchUrl);
                Console.WriteLine("     value:");
                foreach (var webPage in webData.WebPages.Value)
                {
                    Console.WriteLine("         ***************************************************************");
                    Console.WriteLine("         name:" + webPage.Name);
                    Console.WriteLine("         dateLastCrawled:" + webPage.DateLastCrawled);
                    Console.WriteLine("         displayUrl:" + webPage.DisplayUrl);
                    Console.WriteLine("         id:" + webPage.Id);
                    Console.WriteLine("         snippet:" + webPage.Snippet);
                    Console.WriteLine("         url:" + webPage.Url);
                    Console.WriteLine("         openGraphImage:N/A");
                    if (webPage.SearchTags != null)
                    {
                        Console.WriteLine("         searchTags:");
                        foreach (var meta in webPage.SearchTags)
                        {
                            Console.WriteLine("             name:" + meta.Name);
                            Console.WriteLine("             content:" + meta.Content);
                        }
                    }
                    Console.WriteLine("         provider:" + webPage.Provider);
                    Console.WriteLine("         thumbnailUrl:" + webPage.ThumbnailUrl);
                    Console.WriteLine("         webSearchUrl:" + webPage.WebSearchUrl);
                    Console.WriteLine("         ***************************************************************");
                    Console.WriteLine("");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("code:" + ex.Message);
                Console.WriteLine("");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
