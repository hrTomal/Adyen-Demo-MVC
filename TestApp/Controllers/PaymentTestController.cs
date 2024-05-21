using System;
using System.Web.Http;
using Adyen;
using Adyen.Model;
using Adyen.Model.Checkout;
using Adyen.Service.Checkout;

namespace TestApp.Controllers
{
    [RoutePrefix("api/checkout")]
    public class PaymentTestController : ApiController
    {
        [HttpPost]
        [Route("Payments")]
        public dynamic Payments(PaymentRequest request)
        {
            try
            {
                var paymentRequest = new PaymentRequest
                {
                    Amount = request.Amount,
                    Reference = request.Reference,
                    MerchantAccount = "JustGoBVECOM",
                    PaymentMethod = request.PaymentMethod,
                    ReturnUrl = request.ReturnUrl
                };

                var apiKey = "AQEqhmfxK4LNaBdDw0m/n3Q5qf3VYp5eGbRFelMqJMHglBExqsyYeF3a/rsWEMFdWw2+5HzctViMSCJMYAc=-ddJoi9u5LKrcPZcv8ZUb9/a1Uc82BiYBIUKchos81/8=-~g;$sxtLS,6k9y5H";

                var config = new Config()
                {
                    XApiKey = apiKey,
                    Environment = Adyen.Model.Environment.Test
                };               

                var client = new Client(config);

                var service = new PaymentsService(client);
                var response = service.Payments(paymentRequest, new RequestOptions { IdempotencyKey = Guid.NewGuid().ToString() });

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while getting payment methods: {ex.Message}");
                throw;
            }
        }
    }
}
