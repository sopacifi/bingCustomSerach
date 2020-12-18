using System;
using System.Collections.Generic;
using System.Text;

namespace Pluralsight.BingCustomSearch.Models.Response_Models.Error_Responses
{
    public class ErrorResponse
    {
        public string _type { get; set; }
        public Error[] errors { get; set; }
    }
}
