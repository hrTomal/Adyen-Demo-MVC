using Newtonsoft.Json;

namespace Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Response
{
    public class PaymentDetailsSubmitResponse
    {
        [JsonProperty("resultCode")]
        public string ResultCode { get; set; }

        [JsonProperty("pspReference")]
        public string PspReference { get; set; }
    }
}