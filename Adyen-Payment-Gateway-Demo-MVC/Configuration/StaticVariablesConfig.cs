using System;
using System.Configuration;

namespace Adyen_Payment_Gateway_Demo_MVC.Configuration
{
    public static class StaticVariablesConfig
    {
        public static string GetAdyenBaseUrlForTest()
        {
            string baseUrl = "https://checkout-test.adyen.com/v71";

            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new ApplicationException("Base Url Not Found.");
            }

            return baseUrl;
        }
        public static string GetAdyenApiKey()
        {
            string apiKey = ConfigurationManager.AppSettings["AdyenApiKey"];

            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ApplicationException("Adyen API key not found in the configuration file.");
            }

            return apiKey;
        }
        public static string GetAdyenMerchantCode()
        {
            string merchantCode = ConfigurationManager.AppSettings["MerchantCode"];

            if (string.IsNullOrEmpty(merchantCode))
            {
                throw new ApplicationException("Merchant Code not found in the configuration file.");
            }

            return merchantCode;
        }
    }
}