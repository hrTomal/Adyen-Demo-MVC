using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Adyen.Model.Notification;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Entity;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Entity.Webhook;
using Adyen_Payment_Gateway_Demo_MVC.Repository.Adyen;
using Adyen_Payment_Gateway_Demo_MVC.Repository.Adyen.webhook;
using Newtonsoft.Json;

namespace Adyen_Payment_Gateway_Demo_MVC.Application.Features.AdyenWebhooks
{
    public class StandardWebhook
    {
        public async Task ReceiveStandardWebhook(NotificationRequestItem notification)
        {
            var notificationJson = JsonConvert.SerializeObject(notification);
            var data = new StandardHookReceivedJson
            {
                PspReference = notification.PspReference,
                RequestJson = notificationJson,
            };
            await new StandardWebhookRepository().AddWebhookRequestJson(data);
        }
    }
}