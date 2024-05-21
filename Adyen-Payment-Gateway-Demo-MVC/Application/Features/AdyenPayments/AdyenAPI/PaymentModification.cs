using Adyen_Payment_Gateway_Demo_MVC.Configuration;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Common;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Request;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Response;

namespace Adyen_Payment_Gateway_Demo_MVC.Application.Features.AdyenPayments.AdyenAPI
{
    public class PaymentModification
    {
        public async Task<dynamic> RefundPayment(RefundRequest request)
        {
            try
            {
                var baseUrl = StaticVariablesConfig.GetAdyenBaseUrlForTest();
                request.MerchantAccount = StaticVariablesConfig.GetAdyenMerchantCode();
                string jsonData = JsonConvert.SerializeObject(request);
                var requestBody = new StringContent(jsonData, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    var apiUrl = baseUrl + "/payments/" + request.Reference + "/refunds";
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("x-api-key", StaticVariablesConfig.GetAdyenApiKey());

                    HttpResponseMessage response = await client.PostAsync(apiUrl, requestBody);
                    string responseBody = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<RefundResponse>(responseBody);
                    }
                    else
                    {
                        return JsonConvert.DeserializeObject<ApiCommonError>(responseBody);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}