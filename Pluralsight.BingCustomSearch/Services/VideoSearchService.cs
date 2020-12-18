using Newtonsoft.Json;
using Pluralsight.BingCustomSearch.Models.Request_Models;
using Pluralsight.BingCustomSearch.Models.Response_Models.Error_Responses;
using Pluralsight.BingCustomSearch.Models.Response_Models.Video_Search_Models;
using System;
using System.Net.Http;

namespace Pluralsight.BingCustomSearch.Services
{
    public static class VideoSearchService
    {
        public static void callVideoSearchAPI(VideoSearchQuery query)
        {
            var url = Constants.VIDEO_SEARCH_URL +
                "cc=" + query.cc +
                "&count=" + query.count +
                "&customConfig=" + query.customConfig +
                "&mkt=" + query.mkt +
                "&offset=" + query.offset +
                "&q=" + query.q +
                "&safeSearch=" + query.safeSearch +
                "&setLang=" + query.setLang +
                Helpers.AddParameter("freshness", query.freshness) +
                Helpers.AddParameter("pricing", query.pricing) +
                Helpers.AddParameter("resolution", query.resolution) +
                Helpers.AddParameter("videoLength", query.videoLength);


            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Constants.SUBSCRIPTION_KEY);
            var httpResponseMessage = client.GetAsync(url).Result;
            var responseContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
            VideosResponse response = JsonConvert.DeserializeObject<VideosResponse>(responseContent);
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
            Console.WriteLine(" freshness:" + query.freshness);
            Console.WriteLine(" pricing:" + query.pricing);
            Console.WriteLine(" resolution:" + query.resolution);
            Console.WriteLine(" videoLength:" + query.videoLength);
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

                if (response.pivotSuggestions != null)
                {
                    Console.WriteLine(" pivotSuggestions:");
                    Console.WriteLine("     pivot:" + response.pivotSuggestions.pivot);
                    Console.WriteLine("     suggestions:");
                    Console.WriteLine("         displayText:" + response.pivotSuggestions.suggestions.displayText);
                    Console.WriteLine("         searchLink:" + response.pivotSuggestions.suggestions.searchLink);
                    Console.WriteLine("         text:" + response.pivotSuggestions.suggestions.text);
                    Console.WriteLine("         thumbnail:");
                    Console.WriteLine("             url:" + response.pivotSuggestions.suggestions.thumbnail.url);
                    Console.WriteLine("         text:" + response.pivotSuggestions.suggestions.webSearchUrl);
                }
                if (response.instrumentation != null)
                {
                    Console.WriteLine(" instrumentation:");
                    Console.WriteLine("     _type:" + response.instrumentation._type);
                    Console.WriteLine("     pingUrlBase:" + response.instrumentation.pingUrlBase);
                    Console.WriteLine("     pageLoadPingUrl:" + response.instrumentation.pageLoadPingUrl);
                }
                if (response.queryExpansions != null)
                {
                    Console.WriteLine(" queryExpansions:");
                    Console.WriteLine("     displayText:" + response.queryExpansions.displayText);
                    Console.WriteLine("     searchLink:" + response.queryExpansions.searchLink);
                    Console.WriteLine("     text:" + response.queryExpansions.text);
                    Console.WriteLine("     thumbnail:");
                    Console.WriteLine("         url:" + response.queryExpansions.thumbnail.url);
                    Console.WriteLine("     webSearchUrl:" + response.queryExpansions.webSearchUrl);
                }
                if (response.similarTerms != null)
                {
                    Console.WriteLine(" similarTerms:");
                    Console.WriteLine("     displayText:" + response.similarTerms.displayText);
                    Console.WriteLine("     searchLink:" + response.similarTerms.searchLink);
                    Console.WriteLine("     text:" + response.similarTerms.text);
                    Console.WriteLine("     thumbnail:");
                    Console.WriteLine("         url:" + response.similarTerms.thumbnail.url);
                    Console.WriteLine("     webSearchUrl:" + response.similarTerms.webSearchUrl);
                }
                Console.WriteLine(" readLink:" + response.readLink);
                Console.WriteLine(" nextOffset:" + response.nextOffset);
                Console.WriteLine(" webSearchUrl:" + response.webSearchUrl);
                Console.WriteLine(" totalEstimatedMatches:" + response.totalEstimatedMatches);

                Console.WriteLine(" value:");
                for (int i = 0; i < response.value.Length; i++)
                {
                    var video = response.value[i];
                    Console.WriteLine("         ***************************************************************");
                    Console.WriteLine("         name:" + video.name);
                    Console.WriteLine("         allowHttpsEmbed:" + video.allowHttpsEmbed);
                    Console.WriteLine("         allowMobileEmbed:" + video.allowMobileEmbed);
                    Console.WriteLine("         contentUrl:" + video.contentUrl);
                    Console.WriteLine("         creator:" + video.creator);
                    Console.WriteLine("         datePublished:" + video.datePublished);
                    Console.WriteLine("         description:" + video.description);
                    Console.WriteLine("         duration:" + video.duration);
                    Console.WriteLine("         embedHtml:" + video.embedHtml);
                    Console.WriteLine("         encodingFormat:" + video.encodingFormat);
                    Console.WriteLine("         height:" + video.height);
                    Console.WriteLine("         hostPageDisplayUrl:" + video.hostPageDisplayUrl);
                    Console.WriteLine("         hostPageUrl:" + video.hostPageUrl);
                    Console.WriteLine("         isAccessibleForFree:" + video.isAccessibleForFree);
                    Console.WriteLine("         isSuperfresh:" + video.isSuperfresh);
                    Console.WriteLine("         mainEntity:" + video.mainEntity);
                    Console.WriteLine("         motionThumbnailUrl:" + video.motionThumbnailUrl);
                    Console.WriteLine("         publisher:");
                    for (int j = 0; j < video.publisher.Length; j++)
                    {
                        var publisher = video.publisher[j];
                        Console.WriteLine("             name:" + publisher.name);
                    }
                    Console.WriteLine("         thumbnail:");
                    Console.WriteLine("             height:" + video.thumbnail.height);
                    Console.WriteLine("             width:" + video.thumbnail.width);
                    Console.WriteLine("         thumbnailUrl:" + video.thumbnailUrl);
                    Console.WriteLine("         videoId:" + video.videoId);
                    Console.WriteLine("         viewCount:" + video.viewCount);
                    Console.WriteLine("         webSearchUrl:" + video.webSearchUrl);
                    Console.WriteLine("         width:" + video.width);
                    Console.WriteLine("         ***************************************************************");
                    Console.WriteLine("");
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

    }
}
