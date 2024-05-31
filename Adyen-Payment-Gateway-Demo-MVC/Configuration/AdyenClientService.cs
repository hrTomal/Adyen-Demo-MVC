using System;
using Adyen;
using Adyen.Model;
using Environment = Adyen.Model.Environment;

namespace Adyen_Payment_Gateway_Demo_MVC.Configuration
{
    public class AdyenClientService
    {
        public Client CreateAdyenClient()
        {
            var apiKey = StaticVariablesConfig.GetAdyenApiKey();

            var config = new Config()
            {
                XApiKey = apiKey,
                Environment = Environment.Test
            };

            return new Client(config);
        }
        
        public RequestOptions CreateRequestOptions()
        {
            return new RequestOptions { IdempotencyKey = Guid.NewGuid().ToString() };
        }

        public Client CreateBalancePlatformClient()
        {
            var apiKey = StaticVariablesConfig.GetBalancePlatformApiKey();

            var config = new Config()
            {
                XApiKey = apiKey,
                Environment = Environment.Test
            };

            return new Client(config);
        }
        
        public Client CreateLegalEnityClient()
        {
            var apiKey = StaticVariablesConfig.GetLegalEnityClient();

            var config = new Config()
            {
                XApiKey = apiKey,
                Environment = Environment.Test
            };

            return new Client(config);
        }
    }
}