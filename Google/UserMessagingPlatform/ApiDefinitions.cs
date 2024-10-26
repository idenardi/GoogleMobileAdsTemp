using System;
using System.Collections.Generic;

using Foundation;
using ObjCRuntime;

namespace Maui.Google.UserMessagingPlatform
{
    // typedef void (^UMPConsentFormLoadCompletionHandler)(UMPConsentForm * _Nullable, NSError * _Nullable);
    delegate void ConsentFormLoadCompletionHandler([NullAllowed] ConsentForm consentForm, [NullAllowed] NSError error);

    // typedef void (^UMPConsentFormPresentCompletionHandler)(NSError * _Nullable);
    delegate void ConsentFormPresentCompletionHandler([NullAllowed] NSError error);

    // typedef void (^UMPConsentInformationUpdateCompletionHandler)(NSError * _Nullable);
    delegate void ConsentInformationUpdateCompletionHandler([NullAllowed] NSError error);

    // @interface UMPConsentForm
    [DisableDefaultCtor]
    [BaseType(typeof(NSObject), Name = "UMPConsentForm")]
    interface ConsentForm
    {
        // +(void)loadWithCompletionHandler:(UMPConsentFormLoadCompletionHandler _Nonnull)completionHandler;
        [Static]
        [Export("loadWithCompletionHandler:")]
        void Load(ConsentFormLoadCompletionHandler completionHandler);

        // +(void)loadAndPresentIfRequiredFromViewController:(id)viewController completionHandler:(UMPConsentFormPresentCompletionHandler _Nullable)completionHandler;
        [Static]
        [Export("loadAndPresentIfRequiredFromViewController:completionHandler:")]
        void LoadAndPresentIfRequired(NSObject viewController, [NullAllowed] ConsentFormPresentCompletionHandler completionHandler);

        // +(void)presentPrivacyOptionsFormFromViewController:(id)viewController completionHandler:(UMPConsentFormPresentCompletionHandler _Nullable)completionHandler;
        [Static]
        [Export("presentPrivacyOptionsFormFromViewController:completionHandler:")]
        void PresentPrivacyOptionsForm(NSObject viewController, [NullAllowed] ConsentFormPresentCompletionHandler completionHandler);

        // -(void)presentFromViewController:(id)viewController completionHandler:(UMPConsentFormPresentCompletionHandler _Nullable)completionHandler;
        [Export("presentFromViewController:completionHandler:")]
        void Present(NSObject viewController, [NullAllowed] ConsentFormPresentCompletionHandler completionHandler);
    }

    // @interface UMPConsentInformation : NSObject
    [BaseType(typeof(NSObject), Name = "UMPConsentInformation")]
    interface ConsentInformation
    {
        // @property (readonly, nonatomic, class) UMPConsentInformation * _Nonnull sharedInstance;
        [Static]
        [Export("sharedInstance")]
        ConsentInformation SharedInstance { get; }

        // extern NSString *const _Nonnull UMPVersionString;
        [Field("UMPVersionString", "__Internal")]
        NSString UMPVersionString { get; }

        // extern NSErrorDomain  _Nonnull const UMPErrorDomain;
        [Field("UMPErrorDomain", "__Internal")]
        NSString UMPErrorDomain { get; }

        // @property (readonly, nonatomic) UMPConsentStatus consentStatus;
        [Export("consentStatus")]
        ConsentStatus ConsentStatus { get; }

        // @property (readonly, nonatomic) BOOL canRequestAds;
        [Export("canRequestAds")]
        bool CanRequestAds { get; }

        // @property (readonly, nonatomic) UMPFormStatus formStatus;
        [Export("formStatus")]
        FormStatus FormStatus { get; }

        // @property (readonly, nonatomic) UMPPrivacyOptionsRequirementStatus privacyOptionsRequirementStatus;
        [Export("privacyOptionsRequirementStatus")]
        PrivacyOptionsRequirementStatus PrivacyOptionsRequirementStatus { get; }

        // -(void)requestConsentInfoUpdateWithParameters:(id)parameters completionHandler:(UMPConsentInformationUpdateCompletionHandler _Nonnull)handler;
        [Export("requestConsentInfoUpdateWithParameters:completionHandler:")]
        void RequestConsentInfoUpdate(RequestParameters parameters, ConsentInformationUpdateCompletionHandler handler);

        // -(void)reset;
        [Export("reset")]
        void Reset();
    }

    // @interface UMPDebugSettings : NSObject <NSCopying>
    [BaseType(typeof(NSObject), Name = "UMPDebugSettings")]
    interface DebugSettings : INSCopying
    {
        // @property (copy, nonatomic) NSArray<NSString *> * _Nullable testDeviceIdentifiers;
        [NullAllowed, Export("testDeviceIdentifiers", ArgumentSemantic.Copy)]
        string[] TestDeviceIdentifiers { get; set; }

        // @property (nonatomic) UMPDebugGeography geography;
        [Export("geography", ArgumentSemantic.Assign)]
        DebugGeography Geography { get; set; }
    }

    // @interface UMPRequestParameters : NSObject <NSCopying>
    [BaseType(typeof(NSObject), Name = "UMPRequestParameters")]
    interface RequestParameters : INSCopying
    {
        // @property (nonatomic) BOOL tagForUnderAgeOfConsent;
        [Export("tagForUnderAgeOfConsent")]
        bool TagForUnderAgeOfConsent { get; set; }

        // @property (copy, nonatomic) UMPDebugSettings * _Nullable debugSettings;
        [NullAllowed, Export("debugSettings", ArgumentSemantic.Copy)]
        DebugSettings DebugSettings { get; set; }
    }
}