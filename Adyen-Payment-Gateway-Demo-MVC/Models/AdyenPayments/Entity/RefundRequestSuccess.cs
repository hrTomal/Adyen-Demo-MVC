using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Entity
{
    [Table("RefundRequestSuccessLog", Schema = "payments")]
    public class RefundRequestSuccess
    {
        [Key]
        public string pspReference { get; set; }
        public string merchantAccount { get; set; }
        public string paymentPspReference { get; set; }
        public string reference { get; set; }        
        public string status { get; set; }
    }
}