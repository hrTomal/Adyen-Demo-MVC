using Adyen.Model.BalancePlatform;
using Adyen.Model.LegalEntityManagement;
using Adyen.Model.Management;
using Adyen.Service.BalancePlatform;
using Adyen.Service.LegalEntityManagement;
using Adyen_Payment_Gateway_Demo_MVC.Configuration;
using Adyen_Payment_Gateway_Demo_MVC.Models.AdyenPayments.Platform;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adyen_Payment_Gateway_Demo_MVC.Application.Features.BalancePlatform
{
    public class CustomAccountCreation
    {
        public async Task<dynamic> CreateAccount(CustomAccountCreationDetails request)
        {
            try
            {
                var legalEntityCreationResponse = await AddLegalEntity(request.legalEntityInfo);
                if(legalEntityCreationResponse != null && legalEntityCreationResponse.Id != null)
                {
                    var accountHolderInfo = new AccountHolderInfo() { LegalEntityId = legalEntityCreationResponse.Id };
                    var accHolderCreateResponse = await CreateAccountHolder(accountHolderInfo);
                    if (accHolderCreateResponse != null && accHolderCreateResponse.Id != null)
                    {
                        var balanceAccountInfo = new BalanceAccountInfo() { };
                        balanceAccountInfo.AccountHolderId = accHolderCreateResponse.Id;
                        var balanceAccountResponse = await CreateBalanceAccount(balanceAccountInfo);

                        if(!request.ShouldCreateStore)
                        {
                            var onBoardingLinkResponse = await GenerateOnboardingLink(legalEntityCreationResponse.Id, request.onboardingLinkInfo);
                            return onBoardingLinkResponse;
                        }
                        if(balanceAccountResponse.Id != null)
                        {
                            var businessLineInfo = new BusinessLineInfo() { };
                            businessLineInfo.LegalEntityId = legalEntityCreationResponse.Id;
                            businessLineInfo.IndustryCode = "452A";
                            businessLineInfo.Service = BusinessLineInfo.ServiceEnum.PaymentProcessing;
                            var businessLineInfoResponse = await CreateBusinessLine(businessLineInfo);
                            if(businessLineInfoResponse.Id != null)
                            {
                                var storeCreationRequest = request.storeCreationWithMerchantCodeRequest;
                                storeCreationRequest.BusinessLineIds = new List<string> { businessLineInfoResponse.Id };
                                var createStoreResponse = await CreateStores(storeCreationRequest);

                                if(createStoreResponse != null && createStoreResponse.Id != null)
                                {
                                    var paymentMethodResponse = request.paymentMethodSetupInfo;
                                    paymentMethodResponse.BusinessLineId = businessLineInfoResponse.Id;
                                    paymentMethodResponse.StoreIds = new List<string> { createStoreResponse.Id };
                                    var createPayementMethodResponse = await CreatePaymentMethod(paymentMethodResponse);
                                    if(createPayementMethodResponse != null && createPayementMethodResponse.Id != null)
                                    {
                                        var onBoardingLinkResponse = await GenerateOnboardingLink(legalEntityCreationResponse.Id, request.onboardingLinkInfo);
                                        return onBoardingLinkResponse;
                                    }
                                    return new { Message = "Create Payment Method Issue" , AdyenResponse = createPayementMethodResponse };
                                }
                                return new { Message = "Create Store Issue", AdyenResponse = createStoreResponse };
                            }
                            return new { Message = "Create Business Line Issue", AdyenResponse = businessLineInfoResponse };
                        }
                        return new { Message = "Create Balance Account Issue", AdyenResponse = balanceAccountResponse };
                    }
                    return new { Message = "Create Account Holder Issue", AdyenResponse = accHolderCreateResponse };
                }
                return new { Message = "Create Legal Entity Issue", AdyenResponse = legalEntityCreationResponse };
            }
            catch (Adyen.HttpClient.HttpClientException ex)
            {
                return ex;
            }
        }

        private async Task<dynamic> AddLegalEntity(LegalEntityInfoRequiredType legalEntityInfoRequiredType)
        {
            var client = new AdyenClientService().CreateLegalEnityClient();
            try
            {
                var service = new LegalEntitiesService(client);
                var response = service.CreateLegalEntity(legalEntityInfoRequiredType);
                return response;
            }
            catch (Adyen.HttpClient.HttpClientException ex)
            {
                return JObject.Parse(ex.ResponseBody);
            }
        }
        private async Task<dynamic> CreateAccountHolder(AccountHolderInfo account)
        {
            try
            {
                var client = new AdyenClientService().CreateBalancePlatformClient();
                var service = new AccountHoldersService(client);
                var response = service.CreateAccountHolder(account);
                return response;
            }
            catch (Adyen.HttpClient.HttpClientException ex)
            {
                return JObject.Parse(ex.ResponseBody);
            }
        }

        private async Task<dynamic> CreateBalanceAccount(BalanceAccountInfo request)
        {
            try
            {
                var client = new AdyenClientService().CreateBalancePlatformClient();
                var service = new BalanceAccountsService(client);
                var response = service.CreateBalanceAccount(request);
                return response;
            }
            catch (Adyen.HttpClient.HttpClientException ex)
            {
                return JObject.Parse(ex.ResponseBody);
            }
        }

        private async Task<dynamic> CreateBusinessLine(BusinessLineInfo businessLineInfo)
        {
            var client = new AdyenClientService().CreateLegalEnityClient();
            try
            {
                var service = new BusinessLinesService(client);
                var response = service.CreateBusinessLine(businessLineInfo);
                return response;
            }
            catch (Adyen.HttpClient.HttpClientException ex)
            {
                return JObject.Parse(ex.ResponseBody);
            }
        }

        private async Task<dynamic> CreateStores(StoreCreationWithMerchantCodeRequest storeCreationRequest)
        {
            var client = new AdyenClientService().CreateAdyenClient();
            try
            {
                var service = new Adyen.Service.Management.AccountStoreLevelService(client);
                storeCreationRequest.MerchantId = StaticVariablesConfig.GetAdyenMerchantCode();

                var response = service.CreateStore(storeCreationRequest);
                return response;
            }
            catch (Adyen.HttpClient.HttpClientException ex)
            {
                return JObject.Parse(ex.ResponseBody);
            }
        }

        private async Task<dynamic> CreatePaymentMethod(PaymentMethodSetupInfo paymentMethodSetupInfo)
        {
            var client = new AdyenClientService().CreateAdyenClient();
            try
            {
                var service = new Adyen.Service.Management.PaymentMethodsMerchantLevelService(client);
                var merchantId = StaticVariablesConfig.GetAdyenMerchantCode();

                var response = service.RequestPaymentMethod(merchantId, paymentMethodSetupInfo);
                return response;
            }
            catch (Adyen.HttpClient.HttpClientException ex)
            {
                return JObject.Parse(ex.ResponseBody);
            }
        }

        private async Task<dynamic> GenerateOnboardingLink(string legalEntityId, OnboardingLinkInfo onboardingLinkInfo)
        {
            var client = new AdyenClientService().CreateLegalEnityClient();
            try
            {
                var service = new HostedOnboardingService(client);
                var response = service.GetLinkToAdyenhostedOnboardingPage(legalEntityId, onboardingLinkInfo);
                return response;
            }
            catch (Adyen.HttpClient.HttpClientException ex)
            {
                return JObject.Parse(ex.ResponseBody);
            }
        }
    }
}