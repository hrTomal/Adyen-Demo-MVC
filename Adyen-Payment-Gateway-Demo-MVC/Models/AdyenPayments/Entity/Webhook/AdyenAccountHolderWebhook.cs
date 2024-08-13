using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Entity.Webhook
{
    [Table("AdyenAccountHolderWebhooks", Schema = "dbo")]
    public class AdyenAccountHolderWebhook
    {
        [Key]
        public string accountHolderId { get; set; }
        public string legalEntityId { get; set; }        
        public DateTime createdOn { get; set; }
        public string type { get; set; }
        public string requestJson { get; set; }
    }
}