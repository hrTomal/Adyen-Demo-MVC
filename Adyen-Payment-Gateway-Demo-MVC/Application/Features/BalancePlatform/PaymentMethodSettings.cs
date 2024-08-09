using Adyen.Model.Management;
using Adyen_Payment_Gateway_Demo_MVC.Configuration;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Adyen_Payment_Gateway_Demo_MVC.Application.Features.BalancePlatform
{
    public class PaymentMethodSettings
    {
        public async Task<dynamic> Get(string paymentMethodId)
        {
            var client = new AdyenClientService().CreateAdyenClient();
            try
            {
                var service = new Adyen.Service.Management.PaymentMethodsMerchantLevelService(client);
                var merchantId = StaticVariablesConfig.GetAdyenMerchantCode();
                var response = service.GetPaymentMethodDetails(merchantId,paymentMethodId);
                return response;
            }
            catch (Adyen.HttpClient.HttpClientException ex)
            {
                return JObject.Parse(ex.ResponseBody);
            }
        }
        public async Task<dynamic> Create(PaymentMethodSetupInfo paymentMethodSetupInfo)
        {
            var client = new AdyenClientService().CreateAdyenClient();
            try
            {
                var service = new Adyen.Service.Management.PaymentMethodsMerchantLevelService(client);
                var merchantId = StaticVariablesConfig.GetAdyenMerchantCode();

                var response = service.RequestPaymentMethod(merchantId, paymentMethodSetupInfo);
                return response;
            }
            catch (Adyen.HttpClient.HttpClientException ex)
            {
                return JObject.Parse(ex.ResponseBody);
            }
        }
    }
}