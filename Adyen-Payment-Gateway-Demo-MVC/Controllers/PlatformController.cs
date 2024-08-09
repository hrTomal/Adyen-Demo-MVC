using System;
using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using Adyen.Model.BalancePlatform;
using Adyen.Model.LegalEntityManagement;
using Adyen.Model.Management;
using Adyen_Payment_Gateway_Demo_MVC.Application.Features.BalancePlatform;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Platform;
using Newtonsoft.Json;

namespace Adyen_Payment_Gateway_Demo_MVC.Controllers
{
    [RoutePrefix("api/platform")]
    public class PlatformController : Controller
    {
        [HttpGet]
        [Route("GetBalancePlatform/{platformId}")]
        public ActionResult GetBalancePlatform(string platformId)
        {
            var response = new GetBalancePlatform().BalancePlatform(platformId);
            return Content(JsonConvert.SerializeObject(response), "application/json");
        }

        [HttpGet]
        [Route("GetLegalEntity/{legalEntityId}")]
        public async Task<ActionResult> GetLegalEntity(string legalEntityId)
        {
            var response = await new LegalEntities().GetLegalEntity(legalEntityId);
            return Content(JsonConvert.SerializeObject(response), "application/json");
        }
        
        [HttpPost]
        [Route("CreateLegalEntity")]
        public async Task<ActionResult> CreateLegalEntity()
        {
            string requestBody;
            using (var reader = new StreamReader(Request.InputStream))
            {
                requestBody = await reader.ReadToEndAsync();
            }
            var request = JsonConvert.DeserializeObject<LegalEntityInfoRequiredType>(requestBody);

            var response = await new LegalEntities().AddLegalEntity(request);
            return Content(JsonConvert.SerializeObject(response), "application/json");
        }
        
        [HttpPost]
        [Route("AddAccountHolder")]
        public async Task<ActionResult> AddAccountHolder()
        {
            string requestBody;
            using (var reader = new StreamReader(Request.InputStream))
            {
                requestBody = await reader.ReadToEndAsync();
            }
            var request = JsonConvert.DeserializeObject<AccountHolderInfo>(requestBody);

            var response = await new AccountHolders().CreateAccountHolder(request);
            return Content(JsonConvert.SerializeObject(response), "application/json");
        }

        [HttpPost]
        [Route("AddBalanceAccount")]
        public async Task<ActionResult> AddBalanceAccount()
        {
            string requestBody;
            using (var reader = new StreamReader(Request.InputStream))
            {
                requestBody = await reader.ReadToEndAsync();
            }
            var request = JsonConvert.DeserializeObject<BalanceAccountInfo>(requestBody);

            var response = await new BalanceAccounts().CreateBalanceAccount(request);
            return Content(JsonConvert.SerializeObject(response), "application/json");
        }

        [HttpPost]
        [Route("CreateBusinessLine")]
        public async Task<ActionResult> CreateBusinessLine()
        {
            string requestBody;
            using (var reader = new StreamReader(Request.InputStream))
            {
                requestBody = await reader.ReadToEndAsync();
            }
            var request = JsonConvert.DeserializeObject<BusinessLineInfo>(requestBody);

            var response = await new Application.Features.BalancePlatform.BusinessLines().Create(request);
            return Content(JsonConvert.SerializeObject(response), "application/json");
        }

        [HttpPost]
        [Route("CreateStore")]
        public async Task<ActionResult> CreateStore()
        {
            string requestBody;
            using (var reader = new StreamReader(Request.InputStream))
            {
                requestBody = await reader.ReadToEndAsync();
            }
            var request = JsonConvert.DeserializeObject<StoreCreationWithMerchantCodeRequest>(requestBody);

            var response = await new Stores().Create(request);
            return Content(JsonConvert.SerializeObject(response), "application/json");
        }

        [HttpPost]
        [Route("CreatePaymentMethod")]
        public async Task<ActionResult> CreatePaymentMethod()
        {
            string requestBody;
            using (var reader = new StreamReader(Request.InputStream))
            {
                requestBody = await reader.ReadToEndAsync();
            }
            var request = JsonConvert.DeserializeObject<PaymentMethodSetupInfo>(requestBody);

            var response = await new PaymentMethodSettings().Create(request);
            return Content(JsonConvert.SerializeObject(response), "application/json");
        }

        [HttpPost]
        [Route("GenerateOnboardingLink")]
        public async Task<ActionResult> GenerateOnboardingLink()
        {
            string requestBody;
            using (var reader = new StreamReader(Request.InputStream))
            {
                requestBody = await reader.ReadToEndAsync();
            }
            var request = JsonConvert.DeserializeObject<OnBoardingLinkInfoWithId>(requestBody);

            var response = await new LegalEntities().GenerateOnboardingLink(request);
            return Content(JsonConvert.SerializeObject(response), "application/json");
        }      
        
        
        [HttpGet]
        [Route("GetBusinessLine/{businessLineId}")]
        public async Task<ActionResult> GetBusinessLine(string businessLineId)
        {
            var response = await new Application.Features.BalancePlatform.BusinessLines().Get(businessLineId);
            return Content(JsonConvert.SerializeObject(response), "application/json");
        }
        
        [HttpGet]
        [Route("GetStore/{storeId}")]
        public async Task<ActionResult> GetStore(string storeId)
        {
            var response = await new Stores().Get(storeId);
            return Content(JsonConvert.SerializeObject(response), "application/json");
        }
        
        [HttpGet]
        [Route("GetPaymentMethod/{storeId}")]
        public async Task<ActionResult> GetPaymentMethod(string storeId)
        {
            var response = await new PaymentMethodSettings().Get(storeId);
            return Content(JsonConvert.SerializeObject(response), "application/json");
        }
        
        
        [HttpPost]
        [Route("CreateAccountAndGenerateLink")]
        public async Task<ActionResult> CreateAccountAndGenerateLink()
        {
            string requestBody;
            using (var reader = new StreamReader(Request.InputStream))
            {
                requestBody = await reader.ReadToEndAsync();
            }
            var request = JsonConvert.DeserializeObject<CustomAccountCreationDetails>(requestBody);
            var response = await new CustomAccountCreation().CreateAccount(request);
            return Content(JsonConvert.SerializeObject(response), "application/json");
        }

        [HttpPost]
        public async Task<ActionResult> CreateAccountAndGenerateLinkAndRedirect(string jsonRequestBody)
        {
            try
            {
                var request = JsonConvert.DeserializeObject<CustomAccountCreationDetails>(jsonRequestBody);
                var response = await new CustomAccountCreation().CreateAccount(request);
                var test2 = response.Url;

                return new RedirectResult(test2);
            }
            catch (System.Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("~/Views/Payment/PaymentIndex.cshtml");
                //return Content(JsonConvert.SerializeObject(ex.Message), "application/json");
            }
        }

        [HttpPost]
        [Route("SplitRefund")]
        public async Task<ActionResult> SplitRefund()
        {
            string requestBody;
            using (var reader = new StreamReader(Request.InputStream))
            {
                requestBody = await reader.ReadToEndAsync();
            }
            //var request = JsonConvert.DeserializeObject<CustomAccountCreationDetails>(requestBody);
            //var response = await new CustomAccountCreation().CreateAccount(request);
            //return Content(JsonConvert.SerializeObject(response), "application/json");

            return default;
        }

    }
}