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

namespace Adyen_Payment_Gateway_Demo_MVC.Application.Features.AdyenPayments.AdyenLibrary
{
    public class InitiatePayment
    {
        public async Task<dynamic> InitiateAPaymentAsync(PaymentRequest request)
        {
            try
            {
                //Amount amount = new Amount
                //{
                //    Value = 5000,
                //    Currency = "EUR"
                //};
                var paymentRequest = new PaymentRequest
                {
                    Amount = request.Amount,
                    Reference = request.Reference,
                    MerchantAccount = StaticVariablesConfig.GetAdyenMerchantCode(),
                    PaymentMethod = request.PaymentMethod,
                    ReturnUrl = request.ReturnUrl,
                    AuthenticationData = new AuthenticationData()
                    {
                        AttemptAuthentication = AuthenticationData.AttemptAuthenticationEnum.Always,
                        // Add the following line for Native 3DS2:
                        //ThreeDSRequestData = new ThreeDSRequestData()
                        //{
                        //    NativeThreeDS = ThreeDSRequestData.NativeThreeDSEnum.Preferred
                        //}
                    },
                };

                var client = new AdyenClientService().CreateAdyenClient();
                var requestOptions = new AdyenClientService().CreateRequestOptions();
                var service = new PaymentsService(client);
                var response = service.Payments(paymentRequest, requestOptions);

                if(response != null && response.ResultCode == PaymentResponse.ResultCodeEnum.Authorised) {
                    SuccessPaymentLog log = new SuccessPaymentLog();
                    log.resultCode = response.ResultCode.ToString();
                    log.pspReference = response.PspReference;
                    log.merchantReference = response.MerchantReference;
                    log.amount = response.Amount.Value ?? 0;
                    log.currency = response.Amount.Currency;
                    log.paymentMethodBrand = response.PaymentMethod.Brand;
                    log.paymentMethodType = response.PaymentMethod.Type;
                    log.refundAmount = 0;
                    await new SuccessPaymentLogRepository().AddSuccessPaymentLog(log);
                }

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