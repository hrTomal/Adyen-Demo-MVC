using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Entity.Webhook
{
    [Table("AdyenBalanceAccountWebhooks", Schema = "dbo")]
    public class AdyenBalanceAccountWebhook
    {
        [Key]
        public string balanceAccountId { get; set; }
        public string accountHolderId { get; set; }
        public string type { get; set; }
        public DateTime createdOn { get; set; }
        public string requestJson { get; set; }
    }
}