using Newtonsoft.Json;

namespace Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Request
{
    public class PaymentDetailsSubmitRequest
    {
        [JsonProperty("details")]
        public Details Details { get; set; }
    }
    public class Details
    {
        [JsonProperty("redirectResult")]
        public string RedirectResult { get; set; }
        
        [JsonProperty("oneTimePasscode")]
        public string OneTimePasscode { get; set; }

        [JsonProperty("authorization_token")]
        public string Authorization_token { get; set; }
    
        [JsonProperty("billingToken")]
        public string BillingToken { get; set; }

        [JsonProperty("facilitatorAccessToken")]
        public string FacilitatorAccessToken { get; set; }

        [JsonProperty("orderID")]
        public string OrderID { get; set; }

        [JsonProperty("payerID")]
        public string PayerID { get; set; }

        [JsonProperty("payload")]
        public string Payload { get; set; }

        [JsonProperty("paymentID")]
        public string PaymentID { get; set; }

        [JsonProperty("paymentStatus")]
        public string PaymentStatus { get; set; }

        [JsonProperty("resultCode")]
        public string ResultCode { get; set; }

        [JsonProperty("vaultToken")]
        public string VaultToken { get; set; }
    }
}