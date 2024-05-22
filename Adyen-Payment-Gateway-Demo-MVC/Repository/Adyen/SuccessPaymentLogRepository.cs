﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Adyen_Payment_Gateway_Demo_MVC.Configuration;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Entity;

namespace Adyen_Payment_Gateway_Demo_MVC.Repository.Adyen
{
    public class SuccessPaymentLogRepository
    {
        private readonly DefaultDbContext _context;

        public SuccessPaymentLogRepository()
        {
            _context = new DefaultDbContext();
        }

        public async void AddSuccessPaymentLog(SuccessPaymentLog log)
        {
            _context.SuccessPaymentLogs.Add(log);
            _context.SaveChangesAsync();
        }

        public List<SuccessPaymentLog> GetSuccessPaymentLogs()
        {
            return _context.SuccessPaymentLogs.ToList();
        }

        public async void UpdateRefundAmountSuccessPaymentLog(SuccessPaymentLog updatedLog)
        {
            var existingLog = _context.SuccessPaymentLogs.FirstOrDefault(log => log.pspReference == updatedLog.pspReference);
            if (existingLog != null)
            {
                existingLog.refundAmount = updatedLog.refundAmount;
                await _context.SaveChangesAsync();
            }
        }
    }
}