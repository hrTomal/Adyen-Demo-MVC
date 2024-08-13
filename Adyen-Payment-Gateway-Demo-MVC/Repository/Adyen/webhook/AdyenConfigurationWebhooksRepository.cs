using System;
using System.Threading.Tasks;
using Adyen_Payment_Gateway_Demo_MVC.Configuration;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Entity.Webhook;

namespace Adyen_Payment_Gateway_Demo_MVC.Repository.Adyen.webhook
{
    public class AdyenConfigurationWebhooksRepository
    {
        private readonly VoyagerDBContext _context;

        public AdyenConfigurationWebhooksRepository()
        {
            _context = new VoyagerDBContext();
        }

        public async Task AddAccountHolderWebhookLog(AdyenAccountHolderWebhook logData)
        {
            try
            {
                _context.AdyenAccountHolderWebhooks.Add(logData);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }

        }
        
        public async Task AddBalanceAccountWebhookLog(AdyenBalanceAccountWebhook logData)
        {
            try
            {
                _context.AdyenBalanceAccountWebhooks.Add(logData);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }

        }
    }
}