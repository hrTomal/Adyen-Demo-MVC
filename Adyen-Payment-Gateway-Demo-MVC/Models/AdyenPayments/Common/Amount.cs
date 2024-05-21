using Newtonsoft.Json;

namespace Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Common
{
    public class Amount
    {
        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}