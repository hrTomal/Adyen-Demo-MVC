using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Adyen.Model.Notification;
using Adyen_Payment_Gateway_Demo_MVC.Configuration;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Entity;

namespace Adyen_Payment_Gateway_Demo_MVC.Repository.Adyen
{
    public class RecurringContractLogRepository
    {
        private readonly VoyagerDBContext _context;

        public RecurringContractLogRepository()
        {
            _context = new VoyagerDBContext();
        }

        public async Task AddRecurringContractLog(RecurringContractLog logData)
        {
            try
            {
                _context.RecurringContractLogs.Add(logData);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
            
        }

        public List<RecurringContractLog> GetRecurringContractLogs()
        {
            return _context.RecurringContractLogs.ToList();
        }

    }
}