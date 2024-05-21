using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Common
{
    public class ApiCommonError
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("errorType")]
        public string ErrorType { get; set; }

        [JsonProperty("pspReference")]
        public string PspReference { get; set; }
    }
}