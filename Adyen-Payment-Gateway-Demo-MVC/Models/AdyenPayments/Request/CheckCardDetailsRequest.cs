using Newtonsoft.Json;

namespace Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Request
{
    public class CheckCardDetailsRequest
    {
        [JsonProperty("merchantAccount")]
        public string MerchantAccount { get; set; }

        [JsonProperty("cardNumber")]
        public string CardNumber { get; set; }
    }
}