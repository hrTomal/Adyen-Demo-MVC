using Adyen.Model.BalancePlatform;
using Adyen.Model.LegalEntityManagement;
using Adyen.Model.Management;

namespace Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Platform
{
    public class CustomAccountCreationDetails
    {
        public bool ShouldCreateStore { get; set; }
        public LegalEntityInfoRequiredType legalEntityInfo { get; set; }
        public StoreCreationWithMerchantCodeRequest storeCreationWithMerchantCodeRequest { get; set; }
        public PaymentMethodSetupInfo paymentMethodSetupInfo { get; set; }
        public OnboardingLinkInfo onboardingLinkInfo { get; set; }
    }
}