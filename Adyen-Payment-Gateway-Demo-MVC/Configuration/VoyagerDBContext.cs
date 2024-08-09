using System.Data.Entity;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Entity;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Entity.Webhook;

namespace Adyen_Payment_Gateway_Demo_MVC.Configuration
{
    public class VoyagerDBContext : DbContext
    {
        public VoyagerDBContext() : base("VoyagerConnectionString")
        {            
        }
        public DbSet<RecurringContractLog> RecurringContractLogs { get; set; }
        public DbSet<StandardHookReceivedJson> StandardHookReceivedJsons { get; set; }
    }
}