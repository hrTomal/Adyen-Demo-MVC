using System.Threading.Tasks;
using System.Web.Mvc;
using Adyen.Webhooks;

namespace Adyen_Payment_Gateway_Demo_MVC.Controllers
{
    public class BalancePlatformWebhookController : Controller
    {
        private readonly BalancePlatformWebhookHandler _webhookHandler;
        public BalancePlatformWebhookController()
        {
            _webhookHandler = new BalancePlatformWebhookHandler();

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
                dynamic webhook = _webhookHandler.GetGenericBalancePlatformWebhook(requestBody);

                System.Diagnostics.Debug.WriteLine(webhook);

                return new HttpStatusCodeResult(200);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}