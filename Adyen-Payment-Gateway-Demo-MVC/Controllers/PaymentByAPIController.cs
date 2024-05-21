using System.Threading.Tasks;
using Adyen_Payment_Gateway_Demo_MVC.Application.Features.AdyenPayments.AdyenAPI;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Request;
using System;
using System.Web.Mvc;
using Adyen.Model.Checkout;
using Newtonsoft.Json;
using System.IO;

namespace Adyen_Payment_Gateway_Demo_MVC.Controllers
{
    
    [RoutePrefix("api/paymentbyapi")]
    
    public class PaymentByAPIController : Controller
    {
        [HttpPost]
        [Route("PaymentSession")]
        public async Task<ActionResult> PaymentSession(PaymentSessionRequest request)
        {
            var response = await new PaymentSession().GetPaymentSessionAsync(request);
            return Content(JsonConvert.SerializeObject(response), "application/json");
        }
        
        [HttpGet]
        [Route("PaymentMethods")]
        public async Task<ActionResult> PaymentMethods()
        {
            var response = await new Checkout().PaymentMethodsByMerchantAccount();
            return Content(JsonConvert.SerializeObject(response), "application/json");
        }

        [HttpPost]
        [Route("PaymentMethodsByAmountAndCountry")]
        public async Task<ActionResult> PaymentMethodsByAmountAndCountry(PaymentMethodsByAmountCountryReq request)
        {
            var response = await new Checkout().PaymentMethodsByAmountAndCountry(request);
            return Content(JsonConvert.SerializeObject(response), "application/json");
        }

        [HttpPost]
        [Route("Payments")]
        public async Task<ActionResult> Payments(PaymentsRequest request)
        {
            var response = await new Checkout().Payments(request);
            return Content(JsonConvert.SerializeObject(response), "application/json");
        }
        
        [HttpPost]
        [Route("SubmitPaymentsDetails")]
        public async Task<ActionResult> SubmitPaymentsDetails(PaymentDetailsSubmitRequest request)
        {
            var response = await new Checkout().SubmitPaymentsDetails(request);
            return Content(JsonConvert.SerializeObject(response), "application/json");
        }
        
        [HttpPost]
        [Route("CardDetails")]
        public async Task<ActionResult> CardDetails(CheckCardDetailsRequest request)
        {
            var response = await new Checkout().CardDetails(request);
            return Content(JsonConvert.SerializeObject(response), "application/json");
        }
        
        [HttpPost]
        [Route("RefundPayment")]
        public async Task<ActionResult> RefundPayment(RefundRequest request)
        {
            var response = await new PaymentModification().RefundPayment(request);
            return Content(JsonConvert.SerializeObject(response), "application/json");
        }

        [HttpPost]
        [Route("SplitPayment")]
        public async Task<ActionResult> SplitPayment()
        {
            string requestBody;
            using (var reader = new StreamReader(Request.InputStream))
            {
                requestBody = await reader.ReadToEndAsync();
            }
            var request = JsonConvert.DeserializeObject<Adyen.Model.Checkout.PaymentRequest>(requestBody);

            var response = await new Checkout().SplitPayments(request);
            return Content(JsonConvert.SerializeObject(response), "application/json");
        }
    }
}
