using System.Threading.Tasks;
using System;
using System.Web.Mvc;
using Adyen.Model.Notification;
using Adyen.Util;
using Adyen_Payment_Gateway_Demo_MVC.Configuration;
using System.Linq;
using Newtonsoft.Json;

namespace Adyen_Payment_Gateway_Demo_MVC.Controllers
{
    public class CheckoutWebhookController : Controller
    {
        private readonly HmacValidator _hmacValidator;
        private readonly string _hmacKey;

        public CheckoutWebhookController()
        {
            _hmacValidator = new HmacValidator();
            _hmacKey = StaticVariablesConfig.GetAdyenHmacKey();
        }

        [HttpPost]
        [Route("checkoutwebhook/notifications")]
        public async Task<ActionResult> Webhooks()
        {

            try
            {
                string requestBody;
                using (var reader = new System.IO.StreamReader(Request.InputStream))
                {
                    requestBody = reader.ReadToEnd();
                }

                var deserializedRequest = JsonConvert.DeserializeObject<NotificationRequest>(requestBody);
                var container = deserializedRequest.NotificationItemContainers.FirstOrDefault();

                if (container == null)
                {
                    return new HttpStatusCodeResult(400, "Container has no notification items");
                }
         
                if (!_hmacValidator.IsValidHmac(container.NotificationItem, _hmacKey))
                {
                    return new HttpUnauthorizedResult();
                }

                await ProcessNotificationAsync(container.NotificationItem);

                return new HttpStatusCodeResult(202);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(500);
            }
        }

        private Task ProcessNotificationAsync(NotificationRequestItem notification)
        {
            if (!notification.Success)
            {
                //_logger.LogInformation($"Webhook unsuccessful: {notification.Reason} \n" +
                //    $"EventCode: {notification.EventCode} \n" +
                //    $"Merchant Reference ::{notification.MerchantReference} \n" +
                //    $"PSP Reference ::{notification.PspReference} \n");

                return Task.CompletedTask;
            }

            //_logger.LogInformation($"Received successful webhook with event::\n" +
            //                       $"Merchant Reference ::{notification.MerchantReference} \n" +
            //                       $"PSP Reference ::{notification.PspReference} \n");

            return Task.CompletedTask;
        }
    }
}