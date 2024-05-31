using Adyen_Payment_Gateway_Demo_MVC.Configuration;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System;
using Adyen.Service.BalancePlatform;

namespace Adyen_Payment_Gateway_Demo_MVC.Application.Features.BalancePlatform
{
    public class GetBalancePlatform
    {
        public async Task<dynamic> BalancePlatform(string id)
        {
            try
            {
                var client = new AdyenClientService().CreateBalancePlatformClient();

                var service = new PlatformService(client);
                var response = service.GetBalancePlatform(id);
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