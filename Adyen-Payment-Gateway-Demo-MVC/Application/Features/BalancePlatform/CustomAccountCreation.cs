using Adyen.Model.BalancePlatform;
using Adyen.Model.LegalEntityManagement;
using Adyen.Service.BalancePlatform;
using Adyen.Service.LegalEntityManagement;
using Adyen_Payment_Gateway_Demo_MVC.Configuration;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Platform;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Adyen_Payment_Gateway_Demo_MVC.Application.Features.BalancePlatform
{
    public class CustomAccountCreation
    {
        public async Task<dynamic> CreateAccount(CustomAccountCreationDetails request)
        {
            try
            {
                var legalEntityCreationResponse = await AddLegalEntity(request.legalEntityInfo);
                if(legalEntityCreationResponse != null && legalEntityCreationResponse.Id != null)
                {
                    var accountHolderInfo = new AccountHolderInfo() { LegalEntityId = legalEntityCreationResponse.Id };

                    var accHolderCreateResponse = await CreateAccountHolder(accountHolderInfo);
                    if (accHolderCreateResponse != null && accHolderCreateResponse.Id != null)
                    {
                        var onboardingLinkInfo = new OnboardingLinkInfo() { RedirectUrl = request.redirectUrl };
                        var linkGenerateResponse = await GenerateOnboardingLink(accHolderCreateResponse.LegalEntityId, onboardingLinkInfo);
                        return linkGenerateResponse;
                    }
                    return accHolderCreateResponse;
                }
                return legalEntityCreationResponse;
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<dynamic> AddLegalEntity(LegalEntityInfoRequiredType legalEntityInfoRequiredType)
        {
            var client = new AdyenClientService().CreateLegalEnityClient();
            try
            {
                var service = new LegalEntitiesService(client);
                var response = service.CreateLegalEntity(legalEntityInfoRequiredType);
                return response;
            }
            catch (Adyen.HttpClient.HttpClientException ex)
            {
                return JObject.Parse(ex.ResponseBody);
            }
        }
        private async Task<dynamic> CreateAccountHolder(AccountHolderInfo account)
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

        public async Task<dynamic> GenerateOnboardingLink(string legalEntityId, OnboardingLinkInfo onboardingLinkInfo)
        {
            var client = new AdyenClientService().CreateLegalEnityClient();
            try
            {
                var service = new HostedOnboardingService(client);
                var response = service.GetLinkToAdyenhostedOnboardingPage(legalEntityId, onboardingLinkInfo);
                return response;
            }
            catch (Adyen.HttpClient.HttpClientException ex)
            {
                return JObject.Parse(ex.ResponseBody);
            }
        }
    }
}