using System.Collections.Generic;
using Newtonsoft.Json;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Common;

namespace Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Request
{
    public class PaymentsRequest
    {
        [JsonProperty("amount")]
        public Amount Amount { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        //[JsonProperty("paymentMethod")]
        //public PaymentMethod PaymentMethod { get; set; }
        [JsonProperty("paymentMethod")]
        public Dictionary<string, object> PaymentMethod { get; set; }

        [JsonProperty("returnUrl")]
        public string ReturnUrl { get; set; }

        [JsonProperty("merchantAccount")]
        public string MerchantAccount { get; set; }
    }

    //public class Amount
    //{
    //    [JsonProperty("currency")]
    //    public string Currency { get; set; }

    //    [JsonProperty("value")]
    //    public int Value { get; set; }
    //}

    //public class PaymentMethod
    //{
    //    [JsonProperty("type")]
    //    public string Type { get; set; }
    //}

    //public class ApplePayPaymentMethod : PaymentMethod
    //{
    //    [JsonProperty("applePayToken")]
    //    public string ApplePayToken { get; set; }
    //}
    
    //public class SchemePaymentMethod : PaymentMethod
    //{
    //    [JsonProperty("encryptedCardNumber")]
    //    public string EncryptedCardNumber { get; set; }

    //    [JsonProperty("encryptedExpiryMonth")]
    //    public string EncryptedExpiryMonth { get; set; }

    //    [JsonProperty("encryptedExpiryYear")]
    //    public string EncryptedExpiryYear { get; set; }

    //    [JsonProperty("encryptedSecurityCode")]
    //    public string EncryptedSecurityCode { get; set; }
    //}

}

