using Newtonsoft.Json;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Common;

namespace Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.LibraryRequests
{
    public class PaymentMethodsReq
    {
        [JsonProperty("amount")]
        public Amount Amount { get; set; }
        
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }
}