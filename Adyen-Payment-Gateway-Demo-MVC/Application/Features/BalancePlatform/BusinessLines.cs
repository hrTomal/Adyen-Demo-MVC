using Adyen.Model.LegalEntityManagement;
using Adyen.Service.LegalEntityManagement;
using Adyen_Payment_Gateway_Demo_MVC.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace Adyen_Payment_Gateway_Demo_MVC.Application.Features.BalancePlatform
{
    public class BusinessLines
    {
        public async Task<dynamic> Create(BusinessLineInfo businessLineInfo)
        {
            var client = new AdyenClientService().CreateLegalEnityClient();
            try
            {
                var service = new BusinessLinesService(client);
                var response = service.CreateBusinessLine(businessLineInfo);
                return response;
            }
            catch (Adyen.HttpClient.HttpClientException ex)
            {
                return JObject.Parse(ex.ResponseBody);
            }
        }

        internal async Task<dynamic> Get(string businessLineId)
        {
            var client = new AdyenClientService().CreateLegalEnityClient();
            try
            {
                var service = new BusinessLinesService(client);
                var response = service.GetBusinessLine(businessLineId);
                return response;
            }
            catch (Adyen.HttpClient.HttpClientException ex)
            {
                return JObject.Parse(ex.ResponseBody);
            }
        }
    }
}