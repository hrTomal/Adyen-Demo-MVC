using System;
using System.Threading.Tasks;
using Adyen.Webhooks;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Entity.Webhook;
using Adyen_Payment_Gateway_Demo_MVC.Repository.Adyen.webhook;
using Newtonsoft.Json;

namespace Adyen_Payment_Gateway_Demo_MVC.Application.Features.AdyenWebhooks
{
    public class ReceiveBalancePlatformWebhooks
    {
        private readonly BalancePlatformWebhookHandler _webhookHandler;
        public ReceiveBalancePlatformWebhooks()
        {
            _webhookHandler = new BalancePlatformWebhookHandler();
        }

        internal async Task ReceiveBalancePlatformWebhook(string requestBody)
        {
            try
            {
                dynamic webhook = _webhookHandler.GetGenericBalancePlatformWebhook(requestBody);
                System.Diagnostics.Debug.WriteLine($"{webhook.GetType().ToString()}");
                System.Diagnostics.Debug.WriteLine($"{webhook.Type}");

                switch (webhook.GetType().ToString())
                {
                    case "Adyen.Model.TransferWebhooks.TransferNotificationRequest":
                        HandleTransferNotification(webhook);
                        break;

                    case "Adyen.Model.ConfigurationWebhooks.PaymentNotificationRequest":
                        HandlePaymentNotification(webhook);
                        break;

                    case "Adyen.Model.ConfigurationWebhooks.AccountHolderNotificationRequest":
                        HandleAccountHolderNotification(webhook);
                        break;
                    
                    case "Adyen.Model.ConfigurationWebhooks.BalanceAccountNotificationRequest":
                        HandleBalanceAccountNotification(webhook);
                        break;

                    default:
                        System.Diagnostics.Debug.WriteLine("Unknown or unhandled webhook type");
                        break;
                }

                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
            
        }

        private void HandleAccountHolderNotification(dynamic webhook)
        {
            try
            {
                var configurationRequest = new AdyenAccountHolderWebhook
                {
                    accountHolderId = webhook.Data.AccountHolder.Id,
                    legalEntityId = webhook.Data.AccountHolder.LegalEntityId,
                    createdOn = DateTime.Now,
                    type = webhook.Type.ToString(),
                    requestJson = JsonConvert.SerializeObject(webhook),
                };

                _ = new AdyenConfigurationWebhooksRepository().AddAccountHolderWebhookLog(configurationRequest);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"HandleConfigurationNotification Error: {ex.Message}");
                throw;
            }
            
        }
        private void HandleBalanceAccountNotification(dynamic webhook)
        {
            try
            {
                var req = new AdyenBalanceAccountWebhook
                {
                    balanceAccountId = webhook.Data.BalanceAccount.Id,
                    accountHolderId = webhook.Data.BalanceAccount.AccountHolderId,                   
                    createdOn = DateTime.Now,
                    type = webhook.Type.ToString(),
                    requestJson = JsonConvert.SerializeObject(webhook),
                };

                _ = new AdyenConfigurationWebhooksRepository().AddBalanceAccountWebhookLog(req);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"HandleConfigurationNotification Error: {ex.Message}");
                throw;
            }
            
        }

        private void HandlePaymentNotification(dynamic webhook)
        {
            System.Diagnostics.Debug.WriteLine("Handling Transfer Notification");
            System.Diagnostics.Debug.WriteLine($"{webhook.Type}");

            throw new NotImplementedException();
        }

        private void HandleTransferNotification(dynamic webhook)
        {
            System.Diagnostics.Debug.WriteLine("Handling Payment Notification");
            System.Diagnostics.Debug.WriteLine($"{webhook.Type}");

            throw new NotImplementedException();
        }
    }
}