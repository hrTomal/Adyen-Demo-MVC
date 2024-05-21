using Newtonsoft.Json;

namespace Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Response
{
    public class RefundResponse
    {
        [JsonProperty("merchantAccount")]
        public string MerchantAccount { get; set; }

        [JsonProperty("paymentPspReference")]
        public string PaymentPspReference { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("pspReference")]
        public string PspReference { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}