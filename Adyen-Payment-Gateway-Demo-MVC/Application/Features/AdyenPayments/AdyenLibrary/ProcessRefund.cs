using System;
using System.Threading.Tasks;
using Adyen.Model.Checkout;
using Adyen.Model.Payment;
using Adyen_Payment_Gateway_Demo_MVC.Configuration;

namespace Adyen_Payment_Gateway_Demo_MVC.Application.Features.AdyenPayments.AdyenLibrary
{
    public class ProcessRefund
    {
        public async Task<PaymentRefundResponse> ProcessARefund(PaymentRefundRequest request)
        {
            try
            {
                var client = new AdyenClientService().CreateAdyenClient();

                var refundRequest = new RefundRequest
                {
                    MerchantAccount = StaticVariablesConfig.GetAdyenMerchantCode(),
                    OriginalReference = request.Reference
                };

                

                return default;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while getting payment methods: {ex.Message}");
                throw;
            }
        }
    }
}