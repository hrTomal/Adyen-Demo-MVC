using System;
using System.Threading.Tasks;
using Adyen.Model.Notification;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Entity;
using Adyen_Payment_Gateway_Demo_MVC.Repository.Adyen;
using Newtonsoft.Json;

namespace Adyen_Payment_Gateway_Demo_MVC.Application.Features.AdyenWebhooks
{
    public class PaymentWebhooks
    {
        public async Task ReceiveRecurringContract(NotificationRequestItem notification)
        {
            var requestItem = JsonConvert.SerializeObject(notification);
            string recurringDetailReferenceValue = null;
            string shopperReferenceValue = null;

            if (notification.AdditionalData.TryGetValue("recurring.recurringDetailReference", out string recurringDetailReference))
            {
                recurringDetailReferenceValue = recurringDetailReference;
            }

            if (notification.AdditionalData.TryGetValue("recurring.shopperReference", out string shopperReference))
            {
                shopperReferenceValue = shopperReference;
            }

            var logData = new RecurringContractLog
            {
                PspReference = notification.PspReference,
                UpdatedOn = DateTime.Now,
                Request = requestItem,
                RecurringDetailReference = recurringDetailReferenceValue,
                MerchantAccountCode = notification.MerchantAccountCode,
                Currency = notification.Amount.Currency,
                ShopperReference = shopperReferenceValue,
                EventDate = notification.EventDate


            };
            await new RecurringContractLogRepository().AddRecurringContractLog(logData);
        }

    }
}