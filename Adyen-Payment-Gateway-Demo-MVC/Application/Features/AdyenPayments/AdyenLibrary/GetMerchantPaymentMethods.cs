using Adyen.Model.Checkout;
using Adyen.Model;
using Adyen.Service.Checkout;
using Adyen_Payment_Gateway_Demo_MVC.Configuration;
using System.Threading.Tasks;
using System;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.LibraryRequests;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Adyen_Payment_Gateway_Demo_MVC.Application.Features.AdyenPayments.AdyenLibrary
{
    public class GetMerchantPaymentMethods
    {
        public async Task<dynamic> GetPaymentMethods(PaymentMethodsReq request)
        {
            try
            {
                var client = new AdyenClientService().CreateAdyenClient();

                Amount amountObject = request.Amount == null ? null : new Amount(request.Amount.Currency, request.Amount.Value);

                PaymentMethodsRequest paymentMethodsRequest = new PaymentMethodsRequest
                {
                    Amount = amountObject,
                    CountryCode = request.CountryCode,
                    MerchantAccount = StaticVariablesConfig.GetAdyenMerchantCode(),
                    Channel = PaymentMethodsRequest.ChannelEnum.Web,
                    //AllowedPaymentMethods = new List<string> { "scheme", "trustly" }
                };

                var service = new PaymentsService(client);
                var response = await service.PaymentMethodsAsync(paymentMethodsRequest, requestOptions: new AdyenClientService().CreateRequestOptions());

                return response;
            }
            catch (Adyen.HttpClient.HttpClientException ex)
            {
                Console.WriteLine($"Error occurred while getting payment methods: {ex.Message}");
                return JObject.Parse(ex.ResponseBody);
            }
        }

        public async Task<PaymentMethodsResponse> GetPaymentMethods_Test(PaymentMethodsReq request)
        {
            try
            {
                var client = new AdyenClientService().CreateAdyenClient();

                var allowedPaymentMethods = new List<string> { "paysafecard", "scheme" };

                var paymentMethodsRequest = new PaymentMethodsRequest
                {
                    CountryCode = request.CountryCode,
                    MerchantAccount = StaticVariablesConfig.GetAdyenMerchantCode(),
                    AllowedPaymentMethods = allowedPaymentMethods
                };

                var service = new PaymentsService(client);
                var requestOptions = new AdyenClientService().CreateRequestOptions();
                var response = await service.PaymentMethodsAsync(paymentMethodsRequest, requestOptions);

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while getting payment methods: {ex.Message}");
                return null;
            }
        }

    }
}