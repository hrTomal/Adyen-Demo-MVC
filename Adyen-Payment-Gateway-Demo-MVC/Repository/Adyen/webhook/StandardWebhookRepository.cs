using System.Threading.Tasks;
using System;
using Adyen_Payment_Gateway_Demo_MVC.Configuration;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Entity.Webhook;

namespace Adyen_Payment_Gateway_Demo_MVC.Repository.Adyen.webhook
{
    public class StandardWebhookRepository
    {
        private readonly VoyagerDBContext _context;

        public StandardWebhookRepository()
        {
            _context = new VoyagerDBContext();
        }

        public async Task AddWebhookRequestJson(StandardHookReceivedJson data)
        {
            try
            {
                _context.StandardHookReceivedJsons.Add(data);
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