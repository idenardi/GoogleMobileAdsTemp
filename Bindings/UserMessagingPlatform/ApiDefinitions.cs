using Foundation;
using ObjCRuntime;
using UserMessagingPlatform;

// typedef void (^UMPConsentFormLoadCompletionHandler)(UMPConsentForm * _Nullable, int * _Nullable);
unsafe delegate void UMPConsentFormLoadCompletionHandler ([NullAllowed] UMPConsentForm arg0, [NullAllowed] int* arg1);

// typedef void (^UMPConsentFormPresentCompletionHandler)(int * _Nullable);
unsafe delegate void UMPConsentFormPresentCompletionHandler ([NullAllowed] int* arg0);

// @interface UMPConsentForm
interface UMPConsentForm
{
	// +(void)loadWithCompletionHandler:(UMPConsentFormLoadCompletionHandler _Nonnull)completionHandler;
	[Static]
	[Export ("loadWithCompletionHandler:")]
	void LoadWithCompletionHandler (UMPConsentFormLoadCompletionHandler completionHandler);

	// +(void)loadAndPresentIfRequiredFromViewController:(id)viewController completionHandler:(UMPConsentFormPresentCompletionHandler _Nullable)completionHandler;
	[Static]
	[Export ("loadAndPresentIfRequiredFromViewController:completionHandler:")]
	void LoadAndPresentIfRequiredFromViewController (NSObject viewController, [NullAllowed] UMPConsentFormPresentCompletionHandler completionHandler);

	// +(void)presentPrivacyOptionsFormFromViewController:(id)viewController completionHandler:(UMPConsentFormPresentCompletionHandler _Nullable)completionHandler;
	[Static]
	[Export ("presentPrivacyOptionsFormFromViewController:completionHandler:")]
	void PresentPrivacyOptionsFormFromViewController (NSObject viewController, [NullAllowed] UMPConsentFormPresentCompletionHandler completionHandler);

	// -(void)presentFromViewController:(id)viewController completionHandler:(UMPConsentFormPresentCompletionHandler _Nullable)completionHandler;
	[Export ("presentFromViewController:completionHandler:")]
	void PresentFromViewController (NSObject viewController, [NullAllowed] UMPConsentFormPresentCompletionHandler completionHandler);
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString *const _Nonnull UMPVersionString;
	[Field ("UMPVersionString", "__Internal")]
	NSString UMPVersionString { get; }
}

// typedef void (^UMPConsentInformationUpdateCompletionHandler)(NSError * _Nullable);
delegate void UMPConsentInformationUpdateCompletionHandler ([NullAllowed] NSError arg0);

// @interface UMPConsentInformation : NSObject
[BaseType (typeof(NSObject))]
interface UMPConsentInformation
{
	// @property (readonly, nonatomic, class) UMPConsentInformation * _Nonnull sharedInstance;
	[Static]
	[Export ("sharedInstance")]
	UMPConsentInformation SharedInstance { get; }

	// @property (readonly, nonatomic) UMPConsentStatus consentStatus;
	[Export ("consentStatus")]
	UMPConsentStatus ConsentStatus { get; }

	// @property (readonly, nonatomic) BOOL canRequestAds;
	[Export ("canRequestAds")]
	bool CanRequestAds { get; }

	// @property (readonly, nonatomic) UMPFormStatus formStatus;
	[Export ("formStatus")]
	UMPFormStatus FormStatus { get; }

	// @property (readonly, nonatomic) UMPPrivacyOptionsRequirementStatus privacyOptionsRequirementStatus;
	[Export ("privacyOptionsRequirementStatus")]
	UMPPrivacyOptionsRequirementStatus PrivacyOptionsRequirementStatus { get; }

	// -(void)requestConsentInfoUpdateWithParameters:(id)parameters completionHandler:(UMPConsentInformationUpdateCompletionHandler _Nonnull)handler;
	[Export ("requestConsentInfoUpdateWithParameters:completionHandler:")]
	void RequestConsentInfoUpdateWithParameters (NSObject parameters, UMPConsentInformationUpdateCompletionHandler handler);

	// -(void)reset;
	[Export ("reset")]
	void Reset ();
}

// @interface UMPDebugSettings : NSObject <NSCopying>
[BaseType (typeof(NSObject))]
interface UMPDebugSettings : INSCopying
{
	// @property (copy, nonatomic) NSArray<NSString *> * _Nullable testDeviceIdentifiers;
	[NullAllowed, Export ("testDeviceIdentifiers", ArgumentSemantic.Copy)]
	string[] TestDeviceIdentifiers { get; set; }

	// @property (nonatomic) UMPDebugGeography geography;
	[Export ("geography", ArgumentSemantic.Assign)]
	UMPDebugGeography Geography { get; set; }
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSErrorDomain  _Nonnull const UMPErrorDomain;
	[Field ("UMPErrorDomain", "__Internal")]
	NSString UMPErrorDomain { get; }
}

// @interface UMPRequestParameters : NSObject <NSCopying>
[BaseType (typeof(NSObject))]
interface UMPRequestParameters : INSCopying
{
	// @property (nonatomic) BOOL tagForUnderAgeOfConsent;
	[Export ("tagForUnderAgeOfConsent")]
	bool TagForUnderAgeOfConsent { get; set; }

	// @property (copy, nonatomic) UMPDebugSettings * _Nullable debugSettings;
	[NullAllowed, Export ("debugSettings", ArgumentSemantic.Copy)]
	UMPDebugSettings DebugSettings { get; set; }
}
