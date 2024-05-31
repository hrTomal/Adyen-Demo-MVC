using System;
using System.Threading.Tasks;
using Adyen.Model.BalancePlatform;
using Adyen.Model.PlatformsAccount;
using Adyen_Payment_Gateway_Demo_MVC.Configuration;
using Newtonsoft.Json.Linq;

namespace Adyen_Payment_Gateway_Demo_MVC.Application.Features.BalancePlatform
{
    public class BalanceAccounts
    {
        internal async Task<dynamic> CreateBalanceAccount(BalanceAccountInfo request)
        {
            try
            {
                var client = new AdyenClientService().CreateBalancePlatformClient();
                var service = new Adyen.Service.BalancePlatform.BalanceAccountsService(client);
                var response = service.CreateBalanceAccount(request);
                return response;
            }
            catch (Adyen.HttpClient.HttpClientException ex)
            {
                return JObject.Parse(ex.ResponseBody);
            }
        }
    }
}