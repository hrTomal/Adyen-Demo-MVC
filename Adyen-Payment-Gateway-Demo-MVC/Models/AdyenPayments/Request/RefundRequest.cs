using Newtonsoft.Json;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Common;


namespace Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Request
{
    public class RefundRequest
    {
        [JsonProperty("amount")]
        public Amount Amount { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("merchantAccount")]
        public string MerchantAccount { get; set; }
    }
}