using Foundation;
using Maui.Google.UserMessagingPlatform;
using System.Diagnostics;

namespace Maui.Google.Services
{
    public class PrivacyAndConsentService : IPrivacyAndConsentService
    {
        private readonly ConsentInformation _consentInformation;
        private static readonly object LockObject = new();
        private bool _isMobileAdsSDKInitialized;

        public PrivacyAndConsentService()
        {
            _consentInformation = ConsentInformation.SharedInstance;
        }

        public void RequestConsentInfoUpdate(bool? isDebugGeographyEEA = null)
        {
            RequestParameters consentParameters = new();
            if (isDebugGeographyEEA ?? false)
            {
                consentParameters.DebugSettings = new DebugSettings()
                {
                    Geography = DebugGeography.Eea
                };
            }

            _consentInformation.RequestConsentInfoUpdate(consentParameters, OnConsentInformationUpdateCompletionHandler);

            if (_consentInformation.CanRequestAds)
            {
                InitializeMobileAdsSDK();
            }
        }

        public void ShowPrivacyOptionsForm()
        {
            if (IsPrivacyOptionsRequired())
            {
                var viewController = Platform.GetCurrentUIViewController();

                if (viewController is not null)
                {
                    ConsentForm.PresentPrivacyOptionsForm(viewController, ConsentFormPresentCompletionHandler);
                }
            }
        }

        public bool IsPrivacyOptionsRequired() =>
            _consentInformation.PrivacyOptionsRequirementStatus == PrivacyOptionsRequirementStatus.Required;

        private void OnConsentInformationUpdateCompletionHandler(NSError? error)
        {
            if (error is not null)
            {
                Debug.WriteLine($"{error.Code} - {error.Description}");
            }

            var viewController = Platform.GetCurrentUIViewController();
            if (viewController is not null)
            {
                ConsentForm.LoadAndPresentIfRequired(viewController, ConsentFormPresentCompletionHandler);
            }
        }

        private void ConsentFormPresentCompletionHandler(NSError? error)
        {
            if (error is not null)
            {
                Debug.WriteLine($"{error.Code} - {error.Description}");
            }

            if (_consentInformation.CanRequestAds)
            {
                InitializeMobileAdsSDK();
            }
        }

        private void InitializeMobileAdsSDK()
        {
            lock (LockObject)
            {
                if (!_isMobileAdsSDKInitialized)
                {
                    //MobileAds.SharedInstance.Start(CompletionHandler);
                    _isMobileAdsSDKInitialized = true;
                }
            }
        }

        //void CompletionHandler(InitializationStatus status) { }

        public bool CanRequestAds() =>
            _consentInformation.CanRequestAds;

        public void Reset() =>
            _consentInformation.Reset();
    }
}
