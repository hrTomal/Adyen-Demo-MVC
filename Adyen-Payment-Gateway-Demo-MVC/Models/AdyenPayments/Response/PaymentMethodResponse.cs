using System.Collections.Generic;
using Newtonsoft.Json;

namespace Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Response
{
    public class PaymentMethodResponse
    {
        [JsonProperty("paymentMethods")]
        public List<PaymentMethod> PaymentMethods { get; set; }
    }

    public class Issuer
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("disabled")]
        public bool? Disabled { get; set; }
    }

    public class PaymentMethod
    {
        [JsonProperty("brands")]
        public List<string> Brands { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("issuers")]
        public List<Issuer> Issuers { get; set; }
    }

    


}