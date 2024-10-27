namespace Maui.Google.Services;

public interface IPrivacyAndConsentService
{
    void RequestConsentInfoUpdate(bool? isDebugGeographyEEA = null);
    void ShowPrivacyOptionsForm();
    bool IsPrivacyOptionsRequired();
    void Reset();
    bool CanRequestAds();
}
