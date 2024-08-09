using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Entity.Webhook
{
    [Table("AdyenStandardHookReceivedJson", Schema = "dbo")]
    public class StandardHookReceivedJson
    {
        [Key]
        public string PspReference { get; set; }
        public string RequestJson { get; set; }
    }
}