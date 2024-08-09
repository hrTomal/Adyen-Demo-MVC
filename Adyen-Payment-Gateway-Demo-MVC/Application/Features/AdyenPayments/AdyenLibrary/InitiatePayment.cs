using Adyen.Model.Checkout;
using Adyen.Service.Checkout;
using System.Threading.Tasks;
using System;
using Adyen_Payment_Gateway_Demo_MVC.Configuration;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Adyen_Payment_Gateway_Demo_MVC.Repository.Adyen;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Entity;
using Adyen.Model;
using Adyen;

namespace Adyen_Payment_Gateway_Demo_MVC.Application.Features.AdyenPayments.AdyenLibrary
{
    public class InitiatePayment
    {
        public dynamic InitiateAPayment(PaymentRequest request)
        {
            try
            {
                request.MerchantAccount = StaticVariablesConfig.GetAdyenMerchantCode();
                request.AuthenticationData = new AuthenticationData()
                {
                    AttemptAuthentication = AuthenticationData.AttemptAuthenticationEnum.Always
                };

                var client = new AdyenClientService().CreateAdyenClient();
                var requestOptions = new AdyenClientService().CreateRequestOptions();
                var service = new PaymentsService(client);
                var response = service.Payments(request, requestOptions);

                return response;
            }
            catch (Adyen.HttpClient.HttpClientException ex)
            {
                Console.WriteLine($"Error occurred while getting payment methods: {ex.Message}");
                return JObject.Parse(ex.ResponseBody);
            }
        }

        internal object InitiateTokenization(PaymentRequest request)
        {
            try
            {
                request.MerchantAccount = StaticVariablesConfig.GetAdyenMerchantCode();
                request.AuthenticationData = new AuthenticationData()
                {
                    AttemptAuthentication = AuthenticationData.AttemptAuthenticationEnum.Always
                };

                var client = new AdyenClientService().CreateAdyenClient();
                var service = new PaymentsService(client);
                var requestOptions = new AdyenClientService().CreateRequestOptions();
                var response = service.Payments(request, requestOptions);

                return response;
            }
            catch (Adyen.HttpClient.HttpClientException ex)
            {
                Console.WriteLine($"Error occurred while getting payment methods: {ex.Message}");
                return JObject.Parse(ex.ResponseBody);
            }
        }
    }
}