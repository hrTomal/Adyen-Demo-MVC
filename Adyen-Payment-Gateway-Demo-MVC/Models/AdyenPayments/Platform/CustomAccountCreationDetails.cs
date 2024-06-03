using Adyen.Model.BalancePlatform;
using Adyen.Model.LegalEntityManagement;

namespace Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Platform
{
    public class CustomAccountCreationDetails
    {
        public string redirectUrl{ get; set; }
        public LegalEntityInfoRequiredType legalEntityInfo { get; set; }
    }
}