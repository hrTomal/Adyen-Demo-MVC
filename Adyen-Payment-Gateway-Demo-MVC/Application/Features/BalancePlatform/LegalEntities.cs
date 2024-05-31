using System;
using System.Threading.Tasks;
using Adyen.Model.LegalEntityManagement;
using Adyen.Service.LegalEntityManagement;
using Adyen_Payment_Gateway_Demo_MVC.Configuration;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Platform;
using Newtonsoft.Json.Linq;

namespace Adyen_Payment_Gateway_Demo_MVC.Application.Features.BalancePlatform
{
    public class LegalEntities
    {
        internal async Task<dynamic> GetLegalEntity(string legalEntityId)
        {
            var client = new AdyenClientService().CreateLegalEnityClient();
            try
            {
                var service = new LegalEntitiesService(client);
                var response = service.GetLegalEntity(legalEntityId);
                return response;
            }
            catch (Adyen.HttpClient.HttpClientException ex)
            {
                return JObject.Parse(ex.ResponseBody);
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
        
        public async Task<dynamic> GenerateOnboardingLink(OnBoardingLinkInfoWithId request)
        {
            var client = new AdyenClientService().CreateLegalEnityClient();
            try
            {
                var service = new HostedOnboardingService(client);
                var response = service.GetLinkToAdyenhostedOnboardingPage(request.LegalEntityId, request.OnboardingLinkInfo);
                return response;
            }
            catch (Adyen.HttpClient.HttpClientException ex)
            {
                return JObject.Parse(ex.ResponseBody);
            }
        }

        
    }
}