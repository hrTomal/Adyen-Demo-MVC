using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing.Drawing2D;

namespace Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Response
{
    public class CheckCardDetailsResponse
    {
        [JsonProperty("brands")]
        public List<Brand> Brands { get; set; }

        [JsonProperty("issuingCountryCode")]
        public string IssuingCountryCode { get; set; }
    }

    public class Brand
    {
        [JsonProperty("supported")]
        public bool Supported { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}