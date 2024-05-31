using Adyen.Model.LegalEntityManagement;
using Newtonsoft.Json;

namespace Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Platform
{
    public class OnBoardingLinkInfoWithId
    {
        [JsonProperty("legalEntityId")]
        public string LegalEntityId { get; set; }

        [JsonProperty("onboardingLinkInfo")]
        public OnboardingLinkInfo OnboardingLinkInfo { get; set; }
    }
}