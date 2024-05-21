using System;
using Newtonsoft.Json;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Common;

namespace Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Response
{
    public class PaymentSessionResponse
    {
        [JsonProperty("amount")]
        public Amount Amount { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("expiresAt")]
        public DateTime ExpiresAt { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("merchantAccount")]
        public string MerchantAccount { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("returnUrl")]
        public string ReturnUrl { get; set; }

        [JsonProperty("sessionData")]
        public string SessionData { get; set; }
    }
}