using Newtonsoft.Json;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Common;

namespace Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Request
{
    public class PaymentSessionRequest
    {
        [JsonProperty("merchantAccount")]
        public string MerchantAccount { get; set; }

        [JsonProperty("amount")]
        public Amount Amount { get; set; }

        [JsonProperty("returnUrl")]
        public string ReturnUrl { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }
}