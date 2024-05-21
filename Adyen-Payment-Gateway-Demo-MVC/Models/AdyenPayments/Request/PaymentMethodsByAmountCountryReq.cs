using Newtonsoft.Json;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Common;

namespace Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Request
{
    public class PaymentMethodsByAmountCountryReq
    {
        [JsonProperty("merchantAccount")]
        public string MerchantAccount { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("shopperLocale")]
        public string ShopperLocale { get; set; }

        [JsonProperty("amount")]
        public Amount Amount { get; set; }
    }
}