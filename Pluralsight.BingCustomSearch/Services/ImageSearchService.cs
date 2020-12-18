
using Microsoft.Azure.CognitiveServices.Search.CustomImageSearch;
using Newtonsoft.Json;
using Pluralsight.BingCustomSearch.Models;
using Pluralsight.BingCustomSearch.Models.Request_Models;
using Pluralsight.BingCustomSearch.Models.Response_Models.Error_Responses;
using Pluralsight.BingCustomSearch.Models.Response_Models.Image_Search_Models;
using System;
using System.Net.Http;

namespace Pluralsight.BingCustomSearch.Services
{
    public static class ImageSearchService
    {
        public static void callImageSearchAPI(ImageSearchQuery query)
        {
            var url = Constants.IMAGE_SEARCH_URL +
                "cc=" + query.cc +
                "&count=" + query.count +
                "&customConfig=" + query.customConfig +
                "&mkt=" + query.mkt +
                "&offset=" + query.offset +
                "&q=" + query.q +
                "&safeSearch=" + query.safeSearch +
                "&setLang=" + query.setLang +
                Helpers.AddParameter("aspect", query.aspect) +
                Helpers.AddParameter("color", query.color) +
                Helpers.AddParameter("height", query.height) +
                Helpers.AddParameter("imageContent", query.imageContent) +
                Helpers.AddParameter("imageType", query.imageType) +
                Helpers.AddParameter("license", query.license) +
                Helpers.AddParameter("maxFileSize", query.maxFileSize) +
                Helpers.AddParameter("maxHeight", query.maxHeight) +
                Helpers.AddParameter("maxWidth", query.maxWidth) +
                Helpers.AddParameter("minFileSize", query.minFileSize) +
                Helpers.AddParameter("minHeight", query.minHeight) +
                Helpers.AddParameter("minWidth", query.minWidth) +
                Helpers.AddParameter("size", query.size) +
                Helpers.AddParameter("width", query.width);

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Constants.SUBSCRIPTION_KEY);
            var httpResponseMessage = client.GetAsync(url).Result;
            var responseContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
            ImagesResponse response = JsonConvert.DeserializeObject<ImagesResponse>(responseContent);
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
            Console.WriteLine(" aspect:" + query.aspect);
            Console.WriteLine(" color:" + query.color);
            Console.WriteLine(" height:" + query.height);
            Console.WriteLine(" imageContent:" + query.imageContent);
            Console.WriteLine(" imageType:" + query.imageType);
            Console.WriteLine(" license:" + query.license);
            Console.WriteLine(" maxFileSize:" + query.maxFileSize);
            Console.WriteLine(" maxHeight:" + query.maxHeight);
            Console.WriteLine(" maxWidth:" + query.maxWidth);
            Console.WriteLine(" minFileSize:" + query.minFileSize);
            Console.WriteLine(" minHeight:" + query.minHeight);
            Console.WriteLine(" minWidth:" + query.minWidth);
            Console.WriteLine(" size:" + query.size);
            Console.WriteLine(" width:" + query.width);
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
                if (response.instrumentation != null)
                {
                    Console.WriteLine(" instrumentation:");
                    Console.WriteLine("     _type:" + response.instrumentation._type);
                    Console.WriteLine("     pingUrlBase:" + response.instrumentation.pingUrlBase);
                    Console.WriteLine("     pageLoadPingUrl:" + response.instrumentation.pageLoadPingUrl);
                }
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
                    var image = response.value[i];
                    Console.WriteLine("         ***************************************************************");
                    Console.WriteLine("         name:" + image.name);
                    Console.WriteLine("         contentUrl:" + image.contentUrl);
                    Console.WriteLine("         accentColor:" + image.accentColor);
                    Console.WriteLine("         contentSize:" + image.contentSize);
                    Console.WriteLine("         datePublished:" + image.datePublished);
                    Console.WriteLine("         encodingFormat:" + image.encodingFormat);
                    Console.WriteLine("         height:" + image.height);
                    Console.WriteLine("         hostPageDisplayUrl:" + image.hostPageDisplayUrl);
                    Console.WriteLine("         hostPageUrl:" + image.hostPageUrl);
                    Console.WriteLine("         imageId:" + image.imageId);
                    Console.WriteLine("         thumbnailUrl:" + image.thumbnailUrl);
                    Console.WriteLine("         webSearchUrl:" + image.webSearchUrl);
                    Console.WriteLine("         width:" + image.width);
                    Console.WriteLine("         imageInsightsToken:" + image.imageInsightsToken);
                    Console.WriteLine("         thumbnail:");
                    Console.WriteLine("             height:" + image.thumbnail.height);
                    Console.WriteLine("             width:" + image.thumbnail.width);
                    Console.WriteLine("         ***************************************************************");
                    Console.WriteLine("");
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public static void callImageSearchSDK(ImageSearchQuery query)
        {

            var client = new CustomImageSearchClient(new ApiKeyServiceClientCredentials(Constants.SUBSCRIPTION_KEY));
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
                Console.WriteLine(" aspect:" + query.aspect);
                Console.WriteLine(" color:" + query.color);
                Console.WriteLine(" height:" + query.height);
                Console.WriteLine(" imageContent:" + query.imageContent);
                Console.WriteLine(" imageType:" + query.imageType);
                Console.WriteLine(" license:" + query.license);
                Console.WriteLine(" maxFileSize:" + query.maxFileSize);
                Console.WriteLine(" maxHeight:" + query.maxHeight);
                Console.WriteLine(" maxWidth:" + query.maxWidth);
                Console.WriteLine(" minFileSize:" + query.minFileSize);
                Console.WriteLine(" minHeight:" + query.minHeight);
                Console.WriteLine(" minWidth:" + query.minWidth);
                Console.WriteLine(" size:" + query.size);
                Console.WriteLine(" width:" + query.width);
                Console.WriteLine("");

                var imageData = client.CustomInstance.ImageSearchAsync(
                    customConfig: query.customConfig,
                    query: query.q,
                    countryCode: query.cc,
                    count: query.count,
                    market: query.mkt,
                    offset: query.offset,
                    safeSearch: query.safeSearch,
                    setLang: query.setLang,
                    aspect: query.aspect,
                    color: query.color,
                    height: query.height,
                    imageContent: query.imageContent,
                    imageType: query.imageType,
                    license: query.license,
                    maxFileSize: query.maxFileSize,
                    maxHeight: query.maxHeight,
                    maxWidth: query.maxWidth,
                    minFileSize: query.minFileSize,
                    minHeight: query.minHeight,
                    minWidth: query.minWidth,
                    size: query.size,
                    width: query.width
                    ).Result;

                Console.WriteLine("************************************************************************");
                Console.WriteLine("*** Response Parameters                                              ***");
                Console.WriteLine("************************************************************************");
                Console.WriteLine(" _type:N/A");
                Console.WriteLine(" instrumentation:");
                Console.WriteLine("     _type:N/A");
                Console.WriteLine("     pingUrlBase:N/A");
                Console.WriteLine("     pageLoadPingUrl:N/A");
                Console.WriteLine(" pivotSuggestions:");
                Console.WriteLine("     pivot:N/A");
                Console.WriteLine("     suggestions:");
                Console.WriteLine("         displayText:N/A");   
                Console.WriteLine("         searchLink:N/A");
                Console.WriteLine("         text:N/A");
                Console.WriteLine("         thumbnail:");
                Console.WriteLine("             url:N/A");
                Console.WriteLine("         text:N/A");
                Console.WriteLine(" queryExpansions:");
                Console.WriteLine("     displayText:N/A");
                Console.WriteLine("     searchLink:N/A");
                Console.WriteLine("     text:N/A");
                Console.WriteLine("     thumbnail:");
                Console.WriteLine("         url:N/A");
                Console.WriteLine("     webSearchUrl:N/A");
                Console.WriteLine(" similarTerms:");
                Console.WriteLine("     displayText:N/A");
                Console.WriteLine("     searchLink:N/A");
                Console.WriteLine("     text:N/A");
                Console.WriteLine("     thumbnail:");
                Console.WriteLine("         url:N/A");
                Console.WriteLine("         webSearchUrl:N/A");
                Console.WriteLine(" (id):" + imageData.Id);
                Console.WriteLine(" nextOffset:" + imageData.NextOffset);
                Console.WriteLine(" webSearchUrl:" + imageData.WebSearchUrl);
                Console.WriteLine(" readLink:" + imageData.ReadLink);
                Console.WriteLine(" totalEstimatedMatches:" + imageData.TotalEstimatedMatches);

                Console.WriteLine(" value:");
                foreach (var image in imageData.Value)
                {
                    Console.WriteLine("         ***************************************************************");
                    Console.WriteLine("         name:" + image.Name);
                    Console.WriteLine("         (alternateName):" + image.AlternateName);
                    Console.WriteLine("         (bingId):" + image.BingId);
                    Console.WriteLine("         contentUrl:" + image.ContentUrl);
                    Console.WriteLine("         accentColor:" + image.AccentColor);
                    Console.WriteLine("         contentSize:" + image.ContentSize);
                    Console.WriteLine("         datePublished:N/A");
                    Console.WriteLine("         (description):" + image.Description);
                    Console.WriteLine("         encodingFormat:" + image.EncodingFormat);
                    Console.WriteLine("         height:" + image.Height);
                    Console.WriteLine("         hostPageDisplayUrl:" + image.HostPageDisplayUrl);
                    Console.WriteLine("         hostPageUrl:" + image.HostPageUrl);
                    Console.WriteLine("         (Id):" + image.Id);
                    Console.WriteLine("         imageId:" + image.ImageId);
                    Console.WriteLine("         (provider):" + image.Provider);
                    Console.WriteLine("         (readLink):" + image.ReadLink);
                    Console.WriteLine("         (text):" + image.Text);
                    Console.WriteLine("         (url):" + image.Url);
                    Console.WriteLine("         thumbnailUrl:" + image.ThumbnailUrl);
                    Console.WriteLine("         webSearchUrl:" + image.WebSearchUrl);
                    Console.WriteLine("         width:" + image.Width);
                    Console.WriteLine("         imageInsightsToken:" + image.ImageInsightsToken);
                    Console.WriteLine("         thumbnail:");
                    Console.WriteLine("             height:" + image.Thumbnail.Height);
                    Console.WriteLine("             width:" + image.Thumbnail.Width);
                    Console.WriteLine("         ***************************************************************");
                    Console.WriteLine("");
                }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
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
