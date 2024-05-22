using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using Adyen.Model.Checkout;
using Adyen_Payment_Gateway_Demo_MVC.Application.Features.AdyenPayments.AdyenLibrary;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.LibraryRequests;
using Newtonsoft.Json;

namespace Adyen_Payment_Gateway_Demo_MVC.Controllers
{
    [RoutePrefix("api/payment")]
    public class PaymentController : Controller
    {
        public ActionResult PaymentIndex()
        {
            ViewBag.Message = "Test page.";
            return View();
        }

        [HttpPost]
        [Route("PaymentMethods")]
        public async Task<ActionResult> PaymentMethods(PaymentMethodsReq request)
        {            
            var response = await new GetMerchantPaymentMethods().GetPaymentMethods(request);
            return Content(JsonConvert.SerializeObject(response), "application/json");            
        }
        
        [HttpPost]
        [Route("PaymentMethods_Test")]
        public async Task<ActionResult> PaymentMethods_Test(PaymentMethodsReq request)
        {            
            var response = await new GetMerchantPaymentMethods().GetPaymentMethods_Test(request);
            return Content(JsonConvert.SerializeObject(response), "application/json");            
        }

        [HttpPost]
        [Route("Payments")]
        public async Task<ActionResult> Payments()
        {
            string requestBody;
            using (var reader = new StreamReader(Request.InputStream))
            {
                requestBody = await reader.ReadToEndAsync();
            }
            var request = JsonConvert.DeserializeObject<PaymentRequest>(requestBody);

            var response = new InitiatePayment().InitiateAPayment(request);
            return Content(JsonConvert.SerializeObject(response), "application/json");
        }
        
        //[HttpPost]
        //[Route("InitiatePayment_test")]
        //public async Task<ActionResult> InitiatePayment_test(PaymentRequest request)
        //{
        //    var response = await new InitiatePayment().InitiateAPayment(request);
        //    return Json(response, JsonRequestBehavior.AllowGet);
        //} 

        [HttpPost]
        [Route("SubmitAdditionalDetails")]
        public async Task<ActionResult> SubmitAdditionalDetails()
        {
            string requestBody;
            using (var reader = new StreamReader(Request.InputStream))
            {
                requestBody = await reader.ReadToEndAsync();
            }
            var request = JsonConvert.DeserializeObject<PaymentDetailsRequest>(requestBody);

            var response = await new SubmitAdditionalPaymentDetails().SubmitAdditionalDetails(request);
            return Content(JsonConvert.SerializeObject(response), "application/json");
        }
        
        [HttpGet]
        [Route("GetSuccessPaymentLogs")]
        public ActionResult GetSuccessPaymentLogs()
        {
            var response = new GetSuccessPaymentLogs().GetSuccessPaymentLogList();
            return Content(JsonConvert.SerializeObject(response), "application/json");
        }
    }
}