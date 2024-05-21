using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Entity;

namespace Adyen_Payment_Gateway_Demo_MVC.Configuration
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext() : base("DefaultConnection")
        {
            
        }
        public DbSet<SuccessPaymentLog> SuccessPaymentLogs { get; set; }
    }
}