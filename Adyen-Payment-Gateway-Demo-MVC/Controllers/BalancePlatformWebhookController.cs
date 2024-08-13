using System.ComponentModel;
using System.Threading.Tasks;
using System.Web.Mvc;
using Adyen.Util;
using Adyen.Webhooks;
using Adyen_Payment_Gateway_Demo_MVC.Application.Features.AdyenWebhooks;
using Adyen_Payment_Gateway_Demo_MVC.Configuration;

namespace Adyen_Payment_Gateway_Demo_MVC.Controllers
{
    public class BalancePlatformWebhookController : Controller
    {
        private readonly HmacValidator _hmacValidator;
        private readonly string _hmacKey;
        public BalancePlatformWebhookController()
        {
            _hmacValidator = new HmacValidator();
            _hmacKey = StaticVariablesConfig.GetAdyenHmacKey();
        }

        [HttpPost]
        [Route("balanceplatformwebhook/notifications")]
        public async Task<ActionResult> Webhooks()
        {
            try
            {
                string requestBody;
                using (var reader = new System.IO.StreamReader(Request.InputStream))
                {
                    requestBody = reader.ReadToEnd();
                }

                //if (!_hmacValidator.IsValidHmac(container.NotificationItem, _hmacKey))
                //{
                //    return new HttpUnauthorizedResult();
                //}

                _ = new ReceiveBalancePlatformWebhooks().ReceiveBalancePlatformWebhook(requestBody);

                return new HttpStatusCodeResult(200);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}