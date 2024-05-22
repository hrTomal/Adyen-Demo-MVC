using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Entity;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.LibraryRequests;
using Adyen_Payment_Gateway_Demo_MVC.Repository.Adyen;

namespace Adyen_Payment_Gateway_Demo_MVC.Application.Features.AdyenPayments.AdyenLibrary
{
    public class GetSuccessPaymentLogs
    {
        public List<SuccessPaymentLog> GetSuccessPaymentLogList()
        {
			try
			{
				var result = new SuccessPaymentLogRepository().GetSuccessPaymentLogs();
                return result;
            }
			catch (Exception ex)
			{
				throw;
			}
        }
    }
}