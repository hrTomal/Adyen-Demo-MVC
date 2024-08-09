using Adyen.Model.Checkout;
using Adyen.Service.Checkout;
using Adyen_Payment_Gateway_Demo_MVC.Configuration;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Entity;
using Adyen_Payment_Gateway_Demo_MVC.Repository.Adyen;
using Newtonsoft.Json.Linq;
using System;

namespace Adyen_Payment_Gateway_Demo_MVC.Application.Features.AdyenPayments.AdyenLibrary
{
    public class PaymentModification
    {
        public dynamic InitiateRefund()
        {
            try
            {
                var client = new AdyenClientService().CreateAdyenClient();


                return default;
            }
            catch (Adyen.HttpClient.HttpClientException ex)
            {
                Console.WriteLine($"Error occurred while getting payment methods: {ex.Message}");
                return JObject.Parse(ex.ResponseBody);
            }
        }
    }
}