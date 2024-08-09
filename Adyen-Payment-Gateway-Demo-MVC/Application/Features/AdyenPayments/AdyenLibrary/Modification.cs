using Adyen.Model.Checkout;
using Adyen_Payment_Gateway_Demo_MVC.Configuration;
using System.Threading.Tasks;
using System;
using Adyen.Model.Payment;
using Adyen.Model.LegalEntityManagement;

namespace Adyen_Payment_Gateway_Demo_MVC.Application.Features.AdyenPayments.AdyenLibrary
{
    public class Modification
    {
        public async Task<dynamic> SplitRefundInitiate(RefundRequest request)
        {
            try
            {
                var client = new AdyenClientService().CreateAdyenClient();
                request.MerchantAccount = StaticVariablesConfig.GetAdyenMerchantCode();

                var service = new Adyen.Service.PaymentService(client);
                var response = service.Refund(request);
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while getting payment methods: {ex.Message}");
                throw;
            }
        }
    }
}