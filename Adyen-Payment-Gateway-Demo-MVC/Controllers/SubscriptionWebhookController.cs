using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Adyen.Model.Notification;
using Adyen.Util;
using Adyen_Payment_Gateway_Demo_MVC.Application.Features.AdyenWebhooks;
using Adyen_Payment_Gateway_Demo_MVC.Configuration;
using Newtonsoft.Json;

namespace Adyen_Payment_Gateway_Demo_MVC.Controllers
{
    public class SubscriptionWebhookController : Controller
    {
        private readonly HmacValidator _hmacValidator;
        private readonly string _hmacKey;

        public SubscriptionWebhookController()
        {
            _hmacValidator = new HmacValidator();
            _hmacKey = StaticVariablesConfig.GetAdyenHmacKey();
        }

        [HttpPost]
        [Route("subscriptionwebhook/notifications")]
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

                await ProcessAuthorisationNotificationAsync(container.NotificationItem);

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
            _ = new StandardWebhook().ReceiveStandardWebhook(notification); 
            if (notification.EventCode != "AUTHORISATION")
            {
                return Task.CompletedTask;
            }
            if (!notification.Success)
            {
                return Task.CompletedTask;
            }
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

            _ = new PaymentWebhooks().ReceiveRecurringContract(notification);

            //if (notification.AdditionalData.TryGetValue("recurring.recurringDetailReference", out string recurringDetailReference))
            //{
            //    Console.WriteLine("recurring.recurringDetailReference:" + recurringDetailReference);
            //    return Task.CompletedTask;
            //}

            //if (!notification.AdditionalData.TryGetValue("recurring.shopperReference", out string shopperReference))
            //{
            //    return Task.CompletedTask;
            //}

            //if (notification.AdditionalData.TryGetValue("recurringProcessingModel", out string recurringProcessingModel))
            //{
            //    return Task.CompletedTask;
            //}

            return Task.CompletedTask;
        }


    }
}