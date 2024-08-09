using Adyen_Payment_Gateway_Demo_MVC.Configuration;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Adyen_Payment_Gateway_Demo_MVC.Application.Features.BalancePlatform
{
    public class Stores
    {
        public async Task<dynamic> Get(string id)
        {
            var client = new AdyenClientService().CreateAdyenClient();
            try
            {
                var service = new Adyen.Service.Management.AccountStoreLevelService(client);
                var response = service.GetStoreById(id);
                return response;
            }
            catch (Adyen.HttpClient.HttpClientException ex)
            {
                return JObject.Parse(ex.ResponseBody);
            }
        }
        public async Task<dynamic> Create(Adyen.Model.Management.StoreCreationWithMerchantCodeRequest storeCreationRequest)
        {
            var client = new AdyenClientService().CreateAdyenClient();
            try
            {
                var service = new Adyen.Service.Management.AccountStoreLevelService(client);
                storeCreationRequest.MerchantId = StaticVariablesConfig.GetAdyenMerchantCode();

                var response = service.CreateStore(storeCreationRequest);
                return response;
            }
            catch (Adyen.HttpClient.HttpClientException ex)
            {
                return JObject.Parse(ex.ResponseBody);
            }
        }
    }
}