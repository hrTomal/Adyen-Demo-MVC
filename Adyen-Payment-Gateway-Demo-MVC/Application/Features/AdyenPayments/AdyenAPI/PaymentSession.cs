using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Adyen.Model.Checkout;
using Adyen_Payment_Gateway_Demo_MVC.Configuration;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Request;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Response;
using Newtonsoft.Json;

namespace Adyen_Payment_Gateway_Demo_MVC.Application.Features.AdyenPayments.AdyenAPI
{
    public class PaymentSession
    {
        public async Task<PaymentSessionResponse> GetPaymentSessionAsync(PaymentSessionRequest sessionRequest)
        {
            var client = new HttpClient();
            string apiUrl = "https://checkout-test.adyen.com/v71/sessions";
            try
			{
                sessionRequest.MerchantAccount = StaticVariablesConfig.GetAdyenMerchantCode();
                string jsonData = JsonConvert.SerializeObject(sessionRequest);
                var requestBody = new StringContent(jsonData, Encoding.UTF8, "application/json");
                string idempotencyKey = Guid.NewGuid().ToString();
                client.DefaultRequestHeaders.Add("Idempotency-Key", idempotencyKey);
                client.DefaultRequestHeaders.Add("x-api-key", StaticVariablesConfig.GetAdyenApiKey());
                HttpResponseMessage response = await client.PostAsync(apiUrl, requestBody);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var paymentSessionResponse = JsonConvert.DeserializeObject<PaymentSessionResponse>(responseBody);
                    return paymentSessionResponse;
                }
                else
                {
                    throw new HttpRequestException("Failed to post data. Status code: " + response.StatusCode);
                }
            }
			catch (System.Exception)
			{
				throw;
			}
        }
        
        
    }
}