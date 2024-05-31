using Adyen.Model.BalancePlatform;
using Adyen.Service.BalancePlatform;
using Adyen_Payment_Gateway_Demo_MVC.Configuration;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Adyen_Payment_Gateway_Demo_MVC.Application.Features.BalancePlatform
{
    public class AccountHolders
    {
        public async Task<dynamic> CreateAccountHolder(AccountHolderInfo account)
        {
            try
            {
                var client = new AdyenClientService().CreateBalancePlatformClient();
                var service = new AccountHoldersService(client);
                var response = service.CreateAccountHolder(account);
                return response;
            }
            catch (Adyen.HttpClient.HttpClientException ex)
            {
                return JObject.Parse(ex.ResponseBody);
            }
        }
    }
}