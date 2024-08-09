using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Entity
{
    [Table("AdyenSubscriptionWebhook", Schema ="dbo")]
    public class RecurringContractLog
    {
        [Key]
        public string PspReference { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string Request { get; set; }
        public string RecurringDetailReference { get; set; }
        public string MerchantAccountCode { get; set; }
        public string Currency { get; set; }
        public long Value { get; set; }
        public string ShopperReference { get; set; }
        public string EventDate { get; set; }


    }


}