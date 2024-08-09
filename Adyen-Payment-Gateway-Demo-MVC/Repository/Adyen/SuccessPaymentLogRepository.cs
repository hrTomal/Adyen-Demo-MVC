//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Entity;

//namespace Adyen_Payment_Gateway_Demo_MVC.Repository.Adyen
//{
//    public class SuccessPaymentLogRepository
//    {
//        private readonly DefaultDbContext _context;

//        public SuccessPaymentLogRepository()
//        {
//            _context = new DefaultDbContext();
//        }

//        public async Task AddSuccessPaymentLog(SuccessPaymentLog log)
//        {
//            try
//            {
//                _context.SuccessPaymentLogs.Add(log);
//                _context.SaveChangesAsync();
//            }
//            catch (Exception ex)
//            {
//                throw;
//            }
            
//        }

//        public List<SuccessPaymentLog> GetSuccessPaymentLogs()
//        {
//            return _context.SuccessPaymentLogs.ToList();
//        }

//        public async Task UpdateRefundAmountSuccessPaymentLog(SuccessPaymentLog updatedLog)
//        {
//            var existingLog = _context.SuccessPaymentLogs.FirstOrDefault(log => log.pspReference == updatedLog.pspReference);
//            if (existingLog != null)
//            {

//                existingLog.refundAmount = existingLog.refundAmount + updatedLog.refundAmount;
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}