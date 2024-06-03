using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using Adyen.Model.BalancePlatform;
using Adyen.Model.LegalEntityManagement;
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
        [Route("CreateLegalEntityAndGenerateLink")]
        public async Task<ActionResult> CreateLegalEntityAndGenerateLink()
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

    }
}