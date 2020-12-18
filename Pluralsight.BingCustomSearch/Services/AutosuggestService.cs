using Newtonsoft.Json;
using Pluralsight.BingCustomSearch.Models.Request_Models;
using Pluralsight.BingCustomSearch.Models.Response_Models.Autosuggest_Models;
using Pluralsight.BingCustomSearch.Models.Response_Models.Error_Responses;
using System;
using System.Net.Http;

namespace Pluralsight.BingCustomSearch.Services
{
    public static class AutosuggestService
    {
        public static void callAutosuggestSearchAPI(AutosuggestQuery query)
        {
            var url = Constants.AUTOSUGGEST_URL +
                "&customConfig=" + query.customConfig +
                "&q=" + query.q;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Constants.AUTOSUGGEST_SUBSCRIPTION_KEY);
            var httpResponseMessage = client.GetAsync(url).Result;
            var responseContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
            AutosuggestResponse response = JsonConvert.DeserializeObject<AutosuggestResponse>(responseContent);
            ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(responseContent);

            Console.WriteLine("************************************************************************");
            Console.WriteLine("*** Query Parameters                                                 ***");
            Console.WriteLine("************************************************************************");
            Console.WriteLine(" url: " + url);
            Console.WriteLine(" customConfig:" + query.customConfig);  
            Console.WriteLine(" q:" + query.q);
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
                if (response.queryContext != null)
                {
                    Console.WriteLine(" queryContext:");
                    Console.WriteLine("     adultIntent:" + response.queryContext.adultIntent);
                    Console.WriteLine("     alterationOverrideQuery:" + response.queryContext.alterationOverrideQuery);
                    Console.WriteLine("     alteredQuery:" + response.queryContext.alteredQuery);
                    Console.WriteLine("     originalQuery:" + response.queryContext.originalQuery);                    
                }
                Console.WriteLine(" suggestionGroups:");
                for (int i = 0; i < response.suggestionGroups.Length; i++)
                {
                    var suggestion = response.suggestionGroups[i];
                    Console.WriteLine("     name:" + suggestion.name);
                    Console.WriteLine("     searchSuggestions:");
                    for (int j = 0; j < suggestion.searchSuggestions.Length; j++)
                    {
                        var searchSuggestion = suggestion.searchSuggestions[j];
                        Console.WriteLine("         ***************************************************************");
                        Console.WriteLine("         searchKind:" + searchSuggestion.searchKind);
                        Console.WriteLine("         query:" + searchSuggestion.query);
                        Console.WriteLine("         displayText:" + searchSuggestion.displayText);
                    }

                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
