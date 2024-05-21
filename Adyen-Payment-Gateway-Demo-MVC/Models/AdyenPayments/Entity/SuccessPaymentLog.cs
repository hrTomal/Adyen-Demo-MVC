using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Entity
{
    [Table("AdyenSuccessPaymentLog", Schema ="payments")]
    public class SuccessPaymentLog
    {
        [Key]
        public string pspReference { get; set; }
        public string resultCode { get; set; }
        public string merchantReference { get; set; }
        public string currency { get; set; }
        public long amount { get; set; }
        public string paymentMethodBrand { get; set; }
        public string paymentMethodType { get; set; }
        public long refundAmount { get; set; }

    }


}