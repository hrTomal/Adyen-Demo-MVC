using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Adyen.Model.Management;
using Adyen.Model.Notification;
using Adyen.Util;
using Adyen_Payment_Gateway_Demo_MVC.Application.Features.AdyenWebhooks;
using Adyen_Payment_Gateway_Demo_MVC.Configuration;
using Newtonsoft.Json;

namespace Adyen_Payment_Gateway_Demo_MVC.Controllers
{
    public class StandardWebhookController : Controller
    {
        private readonly HmacValidator _hmacValidator;
        private readonly string _hmacKey;

        public StandardWebhookController()
        {
            _hmacValidator = new HmacValidator();
            _hmacKey = _hmacKey = StaticVariablesConfig.GetAdyenHmacKey();
        }

        [HttpPost]
        [Route("standardwebhook/notifications")]
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

                _ = new StandardWebhook().ReceiveStandardWebhook(container.NotificationItem);

                await ProcessAuthorisationNotificationAsync(container.NotificationItem);

                await ProcessRefusedNotificationAsync(container.NotificationItem);

                await ProcessRecurringContractNotificationAsync(container.NotificationItem);

                return new HttpStatusCodeResult(200);
            }
            catch (System.Exception)
            {
                return new HttpStatusCodeResult(500);
            }
        }

        private Task ProcessAuthorisationNotificationAsync(NotificationRequestItem notification)
        {
            if (notification.EventCode != "AUTHORISATION")
            {
                return Task.CompletedTask;
            }
            if (!notification.Success)
            {
                return Task.CompletedTask;
            }

            System.Diagnostics.Debug.WriteLine($"ProcessAuthorisationNotificationAsync: {notification.EventCode} - {notification.Success} - {notification.PspReference}");

            return Task.CompletedTask;
        }
        
        private Task ProcessRefusedNotificationAsync(NotificationRequestItem notification)
        {
            if (notification.EventCode != "AUTHORISATION")
            {
                return Task.CompletedTask;
            } 
            if (notification.Reason != "REFUSED")
            {
                return Task.CompletedTask;
            }

            System.Diagnostics.Debug.WriteLine($"ProcessRefusedNotificationAsync: {notification.EventCode} - {notification.Reason} - {notification.Success} - {notification.PspReference}");

            return Task.CompletedTask;
        }

        private Task ProcessRecurringContractNotificationAsync(NotificationRequestItem notification)
        {
            if (notification.EventCode != "RECURRING_CONTRACT")
            {
                return Task.CompletedTask;
            }

            if (!notification.Success)
            {
                return Task.CompletedTask;
            }
            //_ = new PaymentWebhooks().ReceiveRecurringContract(notification);

            System.Diagnostics.Debug.WriteLine($"ProcessRecurringContractNotificationAsync: {notification.EventCode} - {notification.Success} - {notification.PspReference}");

            return Task.CompletedTask;
        }

    }
}