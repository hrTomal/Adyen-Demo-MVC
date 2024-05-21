using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Adyen.Model.Checkout;
using Adyen.Service.Checkout;
using Adyen_Payment_Gateway_Demo_MVC.Configuration;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Entity;
using Adyen_Payment_Gateway_Demo_MVC.Repository.Adyen;
using Newtonsoft.Json.Linq;

namespace Adyen_Payment_Gateway_Demo_MVC.Application.Features.AdyenPayments.AdyenLibrary
{
    public class SubmitAdditionalPaymentDetails
    {
        public async Task<dynamic> SubmitAdditionalDetails(PaymentDetailsRequest request)
        {
            try
            {
                var client = new AdyenClientService().CreateAdyenClient();
                var requestOptions = new AdyenClientService().CreateRequestOptions();
                var service = new PaymentsService(client);
                var response = await service.PaymentsDetailsAsync(request, requestOptions);

                if (response != null && response.ResultCode == PaymentDetailsResponse.ResultCodeEnum.Authorised)
                {
                    SuccessPaymentLog log = new SuccessPaymentLog();
                    log.resultCode = response.ResultCode.ToString();
                    log.pspReference = response.PspReference;
                    log.merchantReference = response.MerchantReference;
                    log.amount = response.Amount.Value ?? 0;
                    log.currency = response.Amount.Currency;
                    log.paymentMethodBrand = response.PaymentMethod.Brand;
                    log.paymentMethodType = response.PaymentMethod.Type;
                    new SuccessPaymentLogRepository().AddSuccessPaymentLog(log);
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