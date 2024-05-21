using Adyen_Payment_Gateway_Demo_MVC.Configuration;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Request;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using Adyen.Model.Checkout;
using System.Net.Http.Headers;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Common;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Response;
using Newtonsoft.Json.Linq;

namespace Adyen_Payment_Gateway_Demo_MVC.Application.Features.AdyenPayments.AdyenAPI
{
    public class Checkout
    {
        private readonly string paymentApiUrl = "https://checkout-test.adyen.com/v71/payments";
        private readonly string baseUrl = "https://checkout-test.adyen.com/v71";
        public async Task<PaymentMethodsResponse> PaymentMethodsByMerchantAccount()
        {
            try
            {
                var request = new Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Request.PaymentMethodsRequest
                {
                    merchantAccount = StaticVariablesConfig.GetAdyenMerchantCode()
                };
                string jsonData = JsonConvert.SerializeObject(request);
                var requestBody = new StringContent(jsonData, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    var paymentMethodsApiUrl = baseUrl + "/paymentMethods";
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("x-api-key", StaticVariablesConfig.GetAdyenApiKey());
                    HttpResponseMessage response = await client.PostAsync(paymentMethodsApiUrl, requestBody);
                    string responseBody = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {                        
                        var deserializedResponse = JsonConvert.DeserializeObject<PaymentMethodsResponse>(responseBody);
                        return deserializedResponse;
                    }
                    else
                    {
                        throw new HttpRequestException("Failed to post data. Status code: " + response.StatusCode);
                    }
                }                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<dynamic> Payments(PaymentsRequest request)
        {
            var client = new HttpClient();
            try
            {
                request.MerchantAccount = StaticVariablesConfig.GetAdyenMerchantCode();
                string jsonData = JsonConvert.SerializeObject(request);
                var requestBody = new StringContent(jsonData, Encoding.UTF8, "application/json");
                string idempotencyKey = Guid.NewGuid().ToString();
                client.DefaultRequestHeaders.Add("Idempotency-Key", idempotencyKey);
                client.DefaultRequestHeaders.Add("x-api-key", StaticVariablesConfig.GetAdyenApiKey());
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsync(paymentApiUrl, requestBody);
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var deserializedResponse = JsonConvert.DeserializeObject<PaymentResponse>(responseBody);
                    return deserializedResponse;
                }
                else
                {
                    throw new HttpRequestException("Failed to post data. Status code: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        

        public async Task<dynamic> SubmitPaymentsDetails(PaymentDetailsSubmitRequest request)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(request);
                var requestBody = new StringContent(jsonData, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    var apiUrl = baseUrl + "/payments/details";
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("x-api-key", StaticVariablesConfig.GetAdyenApiKey());

                    HttpResponseMessage response = await client.PostAsync(apiUrl, requestBody);
                    string responseBody = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<PaymentDetailsSubmitResponse>(responseBody);
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

        public async Task<dynamic> CardDetails(CheckCardDetailsRequest request)
        {
            try
            {
                request.MerchantAccount = StaticVariablesConfig.GetAdyenMerchantCode();
                string jsonData = JsonConvert.SerializeObject(request);
                var requestBody = new StringContent(jsonData, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    var apiUrl = baseUrl + "/cardDetails";
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("x-api-key", StaticVariablesConfig.GetAdyenApiKey());

                    HttpResponseMessage response = await client.PostAsync(apiUrl, requestBody);
                    string responseBody = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<CheckCardDetailsResponse>(responseBody);
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

        public async Task<dynamic> PaymentMethodsByAmountAndCountry(PaymentMethodsByAmountCountryReq request)
        {
            try
            {
                request.MerchantAccount = StaticVariablesConfig.GetAdyenMerchantCode();
                string jsonData = JsonConvert.SerializeObject(request);
                var requestBody = new StringContent(jsonData, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    var apiUrl = baseUrl + "/paymentMethods";
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("x-api-key", StaticVariablesConfig.GetAdyenApiKey());

                    HttpResponseMessage response = await client.PostAsync(apiUrl, requestBody);
                    string responseBody = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<PaymentMethodResponse>(responseBody);
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

        public async Task<dynamic> SplitPayments(Adyen.Model.Checkout.PaymentRequest request)
        {
            var client = new HttpClient();
            try
            {
                request.MerchantAccount = StaticVariablesConfig.GetAdyenMerchantCode();
                string jsonData = JsonConvert.SerializeObject(request);
                var requestBody = new StringContent(jsonData, Encoding.UTF8, "application/json");
                string idempotencyKey = Guid.NewGuid().ToString();
                client.DefaultRequestHeaders.Add("Idempotency-Key", idempotencyKey);
                client.DefaultRequestHeaders.Add("x-api-key", StaticVariablesConfig.GetAdyenApiKey());
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsync(paymentApiUrl, requestBody);
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var deserializedResponse = JsonConvert.DeserializeObject<PaymentResponse>(responseBody);
                    return deserializedResponse;
                }
                else
                {
                    return JObject.Parse(responseBody);
                    //throw new HttpRequestException("Failed to post data. Status code: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}