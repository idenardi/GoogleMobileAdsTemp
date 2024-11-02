using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using Maui.Google.MobileAds;
using Maui.Google.MobileAds.Mediation;
using ObjCRuntime;
using UIKit;
using WebKit;

namespace Maui.Google.MobileAds
{
    // @interface GADAdChoicesView : UIView
    [BaseType(typeof(UIView), Name = "GADAdChoicesView")]
    interface AdChoicesView
    {
    }

    [Static]
    interface AdLoaderAdTypeConstants
    {
        // extern GADAdLoaderAdType  _Nonnull const GADAdLoaderAdTypeCustomNative;
        [Field("GADAdLoaderAdTypeCustomNative", "__Internal")]
        NSString CustomNative { get; }

        // extern GADAdLoaderAdType  _Nonnull const GADAdLoaderAdTypeGAMBanner;
        [Field("GADAdLoaderAdTypeGAMBanner", "__Internal")]
        NSString GamBanner { get; }

        // extern GADAdLoaderAdType  _Nonnull const GADAdLoaderAdTypeNative;
        [Field("GADAdLoaderAdTypeNative", "__Internal")]
        NSString Native { get; }
    }

    // @protocol GADAdLoaderDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject), Name = "GADAdLoaderDelegate")]
    interface AdLoaderDelegate
    {
        // @required -(void)adLoader:(GADAdLoader * _Nonnull)adLoader didFailToReceiveAdWithError:(NSError * _Nonnull)error;
        [Abstract]
        [Export("adLoader:didFailToReceiveAdWithError:")]
        void DidFailToReceiveAd(AdLoader adLoader, NSError error);

        // @optional - (void)adLoaderDidFinishLoading:(GADAdLoader *)adLoader;
        [Export("adLoaderDidFinishLoading:")]
        void DidFinishLoading(AdLoader adLoader);
    }

    [Model]
    [Protocol]
    [BaseType(typeof(NSObject), Name = "GADAdNetworkExtras")]
    interface AdNetworkExtras
    {
    }

    interface IAdNetworkExtras { }

    [DisableDefaultCtor]
    [BaseType(typeof(NSObject), Name = "GADRequest")]
    interface Request : INSCopying
    {
        // +(instancetype _Nonnull)request;
        [Static]
        [Export("request")]
        Request GetDefaultRequest();

        // -(void)registerAdNetworkExtras:(id<GADAdNetworkExtras> _Nonnull)extras;
        [Export("registerAdNetworkExtras:")]
        void RegisterAdNetworkExtras(IAdNetworkExtras extras);

        // -(id<GADAdNetworkExtras> _Nullable)adNetworkExtrasFor:(Class<GADAdNetworkExtras> _Nonnull)aClass;
        [Export("adNetworkExtrasFor:")]
        IAdNetworkExtras AdNetworkExtrasFor([NullAllowed] Class aClass);

        // -(void)removeAdNetworkExtrasFor:(Class<GADAdNetworkExtras> _Nonnull)aClass;
        [Export("removeAdNetworkExtrasFor:")]
        void RemoveAdNetworkExtrasFor(Class aClass);

        // @property (nonatomic, weak) API_AVAILABLE(ios(13.0)) UIWindowScene * scene __attribute__((availability(ios, introduced=13.0)));
        [System.Runtime.Versioning.SupportedOSPlatform("ios13.0")]
        [Export("scene", ArgumentSemantic.Weak)]
        UIWindowScene Scene { get; set; }

        // @property (copy, nonatomic) NSArray<NSString *> * _Nullable keywords;
        [NullAllowed, Export("keywords", ArgumentSemantic.Copy)]
        string[] Keywords { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable contentURL;
        [NullAllowed, Export("contentURL")]
        string ContentUrl { get; set; }

        // @property (copy, nonatomic) NSArray<NSString *> * _Nullable neighboringContentURLStrings;
        [NullAllowed, Export("neighboringContentURLStrings", ArgumentSemantic.Copy)]
        string[] NeighboringContentUrlStrings { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable requestAgent;
        [NullAllowed, Export("requestAgent")]
        string RequestAgent { get; set; }

        // @property (copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable customTargeting;
        [NullAllowed, Export("customTargeting", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSString> CustomTargeting { get; set; }

        // extern GADMaxAdContentRating  _Nonnull const GADMaxAdContentRatingGeneral;
        [Field("GADMaxAdContentRatingGeneral", "__Internal")]
        NSString MaxAdContentRatingGeneral { get; }

        // extern GADMaxAdContentRating  _Nonnull const GADMaxAdContentRatingParentalGuidance;
        [Field("GADMaxAdContentRatingParentalGuidance", "__Internal")]
        NSString MaxAdContentRatingParentalGuidance { get; }

        // extern GADMaxAdContentRating  _Nonnull const GADMaxAdContentRatingTeen;
        [Field("GADMaxAdContentRatingTeen", "__Internal")]
        NSString MaxAdContentRatingTeen { get; }

        // extern GADMaxAdContentRating  _Nonnull const GADMaxAdContentRatingMatureAudience;
        [Field("GADMaxAdContentRatingMatureAudience", "__Internal")]
        NSString MaxAdContentRatingMatureAudience { get; }

        // extern NSString *const _Nonnull GADSimulatorID;
        [Field("GADSimulatorID", "__Internal")]
        NSString SimulatorId { get; }

        ///
        /// From GADRequest_AdString Category
        ///

        // @property (copy, nonatomic) NSString * _Nullable adString;
        [NullAllowed, Export("adString")]
        string AdString { get; set; }
    }

    // @interface GADAdLoaderOptions : NSObject
    [BaseType(typeof(NSObject), Name = "GADAdLoaderOptions")]
    interface AdLoaderOptions
    {
    }

    // @interface GADAdLoader : NSObject
    [DisableDefaultCtor]
    [BaseType(typeof(NSObject), Name = "GADAdLoader")]
    interface AdLoader
    {
        // @property (nonatomic, weak) id<GADAdLoaderDelegate> __nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        IAdLoaderDelegate Delegate { get; set; }

        // @property(nonatomic, readonly) NSString *adUnitID;
        [Export("adUnitID")]
        string AdUnitId { get; }

        // @property(nonatomic, getter=isLoading, readonly) BOOL loading;
        [Export("isLoading")]
        bool IsLoading { get; }

        // -(instancetype)initWithAdUnitID:(NSString *)adUnitID rootViewController:(UIViewController *)rootViewController adTypes:(NSArray *)adTypes options:(NSArray *)options;
        [Export("initWithAdUnitID:rootViewController:adTypes:options:")]
        NativeHandle Constructor(string adUnitID, [NullAllowed] UIViewController rootViewController, NSString[] adTypes, [NullAllowed] AdLoaderOptions[] options);

        // -(void)loadRequest:(GADRequest *)request;
        [Export("loadRequest:")]
        void LoadRequest([NullAllowed] Request request);
    }

    interface IAdLoaderDelegate { }

    // @protocol GADAdMetadataProvider <NSObject>
    [Model]
    [Protocol]
    [BaseType(typeof(NSObject), Name = "GADAdMetadataProvider")]
    interface AdMetadataProvider
    {
        // @property(nonatomic, readonly, nullable) NSDictionary<GADAdMetadataKey, id> *adMetadata;
        [Export("adMetadata")]
        NSDictionary<NSString, NSObject> AdMetadata { get; }

        // @property(nonatomic, weak, nullable) id<GADAdMetadataDelegate> adMetadataDelegate;
        [NullAllowed, Export("adMetadataDelegate", ArgumentSemantic.Weak)]
        AdMetadataDelegate AdMetadataDelegate { get; set; }
    }

    // @protocol GADAdMetadataDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject), Name = "GADAdMetadataDelegate")]
    interface AdMetadataDelegate
    {
        // @required -(void)adMetadataDidChange:(id<GADAdMetadataProvider> _Nonnull)ad;
        [Abstract]
        [Export("adMetadataDidChange:")]
        void AdMetadataDidChange(AdMetadataProvider ad);
    }

    // typedef void (^GADUserDidEarnRewardHandler)();
    delegate void UserDidEarnRewardHandler();

    // @interface GADAdReward : NSObject
    [DisableDefaultCtor]
    [BaseType(typeof(NSObject), Name = "GADAdReward")]
    interface AdReward
    {
        // @property (readonly, nonatomic) NSString * _Nonnull type;
        [Export("type")]
        string Type { get; }

        // @property (readonly, nonatomic) NSDecimalNumber * _Nonnull amount;
        [Export("amount")]
        NSDecimalNumber Amount { get; }

        // -(instancetype _Nonnull)initWithRewardType:(NSString * _Nullable)rewardType rewardAmount:(NSDecimalNumber * _Nullable)rewardAmount __attribute__((objc_designated_initializer));
        [DesignatedInitializer]
        [Export("initWithRewardType:rewardAmount:")]
        NativeHandle Constructor(string rewardType, NSDecimalNumber rewardAmount);
    }

    #region CustomLib
    // This is a custom class created by me and is not part of Google Admob lib
    // But it is necesary for this binding to work
    [Static]
    interface AdSizeCons
    {
        [Internal]
        [Field("GADAdSizeBanner", "__Internal")]
        IntPtr _Banner { get; }

        [Internal]
        [Field("GADAdSizeLargeBanner", "__Internal")]
        IntPtr _LargeBanner { get; }

        [Internal]
        [Field("GADAdSizeMediumRectangle", "__Internal")]
        IntPtr _MediumRectangle { get; }

        [Internal]
        [Field("GADAdSizeFullBanner", "__Internal")]
        IntPtr _FullBanner { get; }

        [Internal]
        [Field("GADAdSizeLeaderboard", "__Internal")]
        IntPtr _Leaderboard { get; }

        [Internal]
        [Field("GADAdSizeSkyscraper", "__Internal")]
        IntPtr _Skyscraper { get; }

        [Internal]
        [Field("kGADAdSizeSmartBannerPortrait", "__Internal")]
        IntPtr _SmartBannerPortrait { get; }

        [Internal]
        [Field("kGADAdSizeSmartBannerLandscape", "__Internal")]
        IntPtr _SmartBannerLandscape { get; }

        [Internal]
        [Field("GADAdSizeFluid", "__Internal")]
        IntPtr _Fluid { get; }

        [Internal]
        [Field("GADAdSizeInvalid", "__Internal")]
        IntPtr _Invalid { get; }
    }
    #endregion

    // @protocol GADAdSizeDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject), Name = "GADAdSizeDelegate")]
    interface AdSizeDelegate
    {
        // @required -(void)adView:(GADBannerView * _Nonnull)bannerView willChangeAdSizeTo:(GADAdSize)size;
        [Abstract]
        [EventArgs("AdSizeDelegateSize")]
        [Export("adView:willChangeAdSizeTo:")]
        void WillChangeAdSizeTo(BannerView view, AdSize size);
    }

    // typedef void (^GADPaidEventHandler)(GADAdValue * _Nonnull);
    delegate void PaidEventHandler(AdValue value);

    // @interface GADAdValue : NSObject <NSCopying>
    [BaseType(typeof(NSObject), Name = "GADAdValue")]
    interface AdValue : INSCopying
    {
        // @property (readonly, nonatomic) GADAdValuePrecision precision;
        [Export("precision")]
        AdValuePrecision Precision { get; }

        // @property (readonly, nonatomic) NSDecimalNumber * _Nonnull value;
        [Export("value")]
        NSDecimalNumber Value { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull currencyCode;
        [Export("currencyCode")]
        string CurrencyCode { get; }
    }

    // @protocol GADAppEventDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject), Name = "GADAppEventDelegate")]
    interface AppEventDelegate
    {
        // @optional -(void)adView:(GADBannerView * _Nonnull)banner didReceiveAppEvent:(NSString * _Nonnull)name withInfo:(NSString * _Nullable)info;
        [EventArgs("AppEvent")]
        [EventName("AppEventReceived")]
        [Export("adView:didReceiveAppEvent:withInfo:")]
        void AdViewDidReceiveAppEvent(BannerView banner, string name, [NullAllowed] string info);

        // @optional -(void)interstitialAd:(GADInterstitialAd * _Nonnull)interstitialAd didReceiveAppEvent:(NSString * _Nonnull)name withInfo:(NSString * _Nullable)info;
        [EventArgs("AppEvent")]
        [EventName("InterstitialEventReceived")]
        [Export("interstitial:didReceiveAppEvent:withInfo:")]
        void InterstitialDidReceiveAppEvent(InterstitialAd interstitial, string name, [NullAllowed] string info);
    }

    [Protocol]
    [BaseType(typeof(NSObject), Name = "GADFullScreenPresentingAd",
        Delegates = new string[] { "Delegate" },
        Events = new Type[] { typeof(FullScreenContentDelegate) })]
    interface FullScreenPresentingAd
    {
        [NullAllowed, Export("fullScreenContentDelegate", ArgumentSemantic.Weak)]
        IFullScreenContentDelegate Delegate { get; set; }
    }

    interface IFullScreenContentDelegate { }

    [Protocol, Model]
    [BaseType(typeof(NSObject), Name = "GADFullScreenContentDelegate")]
    interface FullScreenContentDelegate
    {
        // -(void)adDidRecordImpression:(id<GADFullScreenPresentingAd> _Nonnull)ad;
        [EventArgs("FullScreenPresentingAd")]
        [EventName("RecordedImpression")]
        [Export("adDidRecordImpression:")]
        void DidRecordImpression(FullScreenPresentingAd ad);

        // -(void)adDidRecordClick:(id<GADFullScreenPresentingAd> _Nonnull)ad;
        [EventArgs("FullScreenPresentingAd")]
        [EventName("RecordedClick")]
        [Export("adDidRecordClick:")]
        void DidRecordClick(FullScreenPresentingAd ad);

        // -(void)ad:(id<GADFullScreenPresentingAd> _Nonnull)ad didFailToPresentFullScreenContentWithError:(NSError * _Nonnull)error;
        [EventArgs("FullScreenPresentingAdWithError")]
        [EventName("FailedToPresentContent")]
        [Export("ad:didFailToPresentFullScreenContentWithError:")]
        void DidFailToPresentFullScreenContent(FullScreenPresentingAd ad, NSError error);

        // -(void)adWillPresentFullScreenContent:(id<GADFullScreenPresentingAd> _Nonnull)ad;
        [EventArgs("FullScreenPresentingAd")]
        [EventName("PresentedContent")]
        [Export("adWillPresentFullScreenContent:")]
        void WillPresentFullScreenContent(FullScreenPresentingAd ad);

        // -(void)adWillDismissFullScreenContent:(id<GADFullScreenPresentingAd> _Nonnull)ad;
        [EventArgs("FullScreenPresentingAd")]
        [EventName("DismissingContent")]
        [Export("adWillDismissFullScreenContent:")]
        void WillDismissFullScreenContent(FullScreenPresentingAd ad);

        // -(void)adDidDismissFullScreenContent:(id<GADFullScreenPresentingAd> _Nonnull)ad;
        [Export("adDidDismissFullScreenContent:")]
        [EventArgs("FullScreenPresentingAd")]
        [EventName("DismissedContent")]
        void DidDismissFullScreenContent(FullScreenPresentingAd ad);
    }

    // @interface GADAdNetworkResponseInfo : NSObject
    [BaseType(typeof(NSObject), Name = "GADAdNetworkResponseInfo")]
    interface AdNetworkResponseInfo
    {
        // extern NSString *const _Nonnull GADErrorDomain;
        [Field("GADErrorDomain", "__Internal")]
        NSString ErrorDomain { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull adNetworkClassName;
        [Export("responseIdentifier")]
        string AdNetworkClassName { get; }

        // @property (readonly, nonatomic) NSDictionary<NSString *,id> * _Nonnull adUnitMapping;
        [Export("adUnitMapping")]
        NSDictionary<NSString, NSObject> AdUnitMapping { get; }

        // @property (readonly, nonatomic) NSString * _Nullable adSourceName;
        [NullAllowed, Export("adSourceName")]
        string AdSourceName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable adSourceID;
        [NullAllowed, Export("adSourceID")]
        string AdSourceID { get; }

        // @property (readonly, nonatomic) NSString * _Nullable adSourceInstanceName;
        [NullAllowed, Export("adSourceInstanceName")]
        string AdSourceInstanceName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable adSourceInstanceID;
        [NullAllowed, Export("adSourceInstanceID")]
        string AdSourceInstanceID { get; }

        // @property (readonly, nonatomic) NSError * _Nullable error;
        [NullAllowed, Export("error")]
        NSError Error { get; }

        // @property (readonly, nonatomic) NSTimeInterval latency;
        [Export("latency")]
        double Latency { get; }

        // @property (readonly, nonatomic) NSDictionary<NSString *,id> * _Nonnull dictionaryRepresentation;
        [Export("dictionaryRepresentation")]
        NSDictionary<NSString, NSObject> DictionaryRepresentation { get; }
    }

    // @interface GADResponseInfo : NSObject
    [BaseType(typeof(NSObject), Name = "GADResponseInfo")]
    interface ResponseInfo
    {
        // extern NSString *const _Nonnull GADGoogleAdNetworkClassName;
        [Field("GADGoogleAdNetworkClassName", "__Internal")]
        NSString GoogleAdNetworkClassName { get; }

        // extern NSString *const _Nonnull GADCustomEventAdNetworkClassName;
        [Field("GADCustomEventAdNetworkClassName", "__Internal")]
        NSString CustomEventAdNetworkClassName { get; }

        // extern NSString * _Nonnull GADErrorUserInfoKeyResponseInfo;
        [Field("GADErrorUserInfoKeyResponseInfo", "__Internal")]
        NSString ErrorUserInfoKey { get; }

        // @property (readonly, nonatomic) NSString * _Nullable responseIdentifier;
        [NullAllowed, Export("responseIdentifier")]
        string ResponseIdentifier { get; }

        // @property (readonly, nonatomic) NSDictionary<NSString *,id> * _Nonnull extrasDictionary;
        [Export("extrasDictionary")]
        NSDictionary<NSString, NSObject> ExtrasDictionary { get; }

        // @property (readonly, nonatomic) GADAdNetworkResponseInfo * _Nullable loadedAdNetworkResponseInfo;
        [NullAllowed, Export("loadedAdNetworkResponseInfo")]
        AdNetworkResponseInfo LoadedAdNetworkResponseInfo { get; }

        // @property (readonly, nonatomic) NSArray<GADAdNetworkResponseInfo *> * _Nonnull adNetworkInfoArray;    
        [Export("adNetworkInfoArray")]
        AdNetworkResponseInfo[] AdNetworkInfo { get; }

        // @property (readonly, nonatomic) NSDictionary<NSString *,id> * _Nonnull dictionaryRepresentation;
        [Export("dictionaryRepresentation")]
        NSDictionary<NSString, NSObject> DictionaryRepresentation { get; }
    }

    // typedef void (^GADAppOpenAdLoadCompletionHandler)(GADAppOpenAd * _Nullable, NSError * _Nullable);
    delegate void AppOpenAdLoadCompletionHandler([NullAllowed] AppOpenAd appOpenAd, [NullAllowed] NSError error);

    // @interface GADAppOpenAd : GADFullScreenPresentingAd
    [DisableDefaultCtor]
    [BaseType(typeof(FullScreenContentDelegate), Name = "GADAppOpenAd")]
    interface AppOpenAd
    {
        // +(void)loadWithAdUnitID:(NSString * _Nonnull)adUnitID request:(id)request completionHandler:(GADAppOpenAdLoadCompletionHandler _Nonnull)completionHandler;
        [Async]
        [Static]
        [Export("loadWithAdUnitID:request:orientation:completionHandler:")]
        void Load(string adUnitId, [NullAllowed] Request request, UIInterfaceOrientation orientation, AppOpenAdLoadCompletionHandler completionHandler);

        // @property (readonly, nonatomic) NSString * _Nonnull adUnitID;
        [Export("adUnitID")]
        string AdUnitID { get; }

        // @property (nonatomic, readonly, nonnull) GADResponseInfo* responseInfo;
        [Export("responseInfo")]
        ResponseInfo ResponseInfo { get; }

        // @property (nonatomic, nullable, copy) GADPaidEventHandler paidEventHandler;
        [NullAllowed, Export("paidEventHandler", ArgumentSemantic.Copy)]
        PaidEventHandler PaidEventHandler { get; set; }

        // -(BOOL)canPresentFromRootViewController:(UIViewController * _Nullable)rootViewController error:(NSError * _Nullable * _Nullable)error;
        [Export("canPresentFromRootViewController:error:")]
        bool CanPresent(UIViewController rootViewController, [NullAllowed] out NSError error);

        // -(void)presentFromRootViewController:(UIViewController * _Nullable)rootViewController;
        [Export("presentFromRootViewController:")]
        void PresentFromRootViewController([NullAllowed] UIViewController rootViewController);
    }

    [Protocol, Model]
    [BaseType(typeof(NSObject), Name = "GADAudioVideoManagerDelegate")]
    interface AudioVideoManagerDelegate
    {
        // - (void)audioVideoManagerWillPlayVideo:(GADAudioVideoManager *)audioVideoManager;
        [EventArgs("AudioVideoManagerWillPlayVideo")]
        [Export("audioVideoManagerWillPlayVideo:")]
        void WillPlayVideo(AudioVideoManager audioVideoManager);

        // - (void)audioVideoManagerDidPauseAllVideo:(GADAudioVideoManager *)audioVideoManager;
        [EventArgs("AudioVideoManagerAllVideoPaused")]
        [EventName("AllVideoPaused")]
        [Export("audioVideoManagerDidPauseAllVideo:")]
        void DidPauseAllVideo(AudioVideoManager audioVideoManager);

        // - (void)audioVideoManagerWillPlayAudio:(GADAudioVideoManager *)audioVideoManager;
        [EventArgs("AudioVideoManagerWillPlayAudio")]
        [Export("audioVideoManagerWillPlayAudio:")]
        void WillPlayAudio(AudioVideoManager audioVideoManager);

        // - (void)audioVideoManagerDidStopPlayingAudio:(GADAudioVideoManager *)audioVideoManager;
        [EventArgs("AudioVideoManagerPlayingAudioStopped")]
        [EventName("PlayingAudioStopped")]
        [Export("audioVideoManagerDidStopPlayingAudio:")]
        void DidStopPlayingAudio(AudioVideoManager audioVideoManager);
    }

    // @interface GADAudioVideoManager : NSObject
    [BaseType(typeof(NSObject),
           Name = "GADAudioVideoManager",
           Delegates = new string[] { "Delegate" },
           Events = new Type[] { typeof(AudioVideoManagerDelegate) })]
    interface AudioVideoManager
    {
        // @property(nonatomic, weak, nullable) id<GADAudioVideoManagerDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        IAudioVideoManagerDelegate Delegate { get; set; }

        // @property(nonatomic, assign) BOOL audioSessionIsApplicationManaged;
        [Export("audioSessionIsApplicationManaged")]
        bool AudioSessionIsApplicationManaged { get; set; }
    }

    interface IAudioVideoManagerDelegate { }

    [Protocol, Model]
    [BaseType(typeof(NSObject), Name = "GADBannerViewDelegate")]
    interface BannerViewDelegate
    {

        [EventArgs("BannerViewE")]
        [EventName("AdReceived")]
        [Export("bannerViewDidReceiveAd:")]
        void DidReceiveAd(BannerView view);

        [EventArgs("BannerViewError")]
        [EventName("ReceiveAdFailed")]
        [Export("bannerView:didFailToReceiveAdWithError:")]
        void DidFailToReceiveAd(BannerView view, NSError error);

        [EventArgs("BannerViewE")]
        [EventName("ImpressionRecorded")]
        [Export("bannerViewDidRecordImpression:")]
        void DidRecordImpression(BannerView view);

        [EventArgs("BannerViewE")]
        [EventName("ClickRecorded")]
        [Export("bannerViewDidRecordClick:")]
        void DidRecordClick(BannerView view);

        [EventArgs("BannerViewE")]
        [Export("bannerViewWillPresentScreen:")]
        void WillPresentScreen(BannerView adView);

        [EventArgs("BannerViewE")]
        [Export("bannerViewWillDismissScreen:")]
        void WillDismissScreen(BannerView adView);

        [EventArgs("BannerViewE")]
        [EventName("ScreenDismissed")]
        [Export("bannerViewDidDismissScreen:")]
        void DidDismissScreen(BannerView adView);
    }

    interface IBannerViewDelegate { }

    interface IAdSizeDelegate { }

    [BaseType(typeof(UIView),
    Name = "GADBannerView",
    Delegates = new string[] { "Delegate", "AdSizeDelegate" },
    Events = new Type[] { typeof(BannerViewDelegate), typeof(AdSizeDelegate) })]
    interface BannerView
    {
        [Export("initWithAdSize:origin:")]
        NativeHandle Constructor(AdSize size, CGPoint origin);

        [Export("initWithAdSize:")]
        NativeHandle Constructor(AdSize size);

        [NullAllowed, Export("adUnitID", ArgumentSemantic.Copy)]
        string AdUnitId { get; set; }

        [NullAllowed, Export("rootViewController", ArgumentSemantic.Weak)]
        UIViewController RootViewController { get; set; }

        [Export("adSize", ArgumentSemantic.Assign)]
        AdSize AdSize { get; set; }

        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        IBannerViewDelegate Delegate { get; set; }

        // @property(nonatomic, weak, GAD_NULLABLE) IBOutlet id<GADAdSizeDelegate> adSizeDelegate;
        [NullAllowed, Export("adSizeDelegate", ArgumentSemantic.Weak)]
        IAdSizeDelegate AdSizeDelegate { get; set; }

        [Export("loadRequest:")]
        void LoadRequest([NullAllowed] Request request);

        [Export("autoloadEnabled", ArgumentSemantic.Assign)]
        bool AutoloadEnabled { [Bind("isAutoloadEnabled")] get; set; }

        // @property (readonly, nonatomic) GADResponseInfo * _Nullable responseInfo;
        [NullAllowed, Export("responseInfo")]
        ResponseInfo ResponseInfo { get; }

        // @property (copy, nonatomic) GADPaidEventHandler _Nullable paidEventHandler;
        [NullAllowed, Export("paidEventHandler", ArgumentSemantic.Copy)]
        PaidEventHandler PaidEventHandler { get; set; }

        // @property (readonly, nonatomic) BOOL isCollapsible;
        [Export("isCollapsible")]
        bool IsCollapsible { get; }
    }

    [Protocol, Model]
    [BaseType(typeof(NSObject), Name = "GADCustomEventBannerDelegate")]
    interface CustomEventBannerDelegate
    {
        // @required -(void)customEventBanner:(id<GADCustomEventBanner> _Nonnull)customEvent didReceiveAd:(UIView * _Nonnull)view;
        [EventArgs("CustomEventB")]
        [EventName("AdReceived")]
        [Export("customEventBanner:didReceiveAd:")]
        void DidReceiveAd(CustomEventBanner customEvent, UIView view);

        // @required -(void)customEventBanner:(id<GADCustomEventBanner> _Nonnull)customEvent didFailAd:(NSError * _Nullable)error;
        [EventArgs("CustomEventBError")]
        [EventName("AdFailed")]
        [Export("customEventBanner:didFailAd:")]
        void DidFailAd(CustomEventBanner customEvent, [NullAllowed] NSError error);

        // @required -(void)customEventBannerWasClicked:(id<GADCustomEventBanner> _Nonnull)customEvent;
        [EventArgs("CustomEventB")]
        [EventName("AdClicked")]
        [Export("customEventBannerWasClicked:")]
        void DidClickInAd(CustomEventBanner customEvent);

        // @required -(void)customEventBannerWillPresentModal:(id<GADCustomEventBanner> _Nonnull)customEvent;
        [EventArgs("CustomEventB")]
        [Export("customEventBannerWillPresentModal:")]
        void WillPresentModal(CustomEventBanner customEvent);

        // @required -(void)customEventBannerWillDismissModal:(id<GADCustomEventBanner> _Nonnull)customEvent;
        [EventArgs("CustomEventB")]
        [Export("customEventBannerWillDismissModal:")]
        void WillDismissModal(CustomEventBanner customEvent);

        // @required -(void)customEventBannerDidDismissModal:(id<GADCustomEventBanner> _Nonnull)customEvent;
        [EventArgs("CustomEventB")]
        [EventName("AdDismissed")]
        [Export("customEventBannerDidDismissModal:")]
        void DidDismissModal(CustomEventBanner customEvent);

        // @required -(void)customEventBanner:(id<GADCustomEventBanner> _Nonnull)customEvent clickDidOccurInAd:(UIView * _Nonnull)view __attribute__((deprecated("Use customEventBannerWasClicked:.")));
        [Obsolete("Deprecated. Use DidClickInAd.")]
        [EventArgs("CustomEventB")]
        [EventName("AdClickOcurred")]
        [Export("customEventBanner:clickDidOccurInAd:")]
        void ClickDidOccurInAd(CustomEventBanner customEvent, UIView view);

        // @required -(void)customEventBannerWillLeaveApplication:(id<GADCustomEventBanner> _Nonnull)customEvent __attribute__((deprecated("Deprecated. No replacement.")));
        [Obsolete("Deprecated. No replacement.")]
        [EventArgs("CustomEventB")]
        [Export("customEventBannerWillLeaveApplication:")]
        void WillLeaveApplication(CustomEventBanner customEvent);
    }

    [BaseType(typeof(NSObject), Name = "GADCustomEventRequest")]
    interface CustomEventRequest
    {
        [NullAllowed, Export("userKeywords", ArgumentSemantic.Copy)]
        NSObject[] UserKeywords { get; }

        [NullAllowed, Export("additionalParameters", ArgumentSemantic.Copy)]
        NSDictionary AdditionalParameters { get; }

        [Export("isTesting", ArgumentSemantic.Assign)]
        bool IsTesting { get; }
    }

    [BaseType(typeof(NSObject),
        Name = "GADCustomEventBanner",
        Delegates = new string[] { "Delegate" },
        Events = new Type[] { typeof(CustomEventBannerDelegate) })]
    interface CustomEventBanner
    {
        // extern NSString *const _Nonnull GADCustomEventParametersServer;
        [Field("GADCustomEventParametersServer", "__Internal")]
        NSString CustomEventParametersServer { get; }

        [Abstract]
        [Export("requestBannerAd:parameter:label:request:")]
        void RequestBannerAd(AdSize adSize, [NullAllowed] string serverParameter, [NullAllowed] string serverLabel, CustomEventRequest request);

        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        ICustomEventBannerDelegate Delegate { get; set; }
    }

    interface ICustomEventBannerDelegate { }

    [BaseType(typeof(NSObject), Name = "GADCustomEventExtras")]
    interface CustomEventExtras : AdNetworkExtras
    {
        // -(void)setExtras:(NSDictionary * _Nullable)extras forLabel:(NSString * _Nonnull)label;
        [Export("setExtras:forLabel:")]
        [PostGet("AllExtras")]
        void SetExtras([NullAllowed] NSDictionary extras, string label);

        // -(NSDictionary * _Nullable)extrasForLabel:(NSString * _Nonnull)label;
        [return: NullAllowed]
        [Export("extrasForLabel:")]
        NSDictionary ExtrasForLabel(string label);

        // -(void)removeAllExtras;
        [Export("removeAllExtras")]
        [PostGet("AllExtras")]
        void RemoveAllExtras();

        // -(NSDictionary * _Nonnull)allExtras;
        [Export("allExtras")]
        NSDictionary AllExtras { get; }
    }

    // @protocol GADCustomEventInterstitialDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject), Name = "GADCustomEventInterstitialDelegate")]
    interface CustomEventInterstitialDelegate
    {
        // @required -(void)customEventInterstitialDidReceiveAd:(id<GADCustomEventInterstitial> _Nonnull)customEvent;
        [EventArgs("CustomEventI")]
        [EventName("AdReceived")]
        [Export("customEventInterstitialDidReceiveAd:")]
        void DidReceiveAd(CustomEventInterstitial customEvent);

        // @required -(void)customEventInterstitial:(id<GADCustomEventInterstitial> _Nonnull)customEvent didFailAd:(NSError * _Nullable)error;
        [EventArgs("CustomEventIError")]
        [EventName("AdFailed")]
        [Export("customEventInterstitial:didFailAd:")]
        void DidFailAd(CustomEventInterstitial customEvent, [NullAllowed] NSError error);

        // @required -(void)customEventInterstitialWasClicked:(id<GADCustomEventInterstitial> _Nonnull)customEvent;
        [EventArgs("CustomEventI")]
        [EventName("AdClicked")]
        [Export("customEventInterstitialWasClicked:")]
        void DidClickAd(CustomEventInterstitial customEvent);

        // @required -(void)customEventInterstitialWillPresent:(id<GADCustomEventInterstitial> _Nonnull)customEvent;
        [EventArgs("CustomEventI")]
        [Export("customEventInterstitialWillPresent:")]
        void WillPresent(CustomEventInterstitial customEvent);

        // @required -(void)customEventInterstitialWillDismiss:(id<GADCustomEventInterstitial> _Nonnull)customEvent;
        [EventArgs("CustomEventI")]
        [Export("customEventInterstitialWillDismiss:")]
        void WillDismiss(CustomEventInterstitial customEvent);

        // @required -(void)customEventInterstitialDidDismiss:(id<GADCustomEventInterstitial> _Nonnull)customEvent;
        [EventArgs("CustomEventI")]
        [EventName("AdDismissed")]
        [Export("customEventInterstitialDidDismiss:")]
        void DidDismiss(CustomEventInterstitial customEvent);

        // @required -(void)customEventInterstitialWillLeaveApplication:(id<GADCustomEventInterstitial> _Nonnull)customEvent __attribute__((deprecated("Deprecated. No replacement.")));
        [Obsolete("Deprecated. No replacement.")]
        [EventArgs("CustomEventI")]
        [Export("customEventInterstitialWillLeaveApplication:")]
        void WillLeaveApplication(CustomEventInterstitial customEvent);
    }

    [BaseType(typeof(NSObject),
        Name = "GADCustomEventInterstitial",
        Delegates = new string[] { "Delegate" },
        Events = new Type[] { typeof(CustomEventInterstitialDelegate) })]
    interface CustomEventInterstitial
    {
        // extern NSString *const _Nonnull GADCustomEventParametersServer;
        [Field("GADCustomEventParametersServer", "__Internal")]
        NSString CustomEventParametersServer { get; }

        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        ICustomEventInterstitialDelegate Delegate { get; set; }

        [Abstract]
        [Export("requestInterstitialAdWithParameter:label:request:")]
        void RequestInterstitialAd([NullAllowed] string serverParameter, [NullAllowed] string serverLabel, CustomEventRequest request);

        [Abstract]
        [Export("presentFromRootViewController:")]
        void PresentFromRootViewController([NullAllowed] UIViewController rootViewController);
    }

    interface ICustomEventInterstitialDelegate { }

    interface ICustomEventNativeAd
    {
    }

    // @protocol GADCustomEventNativeAd <NSObject>
    [BaseType(typeof(NSObject),
        Name = "GADCustomEventNativeAd",
        Delegates = new string[] { "Delegate" },
        Events = new Type[] { typeof(CustomEventNativeAdDelegate) })]
    interface CustomEventNativeAd
    {
        // extern NSString *const _Nonnull GADCustomEventParametersServer;
        [Field("GADCustomEventParametersServer", "__Internal")]
        NSString CustomEventParametersServer { get; }

        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        ICustomEventNativeAdDelegate Delegate { get; set; }

        // @required -(void)requestNativeAdWithParameter:(NSString *)serverParameter request:(GADCustomEventRequest *)request adTypes:(NSArray *)adTypes options:(NSArray *)options rootViewController:(UIViewController *)rootViewController;
        [Abstract]
        [Export("requestNativeAdWithParameter:request:adTypes:options:rootViewController:")]
        void Request(string serverParameter, CustomEventRequest request, NSString[] adTypes, NSNumber[] options, UIViewController rootViewController);

        // - (BOOL)handlesUserClicks;
        [Abstract]
        [Export("handlesUserClicks")]
        bool HandlesUserClicks();

        // - (BOOL)handlesUserImpressions;
        [Abstract]
        [Export("handlesUserImpressions")]
        bool HandlesUserImpressions();
    }

    interface ICustomEventNativeAdDelegate
    {
    }

    [Static]
    interface NativeAdAssetIdentifiers
    {
        // extern GADNativeAssetIdentifier  _Nonnull const GADNativeHeadlineAsset;
        [Field("GADNativeHeadlineAsset", "__Internal")]
        NSString HeadlineAsset { get; }

        // extern GADNativeAssetIdentifier  _Nonnull const GADNativeCallToActionAsset;
        [Field("GADNativeCallToActionAsset", "__Internal")]
        NSString CallToActionAsset { get; }

        // extern GADNativeAssetIdentifier  _Nonnull const GADNativeIconAsset;
        [Field("GADNativeIconAsset", "__Internal")]
        NSString IconAsset { get; }

        // extern GADNativeAssetIdentifier  _Nonnull const GADNativeBodyAsset;
        [Field("GADNativeBodyAsset", "__Internal")]
        NSString BodyAsset { get; }

        // extern GADNativeAssetIdentifier  _Nonnull const GADNativeStoreAsset;
        [Field("GADNativeStoreAsset", "__Internal")]
        NSString StoreAsset { get; }

        // extern GADNativeAssetIdentifier  _Nonnull const GADNativePriceAsset;
        [Field("GADNativePriceAsset", "__Internal")]
        NSString PriceAsset { get; }

        // extern GADNativeAssetIdentifier  _Nonnull const GADNativeImageAsset;
        [Field("GADNativeImageAsset", "__Internal")]
        NSString ImageAsset { get; }

        // extern GADNativeAssetIdentifier  _Nonnull const GADNativeStarRatingAsset;
        [Field("GADNativeStarRatingAsset", "__Internal")]
        NSString StarRatingAsset { get; }

        // extern GADNativeAssetIdentifier  _Nonnull const GADNativeAdvertiserAsset;
        [Field("GADNativeAdvertiserAsset", "__Internal")]
        NSString AdvertiserAsset { get; }

        // extern GADNativeAssetIdentifier  _Nonnull const GADNativeMediaViewAsset;
        [Field("GADNativeMediaViewAsset", "__Internal")]
        NSString MediaViewAsset { get; }

        // extern GADNativeAssetIdentifier  _Nonnull const GADNativeAdChoicesViewAsset;
        [Field("GADNativeAdChoicesViewAsset", "__Internal")]
        NSString AdChoicesViewAsset { get; }
    }

    // @interface GADNativeAdImage : NSObject
    [DisableDefaultCtor]
    [BaseType(typeof(NSObject), Name = "GADNativeAdImage")]
    interface NativeAdImage
    {
        // @property (readonly, nonatomic, strong) UIImage * image;
        [NullAllowed, Export("image", ArgumentSemantic.Strong)]
        UIImage Image { get; }

        // @property (readonly, nonatomic, strong) NSURL * imageURL;
        [NullAllowed, Export("imageURL", ArgumentSemantic.Copy)]
        NSUrl ImageUrl { get; }

        // @property (readonly, assign, nonatomic) CGFloat scale;
        [Export("scale")]
        nfloat Scale { get; }

        ///
        /// From GADNativeAdImage_MediationAdditions Category
        ///

        // -(instancetype)initWithImage:(UIImage *)image;
        [Export("initWithImage:")]
        NativeHandle Constructor(UIImage image);

        // -(instancetype)initWithURL:(NSURL *)URL scale:(CGFloat)scale;
        [Export("initWithURL:scale:")]
        NativeHandle Constructor(NSUrl url, nfloat scale);
    }

    // @protocol GADMediatedUnifiedNativeAd <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject), Name = "GADMediatedUnifiedNativeAd")]
    interface MediatedUnifiedNativeAd
    {
        // @required @property (readonly, copy, nonatomic) NSString * _Nullable headline;
        [Abstract]
        [NullAllowed, Export("headline")]
        string Headline { get; }

        // @required @property (readonly, nonatomic) NSArray<GADNativeAdImage *> * _Nullable images;
        [Abstract]
        [NullAllowed, Export("images")]
        NativeAdImage[] Images { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nullable body;
        [Abstract]
        [NullAllowed, Export("body")]
        string Body { get; }

        // @required @property (readonly, nonatomic) GADNativeAdImage * _Nullable icon;
        [Abstract]
        [NullAllowed, Export("icon")]
        NativeAdImage Icon { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nullable callToAction;
        [Abstract]
        [NullAllowed, Export("callToAction")]
        string CallToAction { get; }

        // @required @property (readonly, copy, nonatomic) NSDecimalNumber * _Nullable starRating;
        [Abstract]
        [NullAllowed, Export("starRating", ArgumentSemantic.Copy)]
        NSDecimalNumber StarRating { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nullable store;
        [Abstract]
        [NullAllowed, Export("store")]
        string Store { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nullable price;
        [Abstract]
        [NullAllowed, Export("price")]
        string Price { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nullable advertiser;
        [Abstract]
        [NullAllowed, Export("advertiser")]
        string Advertiser { get; }

        // @required @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable extraAssets;
        [Abstract]
        [NullAllowed, Export("extraAssets", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> ExtraAssets { get; }

        // @optional @property (readonly, nonatomic) UIView * _Nullable adChoicesView;
        [NullAllowed, Export("adChoicesView")]
        UIView AdChoicesView { get; }

        // @optional @property (readonly, nonatomic) UIView * _Nullable mediaView;
        [NullAllowed, Export("mediaView")]
        UIView MediaView { get; }

        // @optional @property (readonly, assign, nonatomic) BOOL hasVideoContent;
        [Export("hasVideoContent")]
        bool HasVideoContent { get; }

        // @optional @property (readonly, nonatomic) CGFloat mediaContentAspectRatio;
        [Export("mediaContentAspectRatio")]
        nfloat MediaContentAspectRatio { get; }

        // @optional @property (readonly, nonatomic) NSTimeInterval duration;
        [Export("duration")]
        double Duration { get; }

        // @optional @property (readonly, nonatomic) NSTimeInterval currentTime;
        [Export("currentTime")]
        double CurrentTime { get; }

        // @optional -(void)didRenderInView:(UIView * _Nonnull)view clickableAssetViews:(NSDictionary<GADNativeAssetIdentifier,UIView *> * _Nonnull)clickableAssetViews nonclickableAssetViews:(NSDictionary<GADNativeAssetIdentifier,UIView *> * _Nonnull)nonclickableAssetViews viewController:(UIViewController * _Nonnull)viewController;
        [Export("didRenderInView:clickableAssetViews:nonclickableAssetViews:viewController:")]
        void DidRenderInView(UIView view, NSDictionary<NSString, UIView> clickableAssetViews, NSDictionary<NSString, UIView> nonclickableAssetViews, UIViewController viewController);

        // @optional -(void)didRecordImpression;
        [Export("didRecordImpression")]
        void DidRecordImpression();

        // @optional -(void)didRecordClickOnAssetWithName:(GADNativeAssetIdentifier _Nonnull)assetName view:(UIView * _Nonnull)view viewController:(UIViewController * _Nonnull)viewController;
        [Export("didRecordClickOnAssetWithName:view:viewController:")]
        void DidRecordClick(string assetName, UIView view, UIViewController viewController);

        // @optional -(void)didUntrackView:(UIView * _Nullable)view;
        [Export("didUntrackView:")]
        void DidUntrackView([NullAllowed] UIView view);
    }

    [Protocol, Model]
    [BaseType(typeof(NSObject), Name = "GADCustomEventNativeAdDelegate")]
    interface CustomEventNativeAdDelegate
    {
        // @required -(void)customEventNativeAd:(id<GADCustomEventNativeAd>)customEventNativeAd didFailToLoadWithError:(NSError *)error;
        [EventArgs("CustomEventNError")]
        [EventName("AdFailed")]
        [Export("customEventNativeAd:didFailToLoadWithError:")]
        void DidFailToLoad(CustomEventNativeAd customEventNativeAd, NSError error);

        // - (void)customEventNativeAd:(id<GADCustomEventNativeAd>)customEventNativeAd didReceiveMediatedUnifiedNativeAd:(id<GADMediatedUnifiedNativeAd>) mediatedUnifiedNativeAd;
        [EventArgs("CustomEventN")]
        [EventName("AdReceived")]
        [Export("customEventNativeAd:didReceiveMediatedUnifiedNativeAd:")]
        void DidReceiveMediatedUnifiedNativeAd(CustomEventNativeAd customEventNativeAd, MediatedUnifiedNativeAd mediatedUnifiedNativeAd);
    }

    // @interface GADDisplayAdMeasurement : NSObject
    [BaseType(typeof(NSObject), Name = "GADDisplayAdMeasurement")]
    interface DisplayAdMeasurement
    {
        // @property (nonatomic, weak) UIView * _Nullable view;
        [NullAllowed, Export("view", ArgumentSemantic.Weak)]
        UIView View { get; set; }

        // -(BOOL)startWithError:(NSError * _Nullable * _Nullable)error;
        [Export("startWithError:")]
        bool Start([NullAllowed] out NSError error);
    }

    // @interface GADVideoController : NSObject
    [BaseType(typeof(NSObject), Name = "GADVideoController",
        Delegates = new string[] { "Delegate" },
        Events = new Type[] { typeof(VideoControllerDelegate) })]
    interface VideoController
    {
        // @property (nonatomic, weak, GAD_NULLABLE) id<GADVideoControllerDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        IVideoControllerDelegate Delegate { get; set; }

        // @property (readonly, nonatomic) BOOL isMuted;
        [Export("isMuted")]
        bool IsMuted { get; }

        // - (void)setMute:(BOOL)mute;
        [Export("setMute:")]
        void SetMute(bool mute);

        // - (void)play;
        [Export("play")]
        void Play();

        // - (void)pause;
        [Export("pause")]
        void Pause();

        // - (void) stop;
        [Export("stop")]
        void Stop();

        // - (BOOL)customControlsEnabled;
        [Export("customControlsEnabled")]
        bool IsCustomControlsEnabled { get; }

        // - (BOOL)clickToExpandEnabled;
        [Export("clickToExpandEnabled")]
        bool IsClickToExpandEnabled { get; }
    }

    interface IVideoControllerDelegate { }

    // @interface GADMediaContent : NSObject
    [BaseType(typeof(NSObject), Name = "GADMediaContent")]
    interface MediaContent
    {
        // @property (readonly, nonatomic) GADVideoController * _Nonnull videoController;
        [Export("videoController")]
        VideoController VideoController { get; }

        // @property (readonly, nonatomic) BOOL hasVideoContent;
        [Export("hasVideoContent")]
        bool HasVideoContent { get; }

        // @property(nonatomic, readonly) CGFloat aspectRatio;
        [Export("aspectRatio")]
        nfloat AspectRatio { get; }

        // @property (readonly, nonatomic) NSTimeInterval duration;
        [Export("duration")]
        double Duration { get; }

        // @property (readonly, nonatomic) NSTimeInterval currentTime;
        [Export("currentTime")]
        double CurrentTime { get; }

        /// 
        /// From GADMediaContent (NativeAd) category
        /// 

        // @property (nonatomic) UIImage * _Nullable mainImage;
        [NullAllowed, Export("mainImage", ArgumentSemantic.Assign)]
        UIImage MainImage { get; set; }
    }

    // @interface GADMediaView : UIView
    [BaseType(typeof(UIView), Name = "GADMediaView")]
    interface MediaView
    {
        // @property (nonatomic, nullable) GADMediaContent* mediaContent;
        [NullAllowed, Export("mediaContent", ArgumentSemantic.Assign)]
        MediaContent MediaContent { get; set; }
    }

    // typedef void (^GADNativeAdCustomClickHandler)(NSString* assetID);
    delegate void NativeAdCustomClickHandle(string assetId);

    // @interface GADCustomNativeAd : UIView
    [BaseType(typeof(UIView), 
        Name = "GADCustomNativeAd",
        Delegates = new string[] { "Delegate" },
        Events = new Type[] { typeof(CustomNativeAdDelegate) })]
    interface CustomNativeAd
    {
        // extern NSString *const GADCustomTemplateAdMediaViewKey;
        [Internal]
        [Field("GADCustomNativeAdMediaViewKey", "__Internal")]
        NSString _MediaViewKey { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull formatID;
        [Export("formatID")]
        string FormatID { get; }

        // @property (readonly, nonatomic) NSArray<NSString *> * _Nonnull availableAssetKeys;
        [Export("availableAssetKeys")]
        string[] AvailableAssetKeys { get; }

        // @property (copy, atomic) GADNativeAdCustomClickHandler _Nullable customClickHandler;
        [NullAllowed, Export("customClickHandler", ArgumentSemantic.Copy)]
        NativeAdCustomClickHandle CustomClickHandler { get; }

        // @property (readonly, nonatomic) int * _Nullable displayAdMeasurement;
        [NullAllowed, Export("displayAdMeasurement")]
        DisplayAdMeasurement DisplayAdMeasurement { get; }

        // @property (readonly, nonatomic) int * _Nonnull mediaContent;
        [NullAllowed, Export("mediaContent")]
        MediaContent MediaContent { get; }

        // @property(nonatomic, weak, nullable) id<GADCustomNativeAdDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        ICustomNativeAdDelegate Delegate { get; set; }

        // @property (nonatomic, weak) UIViewController * _Nullable rootViewController;
        [NullAllowed, Export("rootViewController", ArgumentSemantic.Weak)]
        UIViewController RootViewController { get; set; }

        // @property (readonly, nonatomic) int * _Nonnull responseInfo;
        [Export("responseInfo")]
        ResponseInfo ResponseInfo { get; }

        // -(id)imageForKey:(NSString * _Nonnull)key;
        [return: NullAllowed]
        [Export("imageForKey:")]
        NativeAdImage ImageForKey(string key);

        // -(NSString * _Nullable)stringForKey:(NSString * _Nonnull)key;
        [return: NullAllowed]
        [Export("stringForKey:")]
        NSString StringForKey(string key);

        // -(void)performClickOnAssetWithKey:(NSString * _Nonnull)assetKey;
        [return: NullAllowed]
        [Export("performClickOnAssetWithKey:")]
        void PerformClickOnAssetWithKey(NSString assetKey);

        // -(void)recordImpression;
        [Export("recordImpression")]
        void RecordImpression();
    }

    interface ICustomNativeAdDelegate { }

    // @protocol GADCustomNativeAdLoaderDelegate <GADAdLoaderDelegate>
    [Protocol, Model]
    [BaseType(typeof(NSObject), Name = "GADCustomNativeAdLoaderDelegate")]
    interface CustomNativeAdLoaderDelegate : AdLoaderDelegate
    {
        // @required -(NSArray<NSString *> * _Nonnull)customNativeAdFormatIDsForAdLoader:(GADAdLoader * _Nonnull)adLoader;
        [Abstract]
        [Export("customNativeAdFormatIDsForAdLoader:")]
        string[] CustomNativeAdFormatIDsForAdLoader(AdLoader adLoader);

        // @required -(void)adLoader:(GADAdLoader * _Nonnull)adLoader didReceiveCustomNativeAd:(GADCustomNativeAd * _Nonnull)customNativeAd;
        [Abstract]
        [Export("adLoader:didReceiveCustomNativeAd:")]
        void AdLoader(AdLoader adLoader, NativeAd nativeAd);
    }

    // @protocol GADCustomNativeAdDelegate <GADAdLoaderDelegate>
    [Protocol, Model]
    [BaseType(typeof(NSObject), Name = "GADCustomNativeAdDelegate")]
    interface CustomNativeAdDelegate
    {
        // -(void)customNativeAdDidRecordImpression:(GADCustomNativeAd * _Nonnull)nativeAd;
        [EventArgs("NativeAd")]
        [EventName("ImpressionRecorded")]
        [Export("customNativeAdDidRecordImpression:")]
        void DidRecordImpression(CustomNativeAd nativeAd);

        // -(void)customNativeAdDidRecordClick:(GADCustomNativeAd * _Nonnull)nativeAd;
        [EventArgs("NativeAd")]
        [EventName("ClickRecorded")]
        [Export("customNativeAdDidRecordClick:")]
        void DidRecordClick(CustomNativeAd nativeAd);

        // -(void)customNativeAdWillPresentScreen:(GADCustomNativeAd * _Nonnull)nativeAd;
        [EventArgs("NativeAd")]
        [EventName("ScreenPresenting")]
        [Export("customNativeAdWillPresentScreen:")]
        void WillPresentScreen(CustomNativeAd nativeAd);

        // -(void)customNativeAdWillDismissScreen:(GADCustomNativeAd * _Nonnull)nativeAd;
        [EventArgs("NativeAd")]
        [EventName("ScreenDismissing")]
        [Export("customNativeAdWillDismissScreen:")]
        void WillDismissScreen(CustomNativeAd nativeAd);

        // -(void)customNativeAdDidDismissScreen:(GADCustomNativeAd * _Nonnull)nativeAd;
        [EventArgs("NativeAd")]
        [EventName("ScreenDismissed")]
        [Export("customNativeAdDidDismissScreen:")]
        void DidDismissScreen(CustomNativeAd nativeAd);
    }

    // @protocol GADDebugOptionsViewControllerDelegate<NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject), Name = "GADDebugOptionsViewControllerDelegate")]
    interface DebugOptionsViewControllerDelegate
    {
        // -(void)debugOptionsViewControllerDidDismiss:(GADDebugOptionsViewController * _Nonnull)controller;
        [Abstract]
        [EventArgs("DebugOptionsViewControllerDismissed")]
        [EventName("Dismissed")]
        [Export("debugOptionsViewControllerDidDismiss:")]
        void DidDismiss(DebugOptionsViewController controller);
    }

    // @interface GADDebugOptionsViewController : UIViewController
    [DisableDefaultCtor]
    [BaseType(typeof(UIViewController), 
        Name = "GADDebugOptionsViewController",
        Delegates = new string[] { "Delegate" },
        Events = new Type[] { typeof(DebugOptionsViewControllerDelegate) })]
    interface DebugOptionsViewController
    {
        // + (instancetype)debugOptionsViewControllerWithAdUnitID:(NSString*)adUnitID;
        [Static]
        [Export("debugOptionsViewControllerWithAdUnitID:")]
        DebugOptionsViewController GetInstance(string adUnitId);

        // @property(nonatomic, weak, GAD_NULLABLE) IBOutlet id<GADDebugOptionsViewControllerDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        IDebugOptionsViewControllerDelegate Delegate { get; set; }
    }

    interface IDebugOptionsViewControllerDelegate { }

    // @interface GADDynamicHeightSearchRequest : GADRequest
    [BaseType(typeof(Request), Name = "GADDynamicHeightSearchRequest")]
    interface DynamicHeightSearchRequest
    {
        // @property (copy, nonatomic) NSString * query;
        [NullAllowed, Export("query")]
        string Query { get; set; }

        // @property (assign, nonatomic) NSInteger adPage;
        [Export("adPage")]
        nint AdPage { get; set; }

        // @property (assign, nonatomic) BOOL adTestEnabled;
        [Export("adTestEnabled")]
        bool AdTestEnabled { get; set; }

        // @property (copy, nonatomic) NSString * channel;
        [NullAllowed, Export("channel")]
        string Channel { get; set; }

        // @property (copy, nonatomic) NSString * hostLanguage;
        [NullAllowed, Export("hostLanguage")]
        string HostLanguage { get; set; }

        // @property (copy, nonatomic) NSString * locationExtensionTextColor;
        [NullAllowed, Export("locationExtensionTextColor")]
        string LocationExtensionTextColor { get; set; }

        // @property (assign, nonatomic) CGFloat locationExtensionFontSize;
        [Export("locationExtensionFontSize")]
        nfloat LocationExtensionFontSize { get; set; }

        // @property (assign, nonatomic) BOOL clickToCallExtensionEnabled;
        [Export("clickToCallExtensionEnabled")]
        bool ClickToCallExtensionEnabled { get; set; }

        // @property (assign, nonatomic) BOOL locationExtensionEnabled;
        [Export("locationExtensionEnabled")]
        bool LocationExtensionEnabled { get; set; }

        // @property (assign, nonatomic) BOOL plusOnesExtensionEnabled;
        [Export("plusOnesExtensionEnabled")]
        bool PlusOnesExtensionEnabled { get; set; }

        // @property (assign, nonatomic) BOOL sellerRatingsExtensionEnabled;
        [Export("sellerRatingsExtensionEnabled")]
        bool SellerRatingsExtensionEnabled { get; set; }

        // @property (assign, nonatomic) BOOL siteLinksExtensionEnabled;
        [Export("siteLinksExtensionEnabled")]
        bool SiteLinksExtensionEnabled { get; set; }

        // @property (copy, nonatomic) NSString * CSSWidth;
        [NullAllowed, Export("CSSWidth")]
        string CssWidth { get; set; }

        // @property (assign, nonatomic) NSInteger numberOfAds;
        [Export("numberOfAds")]
        nint NumberOfAds { get; set; }

        // @property (copy, nonatomic) NSString * fontFamily;
        [Export("fontFamily")]
        string FontFamily { get; set; }

        // @property (copy, nonatomic) NSString * attributionFontFamily;
        [NullAllowed, Export("attributionFontFamily")]
        string AttributionFontFamily { get; set; }

        // @property (assign, nonatomic) CGFloat annotationFontSize;
        [Export("annotationFontSize")]
        nfloat AnnotationFontSize { get; set; }

        // @property (assign, nonatomic) CGFloat attributionFontSize;
        [Export("attributionFontSize")]
        nfloat AttributionFontSize { get; set; }

        // @property (assign, nonatomic) CGFloat descriptionFontSize;
        [Export("descriptionFontSize")]
        nfloat DescriptionFontSize { get; set; }

        // @property (assign, nonatomic) CGFloat domainLinkFontSize;
        [Export("domainLinkFontSize")]
        nfloat DomainLinkFontSize { get; set; }

        // @property (assign, nonatomic) CGFloat titleFontSize;
        [Export("titleFontSize")]
        nfloat TitleFontSize { get; set; }

        // @property (copy, nonatomic) NSString * adBorderColor;
        [NullAllowed, Export("adBorderColor")]
        string AdBorderColor { get; set; }

        // @property (copy, nonatomic) NSString * adSeparatorColor;
        [NullAllowed, Export("adSeparatorColor")]
        string AdSeparatorColor { get; set; }

        // @property (copy, nonatomic) NSString * annotationTextColor;
        [NullAllowed, Export("annotationTextColor")]
        string AnnotationTextColor { get; set; }

        // @property (copy, nonatomic) NSString * attributionTextColor;
        [NullAllowed, Export("attributionTextColor")]
        string AttributionTextColor { get; set; }

        // @property (copy, nonatomic) NSString * backgroundColor;
        [NullAllowed, Export("backgroundColor")]
        string BackgroundColor { get; set; }

        // @property (copy, nonatomic) NSString * borderColor;
        [NullAllowed, Export("borderColor")]
        string BorderColor { get; set; }

        // @property (copy, nonatomic) NSString * domainLinkColor;
        [NullAllowed, Export("domainLinkColor")]
        string DomainLinkColor { get; set; }

        // @property (copy, nonatomic) NSString * textColor;
        [NullAllowed, Export("textColor")]
        string TextColor { get; set; }

        // @property (copy, nonatomic) NSString * titleLinkColor;
        [NullAllowed, Export("titleLinkColor")]
        string TitleLinkColor { get; set; }

        // @property (copy, nonatomic) NSString * adBorderCSSSelections;
        [NullAllowed, Export("adBorderCSSSelections")]
        string AdBorderCssSelections { get; set; }

        // @property (assign, nonatomic) CGFloat adjustableLineHeight;
        [Export("adjustableLineHeight")]
        nfloat AdjustableLineHeight { get; set; }

        // @property (assign, nonatomic) CGFloat attributionBottomSpacing;
        [Export("attributionBottomSpacing")]
        nfloat AttributionBottomSpacing { get; set; }

        // @property (copy, nonatomic) NSString * borderCSSSelections;
        [NullAllowed, Export("borderCSSSelections")]
        string BorderCssSelections { get; set; }

        // @property (assign, nonatomic) BOOL titleUnderlineHidden;
        [Export("titleUnderlineHidden")]
        bool TitleUnderlineHidden { get; set; }

        // @property (assign, nonatomic) BOOL boldTitleEnabled;
        [Export("boldTitleEnabled")]
        bool BoldTitleEnabled { get; set; }

        // @property (assign, nonatomic) CGFloat verticalSpacing;
        [Export("verticalSpacing")]
        nfloat VerticalSpacing { get; set; }

        // @property (assign, nonatomic) BOOL detailedAttributionExtensionEnabled;
        [Export("detailedAttributionExtensionEnabled")]
        bool DetailedAttributionExtensionEnabled { get; set; }

        // @property (assign, nonatomic) BOOL longerHeadlinesExtensionEnabled;
        [Export("longerHeadlinesExtensionEnabled")]
        bool LongerHeadlinesExtensionEnabled { get; set; }

        // @property(nonatomic, copy, nullable) NSString *styleID;
        [NullAllowed, Export("styleID", ArgumentSemantic.Copy)]
        string StyleId { get; set; }

        // -(void)setAdvancedOptionValue:(id)value forKey:(NSString *)key;
        [Export("setAdvancedOptionValue:forKey:")]
        void SetAdvancedOptionValue(NSObject value, string key);
    }

    // @interface GADExtras : NSObject <GADAdNetworkExtras>
    [BaseType(typeof(NSObject), Name = "GADExtras")]
    interface Extras : AdNetworkExtras
    {
        // @property (copy, nonatomic) NSDictionary * _Nullable additionalParameters;
        [NullAllowed, Export("additionalParameters", ArgumentSemantic.Copy)]
        NSDictionary AdditionalParameters { get; set; }
    }


    // @interface GADAdapterStatus : NSObject <NSCopying>
    [BaseType(typeof(NSObject), Name = "GADAdapterStatus")]
    interface AdapterStatus : INSCopying
    {
        // @property (readonly, nonatomic) GADAdapterInitializationState state;
        [Export("state")]
        AdapterInitializationState State { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull description;
        [New]
        [Export("description")]
        string Description { get; }

        // @property (readonly, nonatomic) NSTimeInterval latency;
        [Export("latency")]
        double Latency { get; }
    }

    // @interface GADInitializationStatus : NSObject <NSCopying>
    [BaseType(typeof(NSObject), Name = "GADInitializationStatus")]
    interface InitializationStatus: INSCopying
    {
        // @property (readonly, nonatomic) NSDictionary<NSString *,GADAdapterStatus *> * _Nonnull adapterStatusesByClassName;
        [Export("adapterStatusesByClassName")]
        NSDictionary<NSString, AdapterStatus> AdapterStatusesByClassName { get; }
    }

    // @interface GADServerSideVerificationOptions : NSObject <NSCopying>
    [BaseType(typeof(NSObject), Name = "GADServerSideVerificationOptions")]
    interface ServerSideVerificationOptions : INSCopying
    {
        // @property (copy, nonatomic) NSString * _Nullable userIdentifier;
        [NullAllowed, Export("userIdentifier")]
        string UserIdentifier { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable customRewardString;
        [NullAllowed, Export("customRewardString")]
        string CustomRewardString { get; set; }
    }

    // typedef void (^GADInterstitialAdLoadCompletionHandler)(GADInterstitialAd * _Nullable, NSError * _Nullable);
    delegate void InterstitialAdLoadCompletionHandler([NullAllowed] InterstitialAd interstitialAd, [NullAllowed] NSError error);

    [DisableDefaultCtor]
    [BaseType(typeof(FullScreenPresentingAd), Name = "GADInterstitialAd")]
    interface InterstitialAd
    {
        // @property (readonly, nonatomic) NSString * _Nonnull adUnitID;
        [Export("adUnitID")]
        string AdUnitId { get; }

        // @property (readonly, nonatomic) int * _Nonnull responseInfo;
        [NullAllowed, Export("responseInfo")]
        ResponseInfo ResponseInfo { get; }

        // @property (copy, nonatomic) GADPaidEventHandler _Nullable paidEventHandler;
        [NullAllowed, Export("paidEventHandler", ArgumentSemantic.Copy)]
        PaidEventHandler PaidEventHandler { get; set; }

        // +(void)loadWithAdUnitID:(NSString * _Nonnull)adUnitID request:(id)request completionHandler:(GADInterstitialAdLoadCompletionHandler _Nonnull)completionHandler;
        [Async]
        [Static]
        [Export("loadWithAdUnitID:request:completionHandler:")]
        void Load(string adUnitId, [NullAllowed] Request request, InterstitialAdLoadCompletionHandler completionHandler);

        // -(BOOL)canPresentFromRootViewController:(UIViewController * _Nullable)rootViewController error:(NSError * _Nullable * _Nullable)error;
        [Export("canPresentFromRootViewController:error:")]
        bool CanPresent(UIViewController rootViewController, [NullAllowed] out NSError error);

        // -(void)presentFromRootViewController:(UIViewController * _Nullable)rootViewController;
        [Export("presentFromRootViewController:")]
        void Present([NullAllowed] UIViewController rootViewController);
    }

    [Static]
    interface MaxAdContentRatingConstants
    {
        // extern GADMaxAdContentRating  _Nonnull const GADMaxAdContentRatingGeneral;
        [Field("GADMaxAdContentRatingGeneral", "__Internal")]
        NSString General { get; }

        // extern GADMaxAdContentRating  _Nonnull const GADMaxAdContentRatingParentalGuidance;
        [Field("GADMaxAdContentRatingParentalGuidance", "__Internal")]
        NSString ParentalGuidance { get; }

        // extern GADMaxAdContentRating  _Nonnull const GADMaxAdContentRatingTeen;
        [Field("GADMaxAdContentRatingTeen", "__Internal")]
        NSString Teen { get; }

        // extern GADMaxAdContentRating  _Nonnull const GADMaxAdContentRatingMatureAudience;
        [Field("GADMaxAdContentRatingMatureAudience", "__Internal")]
        NSString MatureAudience { get; }
    }

    // @interface GADRequestConfiguration : NSObject
    [BaseType(typeof(NSObject), Name = "GADRequestConfiguration")]
    interface RequestConfiguration
    {
        // @property (copy, nonatomic) GADMaxAdContentRating _Nullable maxAdContentRating;
        [NullAllowed, Export("maxAdContentRating", ArgumentSemantic.Strong)]
        string MaxAdContentRating { get; set; }

        // @property (copy, nonatomic) NSArray<NSString *> * _Nullable testDeviceIdentifiers;
        [NullAllowed, Export("testDeviceIdentifiers", ArgumentSemantic.Copy)]
        string[] TestDeviceIdentifiers { get; set; }

        // @property (copy, nonatomic) NSNumber * _Nullable tagForUnderAgeOfConsent;
        [NullAllowed, Export("tagForUnderAgeOfConsent", ArgumentSemantic.Copy)]
        NSNumber TagForUnderAgeOfConsent { get; set; }

        // @property (copy, nonatomic) NSNumber * _Nullable tagForChildDirectedTreatment;
        [NullAllowed, Export("tagForChildDirectedTreatment", ArgumentSemantic.Copy)]
        NSNumber TagForChildDirectedTreatment { get; set; }

        // -(void)setPublisherFirstPartyIDEnabled:(BOOL)enabled;
        [Export("setPublisherFirstPartyIDEnabled:")]
        void SetPublisherFirstPartyIDEnabled(bool enabled);

        // @property (nonatomic) GADPublisherPrivacyPersonalizationState publisherPrivacyPersonalizationState;
        [Export("publisherPrivacyPersonalizationState", ArgumentSemantic.Assign)]
        PublisherPrivacyPersonalizationState PublisherPrivacyPersonalizationState { get; set; }
    }

    // typedef void (^GADInitializationCompletionHandler)(GADInitializationStatus * _Nonnull);
    delegate void InitializationCompletionHandler(InitializationStatus status);

    // typedef void (^GADAdInspectorCompletionHandler)(NSError * _Nullable);
    delegate void AdInspectorCompletionHandler(NSError error);

    // @interface GADMobileAds : NSObject
    [DisableDefaultCtor]
    [BaseType(typeof(NSObject), Name = "GADMobileAds")]
    interface MobileAds
    {
        // +(GADMobileAds * _Nonnull)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        MobileAds SharedInstance { get; }

        // @property (readonly, nonatomic) int versionNumber;
        [Export("versionNumber")]
        VersionNumber VersionNumber { get; }

        // @property (assign, nonatomic) float applicationVolume;
        [Export("applicationVolume")]
        float ApplicationVolume { get; set; }

        // @property (assign, nonatomic) BOOL applicationMuted;
        [Export("applicationMuted")]
        bool ApplicationMuted { get; set; }

        // @property (readonly, nonatomic, strong) GADAudioVideoManager * _Nonnull audioVideoManager;
        [Export("audioVideoManager", ArgumentSemantic.Strong)]
        AudioVideoManager AudioVideoManager { get; }

        // @property (readonly, nonatomic, strong) int * _Nonnull requestConfiguration;
        [Export("requestConfiguration", ArgumentSemantic.Strong)]
        RequestConfiguration RequestConfiguration { get; }

        // @property (readonly, nonatomic) GADInitializationStatus * _Nonnull initializationStatus;
        [Export("initializationStatus")]
        InitializationStatus InitializationStatus { get; }

        // -(BOOL)isSDKVersionAtLeastMajor:(NSInteger)major minor:(NSInteger)minor patch:(NSInteger)patch __attribute__((swift_name("isSDKVersionAtLeast(major:minor:patch:)")));
        [Export("isSDKVersionAtLeastMajor:minor:patch:")]
        bool IsSdkVersionAtLeast(nint major, nint minor, nint patch);

        // -(void)startWithCompletionHandler:(GADInitializationCompletionHandler _Nullable)completionHandler;
        [Async]
        [Export("startWithCompletionHandler:")]
        void Start([NullAllowed] InitializationCompletionHandler completionHandler);

        // -(void)disableSDKCrashReporting;
        [Export("disableSDKCrashReporting")]
        void DisableSdkCrashReporting();

        // -(void)disableMediationInitialization;
        [Export("disableMediationInitialization")]
        void DisableMediationInitialization();

        // - (void)presentAdInspectorFromViewController:(nonnull UIViewController *)viewController completionHandler: (nullable GADAdInspectorCompletionHandler)completionHandler;
        [Export("presentAdInspectorFromViewController:viewController:")]
        void PresentAdInspectorFromViewController(UIViewController viewConroller, AdInspectorCompletionHandler completionHandler);

        // -(void)registerWebView:(WKWebView * _Nonnull)webView;
        [Export("registerWebView:")]
        void RegisterWebView(WKWebView webView);
    }

    // @interface GADMultipleAdsAdLoaderOptions : GADAdLoaderOptions
    [BaseType(typeof(AdLoaderOptions), Name = "GADMultipleAdsAdLoaderOptions")]
    interface MultipleAdsAdLoaderOptions
    {
        // @property(nonatomic) NSInteger numberOfAds;
        [Export("numberOfAds")]
        nint NumberOfAds { get; set; }
    }

    // @interface GADMuteThisAdReason : NSObject
    [BaseType(typeof(NSObject), Name = "GADMuteThisAdReason")]
    interface MuteThisAdReason
    {
        // @property (readonly, nonatomic) NSString * _Nonnull reasonDescription;
        [Export("reasonDescription")]
        string ReasonDescription { get; }
    }

    // @protocol GADNativeAdDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject), Name = "GADNativeAdDelegate")]
    interface NativeAdDelegate
    {

        // @optional -(void)nativeAdDidRecordImpression:(GADNativeAd * _Nonnull)nativeAd;
        [EventArgs("NativeAd")]
        [EventName("ImpressionRecorded")]
        [Export("nativeAdDidRecordImpression:")]
        void DidRecordImpression(NativeAd nativeAd);

        // @optional -(void)nativeAdDidRecordClick:(GADNativeAd * _Nonnull)nativeAd;
        [EventArgs("NativeAd")]
        [EventName("ClickRecorded")]
        [Export("nativeAdDidRecordClick:")]
        void DidRecordClick(NativeAd nativeAd);

        // @optional -(void)nativeAdDidRecordSwipeGestureClick:(GADNativeAd * _Nonnull)nativeAd;
        [EventArgs("NativeAd")]
        [EventName("SwipeGestureClickRecorded")]
        [Export("nativeAdDidRecordSwipeGestureClick:")]
        void DidRecordSwipeGestureClick(NativeAd nativeAd);

        // @optional -(void)nativeAdWillPresentScreen:(GADNativeAd * _Nonnull)nativeAd;
        [EventArgs("NativeAd")]
        [Export("nativeAdWillPresentScreen:")]
        void WillPresentScreen(NativeAd nativeAd);

        // @optional -(void)nativeAdWillDismissScreen:(GADNativeAd * _Nonnull)nativeAd;
        [EventArgs("NativeAd")]
        [Export("nativeAdWillDismissScreen:")]
        void WillDismissScreen(NativeAd nativeAd);

        // @optional -(void)nativeAdDidDismissScreen:(GADNativeAd * _Nonnull)nativeAd;
        [EventArgs("NativeAd")]
        [EventName("ScreenDismissed")]
        [Export("nativeAdDidDismissScreen:")]
        void DidDismissScreen(NativeAd nativeAd);

        // @optional -(void)nativeAdIsMuted:(GADNativeAd * _Nonnull)nativeAd;
        [EventArgs("NativeAd")]
        [Export("nativeAdIsMuted:")]
        void IsMuted(NativeAd nativeAd);
    }

    interface INativeAdDelegate { }

    interface INativeAdUnconfirmedClickDelegate { }

    // @interface GADNativeAd : NSObject
    [BaseType(typeof(NSObject), Name = "GADNativeAd",
        Delegates = new[] { "Delegate", "UnconfirmedClickDelegate" },
        Events = new[] { typeof(NativeAdDelegate), typeof(NativeAdUnconfirmedClickDelegate) })]
    interface NativeAd
    {
        // @property (readonly, copy, nonatomic) NSString * _Nullable headline;
        [NullAllowed, Export("headline")]
        string Headline { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable callToAction;
        [NullAllowed, Export("callToAction")]
        string CallToAction { get; }

        // @property (readonly, nonatomic, strong) int * _Nullable icon;
        [NullAllowed, Export("icon", ArgumentSemantic.Strong)]
        NativeAdImage Icon { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable body;
        [NullAllowed, Export("body")]
        string Body { get; }

        // @property (readonly, nonatomic, strong) NSArray * _Nullable images;
        [NullAllowed, Export("images", ArgumentSemantic.Strong)]
        NativeAdImage[] Images { get; }

        // @property (readonly, copy, nonatomic) NSDecimalNumber * _Nullable starRating;
        [NullAllowed, Export("starRating", ArgumentSemantic.Copy)]
        NSDecimalNumber StarRating { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable store;
        [NullAllowed, Export("store")]
        string Store { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable price;
        [NullAllowed, Export("price")]
        string Price { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable advertiser;
        [NullAllowed, Export("advertiser")]
        string Advertiser { get; }

        // @property (readonly, nonatomic) GADMediaContent * _Nonnull mediaContent;
        [Export("mediaContent")]
        MediaContent MediaContent { get; }

        // @property (nonatomic, weak) id<GADCustomNativeAdDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        INativeAdDelegate Delegate { get; set; }

        // @property (nonatomic, weak) UIViewController * _Nullable rootViewController;
        [NullAllowed, Export("rootViewController", ArgumentSemantic.Weak)]
        UIViewController RootViewController { get; set; }

        // @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable extraAssets;
        [NullAllowed, Export("extraAssets", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> ExtraAssets { get; }

        // @property (readonly, nonatomic) int * _Nonnull responseInfo;
        [Export("responseInfo")]
        ResponseInfo ResponseInfo { get; }

        // @property (copy, nonatomic) GADPaidEventHandler _Nullable paidEventHandler;
        [NullAllowed, Export("paidEventHandler", ArgumentSemantic.Copy)]
        PaidEventHandler PaidEventHandler { get; set; }

        // @property (readonly, getter = isCustomMuteThisAdAvailable, nonatomic) BOOL customMuteThisAdAvailable;
        [Export("isCustomMuteThisAdAvailable")]
        bool IsCustomMuteThisAdAvailable { get; }

        // @property (readonly, nonatomic) NSArray<GADMuteThisAdReason *> * _Nullable muteThisAdReasons;
        [NullAllowed, Export("muteThisAdReasons")]
        MuteThisAdReason[] MuteThisAdReasons { get; }

        // -(void)registerAdView:(UIView * _Nonnull)adView clickableAssetViews:(NSDictionary * _Nonnull)clickableAssetViews nonclickableAssetViews:(NSDictionary * _Nonnull)nonclickableAssetViews;
        [Export("registerAdView:clickableAssetViews:nonclickableAssetViews:")]
        void RegisterAdView(UIView adView, NSDictionary<NSString, UIView> clickableAssetViews, NSDictionary<NSString, UIView> nonclickableAssetViews);

        [Wrap("RegisterAdView (adView, NSDictionary<NSString, UIView>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (clickableAssetViews.Values), System.Linq.Enumerable.ToArray (clickableAssetViews.Keys), clickableAssetViews.Keys.Count), NSDictionary<NSString, UIView>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (nonclickableAssetViews.Values), System.Linq.Enumerable.ToArray (nonclickableAssetViews.Keys), nonclickableAssetViews.Keys.Count))")]
        void RegisterAdView(UIView adView, Dictionary<string, UIView> clickableAssetViews, Dictionary<string, UIView> nonclickableAssetViews);

        // -(void)unregisterAdView;
        [Export("unregisterAdView")]
        void UnregisterAdView();

        // -(void)muteThisAdWithReason:(GADMuteThisAdReason * _Nullable)reason;
        [Export("muteThisAdWithReason:")]
        void MuteThisAd(MuteThisAdReason reason);

        ///
        /// From NativeAd_ConfirmedClick Category
        ///

        // @property (nonatomic, weak) id<GADNativeAdUnconfirmedClickDelegate> _Nullable unconfirmedClickDelegate;
        [NullAllowed, Export("unconfirmedClickDelegate", ArgumentSemantic.Weak)]
        INativeAdUnconfirmedClickDelegate UnconfirmedClickDelegate { get; set; }

        // -(void)registerClickConfirmingView:(UIView * _Nullable)view;
        [Export("registerClickConfirmingView:")]
        void RegisterClickConfirmingView([NullAllowed] UIView view);

        // -(void)cancelUnconfirmedClick;
        [Export("cancelUnconfirmedClick")]
        void CancelUnconfirmedClick();

        ///
        /// From NativeAd_CustomClickGesture Category
        ///

        // @property (readonly, getter = isCustomClickGestureEnabled, nonatomic) BOOL customClickGestureEnabled;
        [Export("customClickGestureEnabled")]
        bool CustomClickGestureEnabled { [Bind("isCustomClickGestureEnabled")] get; }

        // -(void)enableCustomClickGestures;
        [Export("enableCustomClickGestures")]
        void EnableCustomClickGestures();

        // -(void)recordCustomClickGesture;
        [Export("recordCustomClickGesture")]
        void RecordCustomClickGesture();
    }

    // @protocol GADNativeAdLoaderDelegate <GADAdLoaderDelegate>
    [Protocol, Model]
    [BaseType(typeof(NSObject), Name = "GADNativeAdLoaderDelegate")]
    interface NativeAdLoaderDelegate : AdLoaderDelegate
    {
        // @required -(void)adLoader:(GADAdLoader * _Nonnull)adLoader didReceiveNativeAd:(GADNativeAd * _Nonnull)nativeAd;
        [Abstract]
        [Export("adLoader:didReceiveNativeAd:")]
        void DidReceiveNativeAd(AdLoader adLoader, NativeAd nativeAd);
    }

    // @interface GADNativeAdView : UIView
    [BaseType(typeof(UIView), Name = "GADNativeAdView")]
    interface NativeAdView
    {
        // @property (nonatomic, strong) GADNativeAd * _Nullable nativeAd;
        [NullAllowed, Export("nativeAd", ArgumentSemantic.Strong)]
        NativeAd NativeAd { get; set; }

        // @property (nonatomic, weak) UIView * _Nullable headlineView __attribute__((iboutlet));
        [NullAllowed, Export("headlineView", ArgumentSemantic.Weak)]
        UIView HeadlineView { get; set; }

        // @property (nonatomic, weak) UIView * _Nullable callToActionView __attribute__((iboutlet));
        [NullAllowed, Export("callToActionView", ArgumentSemantic.Weak)]
        UIView CallToActionView { get; set; }

        // @property (nonatomic, weak) UIView * _Nullable iconView __attribute__((iboutlet));
        [NullAllowed, Export("iconView", ArgumentSemantic.Weak)]
        UIView IconView { get; set; }

        // @property (nonatomic, weak) UIView * _Nullable bodyView __attribute__((iboutlet));
        [NullAllowed, Export("bodyView", ArgumentSemantic.Weak)]
        UIView BodyView { get; set; }

        // @property (nonatomic, weak) UIView * _Nullable storeView __attribute__((iboutlet));
        [NullAllowed, Export("storeView", ArgumentSemantic.Weak)]
        UIView StoreView { get; set; }

        // @property (nonatomic, weak) UIView * _Nullable priceView __attribute__((iboutlet));
        [NullAllowed, Export("priceView", ArgumentSemantic.Weak)]
        UIView PriceView { get; set; }

        // @property (nonatomic, weak) UIView * _Nullable imageView __attribute__((iboutlet));
        [NullAllowed, Export("imageView", ArgumentSemantic.Weak)]
        UIView ImageView { get; set; }

        // @property (nonatomic, weak) UIView * _Nullable starRatingView __attribute__((iboutlet));
        [NullAllowed, Export("starRatingView", ArgumentSemantic.Weak)]
        UIView StarRatingView { get; set; }

        // @property (nonatomic, weak) UIView * _Nullable advertiserView __attribute__((iboutlet));
        [NullAllowed, Export("advertiserView", ArgumentSemantic.Weak)]
        UIView AdvertiserView { get; set; }

        // @property (nonatomic, weak) GADMediaView * _Nullable mediaView __attribute__((iboutlet));
        [NullAllowed, Export("mediaView", ArgumentSemantic.Weak)]
        MediaView MediaView { get; set; }

        // @property (nonatomic, weak) GADAdChoicesView * _Nullable adChoicesView __attribute__((iboutlet));
        [NullAllowed, Export("adChoicesView", ArgumentSemantic.Weak)]
        AdChoicesView AdChoicesView { get; set; }
    }

    // @protocol GADNativeAdUnconfirmedClickDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject), Name = "GADNativeAdUnconfirmedClickDelegate")]
    interface NativeAdUnconfirmedClickDelegate
    {
        // @required -(void)nativeAd:(GADNativeAd * _Nonnull)nativeAd didReceiveUnconfirmedClickOnAssetID:(GADNativeAssetIdentifier _Nonnull)assetID;
        [EventArgs("NativeAdUnconfirmedClickReceived")]
        [EventName("UnconfirmedClickReceived")]
        [Abstract]
        [Export("nativeAd:didReceiveUnconfirmedClickOnAssetID:")]
        void DidReceiveUnconfirmedClick(NativeAd nativeAd, string assetId);

        // @required -(void)nativeAdDidCancelUnconfirmedClick:(GADNativeAd * _Nonnull)nativeAd;
        [EventArgs("NativeAdUnconfirmedClickCancelled")]
        [EventName("UnconfirmedClickCancelled")]
        [Abstract]
        [Export("nativeAdDidCancelUnconfirmedClick:")]
        void DidCancelUnconfirmedClick(NativeAd nativeAd);
    }

    // @interface GADNativeAdCustomClickGestureOptions : GADAdLoaderOptions
    [BaseType(typeof(AdLoaderOptions), Name = "GADNativeAdCustomClickGestureOptions")]
    [DisableDefaultCtor]
    interface NativeAdCustomClickGestureOptions
    {
        // @property (assign, nonatomic) UISwipeGestureRecognizerDirection swipeGestureDirection;
        [Export("swipeGestureDirection", ArgumentSemantic.Assign)]
        UISwipeGestureRecognizerDirection SwipeGestureDirection { get; set; }

        // @property (assign, nonatomic) BOOL tapsAllowed;
        [Export("tapsAllowed")]
        bool TapsAllowed { get; set; }

        // -(instancetype _Nonnull)initWithSwipeGestureDirection:(UISwipeGestureRecognizerDirection)direction tapsAllowed:(BOOL)tapsAllowed __attribute__((objc_designated_initializer));
        [Export("initWithSwipeGestureDirection:tapsAllowed:")]
        [DesignatedInitializer]
        NativeHandle Constructor(UISwipeGestureRecognizerDirection direction, bool tapsAllowed);
    }
    
    // @interface GADNativeAdImageAdLoaderOptions : GADAdLoaderOptions
    [BaseType(typeof(AdLoaderOptions), Name = "GADNativeAdImageAdLoaderOptions")]
    interface NativeAdImageAdLoaderOptions
    {
        // @property (assign, nonatomic) BOOL disableImageLoading;
        [Export("disableImageLoading")]
        bool DisableImageLoading { get; set; }

        // @property (assign, nonatomic) BOOL shouldRequestMultipleImages;
        [Export("shouldRequestMultipleImages")]
        bool ShouldRequestMultipleImages { get; set; }
    }

    // @interface GADNativeAdMediaAdLoaderOptions : GADAdLoaderOptions
    [BaseType(typeof(AdLoaderOptions), Name = "GADNativeAdMediaAdLoaderOptions")]
    interface NativeAdMediaAdLoaderOptions
    {
        // @property (assign, nonatomic) GADMediaAspectRatio mediaAspectRatio;
        [Export("mediaAspectRatio", ArgumentSemantic.Assign)]
        MediaAspectRatio MediaAspectRatio { get; set; }
    }

    // @interface GADNativeAdViewAdOptions : GADAdLoaderOptions
    [BaseType(typeof(AdLoaderOptions), Name = "GADNativeAdViewAdOptions")]
    interface NativeAdViewAdOptions
    {
        // @property (assign, nonatomic) GADAdChoicesPosition preferredAdChoicesPosition;
        [Export("preferredAdChoicesPosition", ArgumentSemantic.Assign)]
        AdChoicesPosition PreferredAdChoicesPosition { get; set; }
    }

    // @interface GADNativeMuteThisAdLoaderOptions : GADAdLoaderOptions
    [BaseType(typeof(AdLoaderOptions), Name = "GADNativeMuteThisAdLoaderOptions")]
    interface NativeMuteThisAdLoaderOptions
    {
        // @property (nonatomic) BOOL customMuteThisAdRequested;
        [Export("customMuteThisAdRequested", ArgumentSemantic.Assign)]
        bool CustomMuteThisAdRequested { get; set; }
    }

    // typedef void (^GADQueryInfoCreationCompletionHandler)(GADQueryInfo * _Nullable, NSError * _Nullable);
    delegate void QueryInfoCreationCompletionHandler([NullAllowed] QueryInfo queryInfo, [NullAllowed] NSError error);

    // @interface GADQueryInfo : NSObject
    [BaseType(typeof(NSObject), Name = "GADQueryInfo")]
    interface QueryInfo
    {
        // @property (readonly, nonatomic) NSString * _Nonnull query;
        [Export("query")]
        string Query { get; }

        // +(void)createQueryInfoWithRequest:(id)request adFormat:(GADAdFormat)adFormat completionHandler:(GADQueryInfoCreationCompletionHandler _Nonnull)completionHandler;
        [Static]
        [Export("createQueryInfoWithRequest:adFormat:completionHandler:")]
        void CreateQueryInfoWithRequest(NSObject request, AdFormat adFormat, QueryInfoCreationCompletionHandler completionHandler);

        // +(void)createQueryInfoWithRequest:(id)request adFormat:(GADAdFormat)adFormat adUnitID:(NSString * _Nonnull)adUnitID completionHandler:(GADQueryInfoCreationCompletionHandler _Nonnull)completionHandler;
        [Static]
        [Export("createQueryInfoWithRequest:adFormat:adUnitID:completionHandler:")]
        void CreateQueryInfoWithRequest(NSObject request, AdFormat adFormat, string adUnitID, QueryInfoCreationCompletionHandler completionHandler);
    }

    // typedef void (^GADRewardedAdLoadCompletionHandler)(GADRewardedAd * _Nullable, NSError * _Nullable);
    delegate void RewardedAdLoadCompletionHandler([NullAllowed] RewardedAd rewardedAd, [NullAllowed] NSError error);

    // @interface GADRewardedAd : NSObject <GADAdMetadataProvider, GADFullScreenPresentingAd>
    [BaseType(typeof(FullScreenPresentingAd), Name = "GADRewardedAd")]
    interface RewardedAd : AdMetadataProvider
    {
        // extern NSString *const _Nonnull GADErrorDomain;
        [Field("GADErrorDomain", "__Internal")]
        NSString ErrorDomain { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull adUnitID;
        [Export("adUnitID")]
        string AdUnitId { get; }

        // @property (readonly, nonatomic) GADResponseInfo * _Nonnull responseInfo;
        [NullAllowed, Export("responseInfo")]
        ResponseInfo ResponseInfo { get; }

        // @property (readonly, nonatomic) GADAdReward * _Nonnull adReward;
        [Export("adReward")]
        AdReward AdReward { get; }

        // @property (nonatomic, nullable) GADServerSideVerificationOptions *serverSideVerificationOptions;
        [NullAllowed, Export("serverSideVerificationOptions")]
        ServerSideVerificationOptions ServerSideVerificationOptions { get; set; }

        // @property (copy, nonatomic) GADPaidEventHandler _Nullable paidEventHandler;
        [NullAllowed, Export("paidEventHandler", ArgumentSemantic.Copy)]
        PaidEventHandler PaidEventHandler { get; set; }

        // +(void)loadWithAdUnitID:(NSString * _Nonnull)adUnitID request:(GADRequest * _Nullable)request completionHandler:(GADRewardedAdLoadCompletionHandler _Nonnull)completionHandler;
        [Async]
        [Static]
        [Export("loadWithAdUnitID:request:completionHandler:")]
        void Load(string adUnitId, [NullAllowed] Request request, RewardedAdLoadCompletionHandler completionHandler);

        // -(BOOL)canPresentFromRootViewController:(UIViewController * _Nullable)rootViewController error:(NSError * _Nullable * _Nullable)error;
        [Export("canPresentFromRootViewController:error:")]
        bool CanPresent(UIViewController rootViewController, [NullAllowed] out NSError error);

        // -(void)presentFromRootViewController:(UIViewController * _Nullable)rootViewController userDidEarnRewardHandler:(GADUserDidEarnRewardHandler _Nonnull)userDidEarnRewardHandler;
        [Export("presentFromRootViewController:userDidEarnRewardHandler:")]
        void Present(UIViewController viewController, UserDidEarnRewardHandler userDidEarnRewardHandler);
    }

    // typedef void (^GADRewardedInterstitialAdLoadCompletionHandler)(GADRewardedInterstitialAd * _Nullable, NSError * _Nullable);
    delegate void RewardedInterstitialAdLoadCompletionHandler([NullAllowed] RewardedInterstitialAd rewardedInterstitialAd, [NullAllowed] NSError error);

    // @interface GADRewardedInterstitialAd : NSObject <GADAdMetadataProvider, GADFullScreenPresentingAd>
    [BaseType(typeof(FullScreenContentDelegate), Name = "GADRewardedInterstitialAd")]
    interface RewardedInterstitialAd : AdMetadataProvider
    {
        // @property (readonly, nonatomic) NSString * _Nonnull adUnitID;
        [Export("adUnitID")]
        string AdUnitId { get; }

        // @property (readonly, nonatomic) GADResponseInfo * _Nonnull responseInfo;
        [NullAllowed, Export("responseInfo")]
        ResponseInfo ResponseInfo { get; }

        // @property (readonly, nonatomic) GADAdReward * _Nonnull adReward;
        [NullAllowed, Export("adReward")]
        AdReward AdReward { get; }

        // @property (nonatomic, nullable) GADServerSideVerificationOptions *serverSideVerificationOptions;
        [NullAllowed, Export("serverSideVerificationOptions")]
        ServerSideVerificationOptions ServerSideVerificationOptions { get; set; }

        // @property (copy, nonatomic) GADPaidEventHandler _Nullable paidEventHandler;
        [NullAllowed, Export("paidEventHandler", ArgumentSemantic.Copy)]
        PaidEventHandler PaidEventHandler { get; set; }

        // +(void)loadWithAdUnitID:(NSString * _Nonnull)adUnitID request:(GADRequest * _Nullable)request completionHandler:(GADRewardedInterstitialAdLoadCompletionHandler _Nonnull)completionHandler;
        [Async]
        [Static]
        [Export("loadWithAdUnitID:request:completionHandler:")]
        void Load(string adUnitId, [NullAllowed] Request request, RewardedInterstitialAdLoadCompletionHandler completionHandler);

        // -(BOOL)canPresentFromRootViewController:(UIViewController * _Nonnull)rootViewController error:(NSError * _Nullable * _Nullable)error;
        [Export("canPresentFromRootViewController:error:")]
        bool CanPresent(UIViewController rootViewController, [NullAllowed] out NSError error);

        // -(void)presentFromRootViewController:(UIViewController * _Nullable)viewController userDidEarnRewardHandler:(GADUserDidEarnRewardHandler _Nonnull)userDidEarnRewardHandler;
        [Export("presentFromRootViewController:userDidEarnRewardHandler:")]
        void Present([NullAllowed] UIViewController viewController, UserDidEarnRewardHandler userDidEarnRewardHandler);
    }

    // @interface GADSearchBannerView : GADBannerView
    [BaseType(typeof(BannerView), Name = "GADSearchBannerView")]
    interface SearchBannerView
    {
        [Export("initWithFrame:")]
        NativeHandle Constructor(CGRect frame);

        [Export("initWithAdSize:origin:")]
        NativeHandle Constructor(AdSize size, CGPoint origin);

        [Export("initWithAdSize:")]
        NativeHandle Constructor(AdSize size);
    }

    // @protocol GADVideoControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject), Name = "GADVideoControllerDelegate")]
    interface VideoControllerDelegate
    {
        // - (void)videoControllerDidPlayVideo:(GADVideoController *)videoController;
        [EventArgs("VideoControllerVideoPlayed")]
        [EventName("VideoPlayed")]
        [Export("videoControllerDidPlayVideo:")]
        void DidPlayVideo(VideoController videoController);

        // - (void)videoControllerDidPauseVideo:(GADVideoController *)videoController;
        [EventArgs("VideoControllerVideoPaused")]
        [EventName("VideoPaused")]
        [Export("videoControllerDidPauseVideo:")]
        void DidPauseVideo(VideoController videoController);

        // - (void)videoControllerDidEndVideoPlayback:(GADVideoController*)videoController;
        [EventArgs("VideoControllerVideoPlaybackEnded")]
        [EventName("VideoPlaybackEnded")]
        [Export("videoControllerDidEndVideoPlayback:")]
        void DidEndVideoPlayback(VideoController videoController);

        // - (void)videoControllerDidMuteVideo:(GADVideoController *)videoController;
        [EventArgs("VideoControllerVideoMuted")]
        [EventName("VideoMuted")]
        [Export("videoControllerDidMuteVideo:")]
        void DidMuteVideo(VideoController videoController);

        // - (void)videoControllerDidUnmuteVideo:(GADVideoController *)videoController;
        [EventArgs("VideoControllerVideoUnuted")]
        [EventName("VideoUnuted")]
        [Export("videoControllerDidUnmuteVideo:")]
        void DidUnmuteVideo(VideoController videoController);
    }

    // @interface GADVideoOptions : GADAdLoaderOptions
    [BaseType(typeof(AdLoaderOptions), Name = "GADVideoOptions")]
    interface VideoOptions
    {
        // @property(nonatomic, assign) BOOL startMuted;
        [Export("startMuted", ArgumentSemantic.Assign)]
        bool StartMuted { get; set; }

        // @property(nonatomic, assign) BOOL customControlsRequested;
        [Export("customControlsRequested", ArgumentSemantic.Assign)]
        bool CustomControlsRequested { get; set; }

        //@property(nonatomic, assign) BOOL clickToExpandRequested;
        [Export("clickToExpandRequested", ArgumentSemantic.Assign)]
        bool ClickToExpandRequested { get; set; }
    }

    interface IAppEventDelegate { }
}

namespace Maui.Google.MobileAds.Manager
{
    // @protocol GAMBannerAdLoaderDelegate<GADAdLoaderDelegate>
    [Protocol, Model]
    [BaseType(typeof(NSObject), Name = "GAMBannerAdLoaderDelegate")]
    interface BannerAdLoaderDelegate : AdLoaderDelegate
    {
        // @required -(NSArray<NSValue *> * _Nonnull)validBannerSizesForAdLoader:(GADAdLoader * _Nonnull)adLoader;
        [Abstract]
        [Export("validBannerSizesForAdLoader:")]
        NSValue[] ValidBannerSizes(AdLoader adLoader);

        // @required -(void)adLoader:(GADAdLoader * _Nonnull)adLoader didReceiveGAMBannerView:(GAMBannerView * _Nonnull)bannerView;
        [Abstract]
        [Export("adLoader:didReceiveGAMBannerView:")]
        void DidReceiveBannerView(AdLoader adLoader, BannerView bannerView);
    }

    [BaseType(typeof(Maui.Google.MobileAds.BannerView),
        Name = "GAMBannerView",
        Delegates = new string[] { "AppEventDelegate" },
        Events = new Type[] { typeof(AppEventDelegate) })]
    interface BannerView
    {
        // @property (copy, nonatomic) NSString * _Nullable adUnitID;
        [NullAllowed, Export("adUnitID", ArgumentSemantic.Copy)]
        string AdUnitID { get; set; }

        // @property (nonatomic, weak) id<GADAppEventDelegate> _Nullable appEventDelegate __attribute__((iboutlet));
        [NullAllowed, Export("appEventDelegate", ArgumentSemantic.Weak)]
        IAppEventDelegate AppEventDelegate { get; set; }

        // @property (copy, nonatomic) NSArray<NSValue *> * _Nullable validAdSizes;
        [NullAllowed, Export("validAdSizes", ArgumentSemantic.Copy)]
        NSValue[] ValidAdSizes { get; set; }

        // @property (nonatomic) BOOL enableManualImpressions;
        [Export("enableManualImpressions")]
        bool EnableManualImpressions { get; set; }

        // @property (readonly, nonatomic) GADVideoController * _Nonnull videoController;
        [Export("videoController")]
        VideoController VideoController { get; }

        // -(void)recordImpression;
        [Export("recordImpression")]
        void RecordImpression();

        // -(void)resize:(GADAdSize)size;
        [Export("resize:")]
        void Resize(AdSize size);

        // - (void)setAdOptions:(NSArray *)adOptions;
        [Export("setAdOptions:")]
        void SetAdOptions(AdLoaderOptions[] adOptions);

        [Export("initWithFrame:")]
        NativeHandle Constructor(CGRect frame);

        [Export("initWithAdSize:origin:")]
        NativeHandle Constructor(AdSize size, CGPoint origin);

        [Export("initWithAdSize:")]
        NativeHandle Constructor(AdSize size);
    }

    // @interface GAMBannerViewOptions : GADAdLoaderOptions
    [BaseType(typeof(AdLoaderOptions), Name = "GAMBannerViewOptions")]
    interface BannerViewOptions
    {
        // @property(nonatomic, assign) BOOL enableManualImpressions;
        [Export("enableManualImpressions", ArgumentSemantic.Assign)]
        bool EnableManualImpressions { get; set; }
    }

    [BaseType(typeof(Maui.Google.MobileAds.Request), Name = "GAMRequest")]
    interface Request
    {
        [NullAllowed, Export("publisherProvidedID")]
        string PublisherProvidedID { get; set; }

        [NullAllowed, Export("categoryExclusions", ArgumentSemantic.Copy)]
        string[] CategoryExclusions { get; set; }

        [New]
        [NullAllowed, Export("customTargeting", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSString> CustomTargeting { get; set; }
    }

    // typedef void (^GAMInterstitialAdLoadCompletionHandler)(GAMInterstitialAd * _Nullable, NSError * _Nullable);
    delegate void GamInterstitialAdLoadCompletionHandler([NullAllowed] InterstitialAd interstitialAd, [NullAllowed] NSError error);

    // @interface GAMInterstitialAd : GADInterstitialAd
    [DisableDefaultCtor]
    [BaseType(typeof(Maui.Google.MobileAds.InterstitialAd), Name = "GAMInterstitialAd",
        Delegates = new string[] { "AppEventDelegate" },
        Events = new Type[] { typeof(AppEventDelegate) })]
    interface InterstitialAd
    {
        // @property (nonatomic, weak) id<GADAppEventDelegate> _Nullable appEventDelegate;
        [NullAllowed, Export("appEventDelegate", ArgumentSemantic.Weak)]
        IAppEventDelegate AppEventDelegate { get; set; }

        // +(void)loadWithAdManagerAdUnitID:(NSString * _Nonnull)adUnitID request:(id)request completionHandler:(GAMInterstitialAdLoadCompletionHandler _Nonnull)completionHandler;
        [Async]
        [Static]
        [Export("loadWithAdManagerAdUnitID:request:completionHandler:")]
        void LoadWithAdManagerAdUnitID(string adUnitId, [NullAllowed] Request request, GamInterstitialAdLoadCompletionHandler completionHandler);
    }
}

namespace Maui.Google.MobileAds.Mediation
{
    [Protocol, Model]
    [BaseType(typeof(NSObject), Name = "GADMediationAdRequest")]
    interface MediationAdRequest
    {
        // @required -(NSString * _Nullable)publisherId;
        [Abstract]
        [NullAllowed, Export("publisherId")]
        string PublisherId { get; }

        // @required -(NSDictionary * _Nullable)credentials;
        [Abstract]
        [NullAllowed, Export("credentials")]
        NSDictionary Credentials { get; }

        // @required -(BOOL)testMode;
        [Abstract]
        [Export("testMode")]
        bool TestMode { get; }

        // @required -(id<GADAdNetworkExtras> _Nullable)networkExtras;
        [Abstract]
        [NullAllowed, Export("networkExtras")]
        AdNetworkExtras NetworkExtras { get; }

        // @required -(NSNumber * _Nullable)childDirectedTreatment;
        [Abstract]
        [NullAllowed, Export("childDirectedTreatment")]
        NSNumber ChildDirectedTreatment { get; }

        // @required -(GADMaxAdContentRating _Nullable)maxAdContentRating;
        [Abstract]
        [NullAllowed, Export("maxAdContentRating")]
        string MaxAdContentRating { get; }

        // @required -(NSNumber * _Nullable)underAgeOfConsent;
        [Abstract]
        [NullAllowed, Export("underAgeOfConsent")]
        NSNumber UnderAgeOfConsent { get; }

        // @required -(NSArray * _Nullable)userKeywords;
        [Abstract]
        [NullAllowed, Export("userKeywords")]
        NSObject[] UserKeywords { get; }
    }

    [Protocol, Model]
    [BaseType(typeof(MediationAdRequest), Name = "GADMAdNetworkConnector")]
    interface AdNetworkConnector
    {
        // @required -(UIViewController *)viewControllerForPresentingModalView;
        [Abstract]
        [Export("viewControllerForPresentingModalView")]
        UIViewController ViewControllerForPresentingModalView();

        // @required -(float)adVolume;
        [Abstract]
        [Export("adVolume")]
        float AdVolume { get; }

        // @required -(BOOL)adMuted;
        [Abstract]
        [Export("adMuted")]
        bool AdMuted { get; }

        // @required -(void)adapter:(id<GADMAdNetworkAdapter>)adapter didFailAd:(NSError *)error;
        [Abstract]
        [Export("adapter:didFailAd:")]
        void DidFail(AdNetworkAdapter adapter, NSError error);

        // @required -(void)adapter:(id<GADMAdNetworkAdapter>)adapter didReceiveAdView:(UIView *)view;
        [Abstract]
        [Export("adapter:didReceiveAdView:")]
        void DidReceive(AdNetworkAdapter adapter, UIView view);

        // @required -(void)adapterDidReceiveInterstitial:(id<GADMAdNetworkAdapter>)adapter;
        [Abstract]
        [Export("adapterDidReceiveInterstitial:")]
        void DidReceiveInterstitial(AdNetworkAdapter adapter);

        // @required -(void)adapter:(id<GADMAdNetworkAdapter>)adapter didReceiveMediatedUnifiedNativeAd:(id<GADMediatedUnifiedNativeAd>)mediatedUnifiedNativeAd;
        [Abstract]
        [Export("adapter:didReceiveMediatedUnifiedNativeAd:")]
        void DidReceiveMediatedUnifiedNativeAd(AdNetworkAdapter adapter, MediatedUnifiedNativeAd mediatedUnifiedNativeAd);

        // @required -(void)adapterDidGetAdClick:(id<GADMAdNetworkAdapter>)adapter;
        [Abstract]
        [Export("adapterDidGetAdClick:")]
        void DidGetAdClick(AdNetworkAdapter adapter);

        // @required -(void)adapterWillPresentFullScreenModal:(id<GADMAdNetworkAdapter>)adapter;
        [Abstract]
        [Export("adapterWillPresentFullScreenModal:")]
        void WillPresent(AdNetworkAdapter adapter);

        // @required -(void)adapterWillDismissFullScreenModal:(id<GADMAdNetworkAdapter>)adapter;
        [Abstract]
        [Export("adapterWillDismissFullScreenModal:")]
        void WillDismiss(AdNetworkAdapter adapter);

        // @required -(void)adapterDidDismissFullScreenModal:(id<GADMAdNetworkAdapter>)adapter;
        [Abstract]
        [Export("adapterDidDismissFullScreenModal:")]
        void DidDismiss(AdNetworkAdapter adapter);

        // @required -(void)adapterWillPresentInterstitial:(id<GADMAdNetworkAdapter>)adapter;
        [Abstract]
        [Export("adapterWillPresentInterstitial:")]
        void WillPresentInterstitial(AdNetworkAdapter adapter);

        // @required -(void)adapterWillDismissInterstitial:(id<GADMAdNetworkAdapter>)adapter;
        [Abstract]
        [Export("adapterWillDismissInterstitial:")]
        void WillDismissInterstitial(AdNetworkAdapter adapter);

        // @required -(void)adapterDidDismissInterstitial:(id<GADMAdNetworkAdapter>)adapter;
        [Abstract]
        [Export("adapterDidDismissInterstitial:")]
        void DidDismissInterstitial(AdNetworkAdapter adapter);

        // @required -(void)adapter:(id<GADMAdNetworkAdapter>)adapter didReceiveInterstitial:(NSObject *)interstitial __attribute__((deprecated("Use -adapterDidReceiveInterstitial:.")));
        [Abstract]
        [Export("adapter:didReceiveInterstitial:")]
        void DidReceiveInterstitial(AdNetworkAdapter adapter, NSObject interstitial);

        // @required -(void)adapter:(id<GADMAdNetworkAdapter>)adapter clickDidOccurInBanner:(UIView *)view __attribute__((deprecated("Use -adapterDidGetAdClick:.")));
        [Abstract]
        [Export("adapter:clickDidOccurInBanner:")]
        void ClickDidOccur(AdNetworkAdapter adapter, UIView view);

        // @required -(void)adapter:(id<GADMAdNetworkAdapter>)adapter didFailInterstitial:(NSError *)error __attribute__((deprecated("Use -adapter:didFailAd:")));
        [Abstract]
        [Export("adapter:didFailInterstitial:")]
        void DidFailInterstitial(AdNetworkAdapter adapter, NSError error);

        // @required -(void)adapterWillLeaveApplication:(id<GADMAdNetworkAdapter>)adapter __attribute__((deprecated("Deprecated. No replacement.")));
        [Abstract]
        [Export("adapterWillLeaveApplication:")]
        void WillLeaveApplication(AdNetworkAdapter adapter);
    }

    [Protocol, Model]
    [BaseType(typeof(NSObject), Name = "GADMAdNetworkAdapter")]
    interface AdNetworkAdapter
    {
        // @required +(NSString *)adapterVersion;
        [Static, Abstract]
        [Export("adapterVersion")]
        string AdapterVersion { get; }

        // @required +(Class<GADAdNetworkExtras>)networkExtrasClass;
        [Static, Abstract]
        [Export("networkExtrasClass")]
        AdNetworkExtras NetworkExtrasClass { get; }

        // @required -(instancetype)initWithGADMAdNetworkConnector:(id<GADMAdNetworkConnector>)connector;
        [Export("initWithGADMAdNetworkConnector:")]
        NativeHandle Constructor(AdNetworkConnector connector);

        // @required -(void)getBannerWithSize:(GADAdSize)adSize;
        [Abstract]
        [Export("getBannerWithSize:")]
        void GetBanner(AdSize adSize);

        // @required -(void)getInterstitial;
        [Abstract]
        [Export("getInterstitial")]
        void GetInterstitial();

        // @required -(void)stopBeingDelegate;
        [Abstract]
        [Export("stopBeingDelegate")]
        void StopBeingDelegate();

        // @required -(void)presentInterstitialFromRootViewController:(UIViewController *)rootViewController;
        [Abstract]
        [Export("presentInterstitialFromRootViewController:")]
        void PresentInterstitial(UIViewController rootViewController);

        // @optional -(void)getNativeAdWithAdTypes:(NSArray<GADAdLoaderAdType> *)adTypes options:(NSArray<GADAdLoaderOptions *> *)options;
        [Export("getNativeAdWithAdTypes:options:")]
        void GetNativeAd(string[] adTypes, AdLoaderOptions[] options);

        // @optional -(BOOL)handlesUserClicks;
        [Export("handlesUserClicks")]
        bool HandlesUserClicks { get; }

        // @optional -(BOOL)handlesUserImpressions;
        [Export("handlesUserImpressions")]
        bool HandlesUserImpressions { get; }

        // @optional -(void)changeAdSizeTo:(GADAdSize)adSize;
        [Export("changeAdSizeTo:")]
        void ChangeAdSizeTo(AdSize adSize);
    }

    // @interface GADMediatedUnifiedNativeAdNotificationSource : NSObject
    [BaseType(typeof(NSObject), Name = "GADMediatedUnifiedNativeAdNotificationSource")]
    interface MediatedUnifiedNativeAdNotificationSource
    {
        // +(void)mediatedNativeAdDidRecordImpression:(id<GADMediatedUnifiedNativeAd> _Nonnull)mediatedNativeAd;
        [Static]
        [Export("mediatedNativeAdDidRecordImpression:")]
        void DidRecordImpression(MediatedUnifiedNativeAd mediatedNativeAd);

        // +(void)mediatedNativeAdDidRecordClick:(id<GADMediatedUnifiedNativeAd> _Nonnull)mediatedNativeAd;
        [Static]
        [Export("mediatedNativeAdDidRecordClick:")]
        void DidRecordClick(MediatedUnifiedNativeAd mediatedNativeAd);

        [Export("mediatedNativeAdWillPresentScreen:")]
        void WillPresentScreen(MediatedUnifiedNativeAd mediatedNativeAd);

        // +(void)mediatedNativeAdWillDismissScreen:(id<GADMediatedUnifiedNativeAd> _Nonnull)mediatedNativeAd;
        [Static]
        [Export("mediatedNativeAdWillDismissScreen:")]
        void WillDismissScreen(MediatedUnifiedNativeAd mediatedNativeAd);

        // +(void)mediatedNativeAdDidDismissScreen:(id<GADMediatedUnifiedNativeAd> _Nonnull)mediatedNativeAd;
        [Static]
        [Export("mediatedNativeAdDidDismissScreen:")]
        void DidDismissScreen(MediatedUnifiedNativeAd mediatedNativeAd);

        // +(void)mediatedNativeAdDidPlayVideo:(id<GADMediatedUnifiedNativeAd> _Nonnull)mediatedNativeAd;
        [Static]
        [Export("mediatedNativeAdDidPlayVideo:")]
        void DidPlayVideo(MediatedUnifiedNativeAd mediatedNativeAd);

        // +(void)mediatedNativeAdDidPauseVideo:(id<GADMediatedUnifiedNativeAd> _Nonnull)mediatedNativeAd;
        [Static]
        [Export("mediatedNativeAdDidPauseVideo:")]
        void DidPauseVideo(MediatedUnifiedNativeAd mediatedNativeAd);

        // +(void)mediatedNativeAdDidEndVideoPlayback:(id<GADMediatedUnifiedNativeAd> _Nonnull)mediatedNativeAd;
        [Static]
        [Export("mediatedNativeAdDidEndVideoPlayback:")]
        void DidEndVideoPlayback(MediatedUnifiedNativeAd mediatedNativeAd);
    }

    [Protocol, Model]
    [BaseType(typeof(NSObject), Name = "GADMediationAd")]
    interface MediationAd
    {
    }

    [BaseType(typeof(NSObject), Name = "GADMediationCredentials")]
    interface MediationCredentials
    {
        // @property (readonly, nonatomic) NSDictionary<NSString *,id> * _Nonnull settings;
        [Export("settings")]
        NSDictionary<NSString, NSObject> Settings { get; }

        // @property (readonly, nonatomic) GADAdFormat format;
        [Export("format")]
        AdFormat Format { get; }
    }

    // @interface GADMediationServerConfiguration : NSObject
    [BaseType(typeof(NSObject), Name = "GADMediationServerConfiguration")]
    interface MediationServerConfiguration
    {
        // @property (readonly, nonatomic) NSArray<GADMediationCredentials *> * _Nonnull credentials;
        [Export("credentials")]
        MediationCredentials[] Credentials { get; }
    }

    // @interface GADMediationAdConfiguration : NSObject
    [BaseType(typeof(NSObject), Name = "GADMediationAdConfiguration")]
    interface MediationAdConfiguration
    {
        // @property (readonly, nonatomic) NSString * _Nullable bidResponse;
        [NullAllowed, Export("bidResponse")]
        string BidResponse { get; }

        // @property (readonly, nonatomic) UIViewController * _Nullable topViewController;
        [NullAllowed, Export("topViewController")]
        UIViewController TopViewController { get; }

        // @property (readonly, nonatomic) GADMediationCredentials * _Nonnull credentials;
        [Export("credentials")]
        MediationCredentials Credentials { get; }

        // @property (readonly, nonatomic) NSData * _Nullable watermark;
        [NullAllowed, Export("watermark")]
        NSData Watermark { get; }

        // @property (readonly, nonatomic) id<GADAdNetworkExtras> _Nullable extras;
        [NullAllowed, Export("extras")]
        AdNetworkExtras Extras { get; }

        // @property (readonly, nonatomic) BOOL isTestRequest;
        [Export("isTestRequest")]
        bool IsTestRequest { get; }
    }

    // @protocol GADMediationAdEventDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject), Name = "GADMediationAdEventDelegate")]
    interface MediationAdEventDelegate
    {
        // @required -(void)reportImpression;
        [Abstract]
        [Export("reportImpression")]
        void ReportImpression();

        // @required -(void)reportClick;
        [Abstract]
        [Export("reportClick")]
        void ReportClick();

        // @required -(void)willPresentFullScreenView;
        [Abstract]
        [Export("willPresentFullScreenView")]
        void WillPresentFullScreenView();

        // @required -(void)didFailToPresentWithError:(NSError * _Nonnull)error;
        [Abstract]
        [Export("didFailToPresentWithError:")]
        void DidFailToPresentWithError(NSError error);

        // @required -(void)willDismissFullScreenView;
        [Abstract]
        [Export("willDismissFullScreenView")]
        void WillDismissFullScreenView();

        // @required -(void)didDismissFullScreenView;
        [Abstract]
        [Export("didDismissFullScreenView")]
        void DidDismissFullScreenView();
    }

    // @protocol GADMediationBannerAdEventDelegate <GADMediationAdEventDelegate>
    [Protocol, Model]
    [BaseType(typeof(MediationAdEventDelegate), Name = "GADMediationBannerAdEventDelegate")]
    interface MediationBannerAdEventDelegate
    {
    }

    // @protocol GADMediationInterstitialAdEventDelegate <GADMediationAdEventDelegate>
    [Protocol, Model]
    [BaseType(typeof(MediationAdEventDelegate), Name = "GADMediationInterstitialAdEventDelegate")]
    interface MediationInterstitialAdEventDelegate
    {
    }

    // @protocol GADMediationNativeAdEventDelegate <GADMediationAdEventDelegate>
    [Protocol, Model]
    [BaseType(typeof(MediationAdEventDelegate), Name = "GADMediationNativeAdEventDelegate")]
    interface MediationNativeAdEventDelegate
    {
        // @required -(void)didPlayVideo;
        [Abstract]
        [Export("didPlayVideo")]
        void DidPlayVideo();

        // @required -(void)didPauseVideo;
        [Abstract]
        [Export("didPauseVideo")]
        void DidPauseVideo();

        // @required -(void)didEndVideo;
        [Abstract]
        [Export("didEndVideo")]
        void DidEndVideo();

        // @required -(void)didMuteVideo;
        [Abstract]
        [Export("didMuteVideo")]
        void DidMuteVideo();

        // @required -(void)didUnmuteVideo;
        [Abstract]
        [Export("didUnmuteVideo")]
        void DidUnmuteVideo();
    }

    // @protocol GADMediationRewardedAdEventDelegate <GADMediationAdEventDelegate>
    [Protocol, Model]
    [BaseType(typeof(MediationAdEventDelegate), Name = "GADMediationRewardedAdEventDelegate")]
    interface MediationRewardedAdEventDelegate
    {
        // @required -(void)didRewardUser;
        [Abstract]
        [Export("didRewardUser")]
        void DidRewardUser();

        // @required -(void)didStartVideo;
        [Abstract]
        [Export("didStartVideo")]
        void DidStartVideo();

        // @required -(void)didEndVideo;
        [Abstract]
        [Export("didEndVideo")]
        void DidEndVideo();
    }

    // @protocol GADMediationAppOpenAdEventDelegate <GADMediationAdEventDelegate>
    [Protocol, Model]
    [BaseType(typeof(MediationAdEventDelegate), Name = "GADMediationAppOpenAdEventDelegate")]
    interface MediationAppOpenAdEventDelegate
    {
    }

    // @protocol GADMediationAppOpenAd <GADMediationAd>
    [Protocol, Model]
    [BaseType(typeof(MediationAd), Name = "GADMediationAppOpenAd")]
    interface MediationAppOpenAd
    {
        // @required -(void)presentFromViewController:(UIViewController * _Nonnull)viewController;
        [Abstract]
        [Export("presentFromViewController:")]
        void PresentFromViewController(UIViewController viewController);
    }

    // @interface GADMediationAppOpenAdConfiguration : GADMediationAdConfiguration
    [BaseType(typeof(MediationAdConfiguration), Name = "GADMediationAppOpenAdConfiguration")]
    interface MediationAppOpenAdConfiguration
    {
    }

    // @protocol GADMediationBannerAd <GADMediationAd>
    [Protocol, Model]
    [BaseType(typeof(MediationAd), Name = "GADMediationBannerAd")]
    interface MediationBannerAd
    {
        // @required @property (readonly, nonatomic) UIView * _Nonnull view;
        [Abstract]
        [Export("view")]
        UIView View { get; }

        // @optional -(void)changeAdSizeTo:(GADAdSize)adSize;
        [Export("changeAdSizeTo:")]
        void ChangeAdSizeTo(AdSize adSize);
    }

    // @protocol GADMediationInterscrollerAd <GADMediationBannerAd>
    [Protocol, Model]
    [BaseType(typeof(MediationBannerAd), Name = "GADMediationInterscrollerAd")]
    interface MediationInterscrollerAd
    {
        // @required @property (assign, nonatomic) BOOL delegateInterscrollerEffect;
        [Abstract]
        [Export("delegateInterscrollerEffect")]
        bool DelegateInterscrollerEffect { get; set; }
    }

    // @interface GADMediationBannerAdConfiguration : GADMediationAdConfiguration
    [BaseType(typeof(MediationAdConfiguration), Name = "GADMediationBannerAdConfiguration")]
    interface MediationBannerAdConfiguration
    {
        // @property (readonly, nonatomic) GADAdSize adSize;
        [Export("adSize")]
        AdSize AdSize { get; }
    }

    // @protocol GADMediationInterstitialAd <GADMediationAd>
    [Protocol, Model]
    [BaseType(typeof(MediationAd), Name = "GADMediationInterstitialAd")]
    interface MediationInterstitialAd
    {
        // @required -(void)presentFromViewController:(UIViewController * _Nonnull)viewController;
        [Abstract]
        [Export("presentFromViewController:")]
        void PresentFromViewController(UIViewController viewController);
    }

    // @interface GADMediationInterstitialAdConfiguration : GADMediationAdConfiguration
    [BaseType(typeof(MediationAdConfiguration), Name = "GADMediationInterstitialAdConfiguration")]
    interface MediationInterstitialAdConfiguration
    {
    }

    // @protocol GADMediationNativeAd <GADMediationAd, GADMediatedUnifiedNativeAd>
    [Protocol, Model]
    [BaseType(typeof(MediationAd), Name = "GADMediationNativeAd")]
    interface MediationNativeAd : MediatedUnifiedNativeAd
    {
        // @optional -(BOOL)handlesUserClicks;
        [Abstract]
        [Export("handlesUserClicks")]
        bool HandlesUserClicks();

        // @optional -(BOOL)handlesUserImpressions;
        [Abstract]
        [Export("handlesUserImpressions")]
        bool HandlesUserImpressions();
    }

    // @interface GADMediationNativeAdConfiguration : GADMediationAdConfiguration
    [BaseType(typeof(MediationAdConfiguration), Name = "GADMediationNativeAdConfiguration")]
    interface MediationNativeAdConfiguration
    {
        // @property (readonly, nonatomic) NSArray<GADAdLoaderOptions *> * _Nonnull options;
        [Export("options")]
        AdLoaderOptions[] Options { get; }
    }

    // @protocol GADMediationRewardedAd <GADMediationAd>
    [Protocol, Model]
    [BaseType(typeof(MediationAd), Name = "GADMediationRewardedAd")]
    interface MediationRewardedAd
    {
        // @required -(void)presentFromViewController:(UIViewController * _Nonnull)viewController;
        [Abstract]
        [Export("presentFromViewController:")]
        void PresentFromViewController(UIViewController viewController);
    }

    // @interface GADMediationRewardedAdConfiguration : GADMediationAdConfiguration
    [BaseType(typeof(MediationAdConfiguration), Name = "GADMediationRewardedAdConfiguration")]
    interface MediationRewardedAdConfiguration
    {
    }

    // typedef id<GADMediationBannerAdEventDelegate> _Nullable (^GADMediationBannerLoadCompletionHandler)(id<GADMediationBannerAd> _Nullable, NSError * _Nullable);
    delegate MediationBannerAdEventDelegate MediationBannerLoadCompletionHandler([NullAllowed] MediationBannerAd mediationBannerAd, [NullAllowed] NSError error);

    // typedef id<GADMediationBannerAdEventDelegate> _Nullable (^GADMediationInterscrollerAdLoadCompletionHandler)(id<GADMediationInterscrollerAd> _Nullable, NSError * _Nullable);
    delegate MediationBannerAdEventDelegate MediationInterscrollerAdLoadCompletionHandler([NullAllowed] MediationInterscrollerAd mediationInterscrollerAd, [NullAllowed] NSError error);

    // typedef id<GADMediationInterstitialAdEventDelegate> _Nullable (^GADMediationInterstitialLoadCompletionHandler)(id<GADMediationInterstitialAd> _Nullable, NSError * _Nullable);
    delegate MediationInterstitialAdEventDelegate MediationInterstitialLoadCompletionHandler([NullAllowed] MediationInterstitialAd mediationInterstitialAd, [NullAllowed] NSError error);

    // typedef id<GADMediationNativeAdEventDelegate> _Nullable (^GADMediationNativeLoadCompletionHandler)(id<GADMediationNativeAd> _Nullable, NSError * _Nullable);
    delegate MediationNativeAdEventDelegate MediationNativeLoadCompletionHandler([NullAllowed] MediationNativeAd mediationNativeAd, [NullAllowed] NSError error);

    // typedef id<GADMediationRewardedAdEventDelegate> _Nullable (^GADMediationRewardedLoadCompletionHandler)(id<GADMediationRewardedAd> _Nullable, NSError * _Nullable);
    delegate MediationRewardedAdEventDelegate MediationRewardedLoadCompletionHandler([NullAllowed] MediationRewardedAd mediationRewardedAd, [NullAllowed] NSError error);

    // typedef id<GADMediationAppOpenAdEventDelegate> _Nullable (^GADMediationAppOpenLoadCompletionHandler)(id<GADMediationAppOpenAd> _Nullable, NSError * _Nullable);
    delegate MediationAppOpenAdEventDelegate MediationAppOpenLoadCompletionHandler([NullAllowed] MediationAppOpenAd mediationAppOpenAd, [NullAllowed] NSError error);

    // typedef void (^GADMediationAdapterSetUpCompletionBlock)(NSError * _Nullable);
    delegate void MediationAdapterSetUpCompletionBlock([NullAllowed] NSError error);

    // @protocol GADMediationAdapter <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject), Name = "GADMediationAdapter")]
    interface MediationAdapter
    {
        // @required +(GADVersionNumber)adapterVersion;
        [Static, Abstract]
        [Export("adapterVersion")]
        VersionNumber AdapterVersion { get; }

        // @required +(GADVersionNumber)adSDKVersion;
        [Static, Abstract]
        [Export("adSDKVersion")]
        VersionNumber AdSDKVersion { get; }

        // @required +(Class<GADAdNetworkExtras> _Nullable)networkExtrasClass;
        [Static, Abstract]
        [NullAllowed, Export("networkExtrasClass")]
        AdNetworkExtras NetworkExtrasClass { get; }

        // @optional +(void)setUpWithConfiguration:(GADMediationServerConfiguration * _Nonnull)configuration completionHandler:(GADMediationAdapterSetUpCompletionBlock _Nonnull)completionHandler;
        [Static]
        [Export("setUpWithConfiguration:completionHandler:")]
        void SetUp(MediationServerConfiguration configuration, MediationAdapterSetUpCompletionBlock completionHandler);

        // @optional -(void)loadBannerForAdConfiguration:(GADMediationBannerAdConfiguration * _Nonnull)adConfiguration completionHandler:(GADMediationBannerLoadCompletionHandler _Nonnull)completionHandler;
        [Export("loadBannerForAdConfiguration:completionHandler:")]
        void LoadBanner(MediationBannerAdConfiguration adConfiguration, MediationBannerLoadCompletionHandler completionHandler);

        // @optional -(void)loadInterscrollerAdForAdConfiguration:(GADMediationBannerAdConfiguration * _Nonnull)adConfiguration completionHandler:(GADMediationInterscrollerAdLoadCompletionHandler _Nonnull)completionHandler;
        [Export("loadInterscrollerAdForAdConfiguration:completionHandler:")]
        void LoadInterscrollerAd(MediationBannerAdConfiguration adConfiguration, MediationInterscrollerAdLoadCompletionHandler completionHandler);

        // @optional -(void)loadInterstitialForAdConfiguration:(GADMediationInterstitialAdConfiguration * _Nonnull)adConfiguration completionHandler:(GADMediationInterstitialLoadCompletionHandler _Nonnull)completionHandler;
        [Export("loadInterstitialForAdConfiguration:completionHandler:")]
        void LoadInterstitial(MediationInterstitialAdConfiguration adConfiguration, MediationInterstitialLoadCompletionHandler completionHandler);

        // @optional -(void)loadNativeAdForAdConfiguration:(GADMediationNativeAdConfiguration * _Nonnull)adConfiguration completionHandler:(GADMediationNativeLoadCompletionHandler _Nonnull)completionHandler;
        [Export("loadNativeAdForAdConfiguration:completionHandler:")]
        void LoadNativeAd(MediationNativeAdConfiguration adConfiguration, MediationNativeLoadCompletionHandler completionHandler);

        // @optional -(void)loadRewardedAdForAdConfiguration:(GADMediationRewardedAdConfiguration * _Nonnull)adConfiguration completionHandler:(GADMediationRewardedLoadCompletionHandler _Nonnull)completionHandler;
        [Export("loadRewardedAdForAdConfiguration:completionHandler:")]
        void LoadRewardedAd(MediationRewardedAdConfiguration adConfiguration, MediationRewardedLoadCompletionHandler completionHandler);

        // @optional -(void)loadRewardedInterstitialAdForAdConfiguration:(GADMediationRewardedAdConfiguration * _Nonnull)adConfiguration completionHandler:(GADMediationRewardedLoadCompletionHandler _Nonnull)completionHandler;
        [Export("loadRewardedInterstitialAdForAdConfiguration:completionHandler:")]
        void LoadRewardedInterstitialAd(MediationRewardedAdConfiguration adConfiguration, MediationRewardedLoadCompletionHandler completionHandler);

        // @optional -(void)loadAppOpenAdForAdConfiguration:(GADMediationAppOpenAdConfiguration * _Nonnull)adConfiguration completionHandler:(GADMediationAppOpenLoadCompletionHandler _Nonnull)completionHandler;
        [Export("loadAppOpenAdForAdConfiguration:completionHandler:")]
        void LoadAppOpenAd(MediationAppOpenAdConfiguration adConfiguration, MediationAppOpenLoadCompletionHandler completionHandler);
    }
}

namespace Maui.Google.MobileAds.RTBMediation
{
    // @interface GADRTBMediationSignalsConfiguration : NSObject
    [BaseType(typeof(NSObject), Name = "GADRTBMediationSignalsConfiguration")]
    interface RTBMediationSignalsConfiguration
    {
        // @property (readonly, nonatomic) NSArray<GADMediationCredentials *> * _Nonnull credentials;
        [Export("credentials")]
        MediationCredentials[] Credentials { get; }
    }

    // @interface GADRTBRequestParameters : NSObject
    [BaseType(typeof(NSObject), Name = "GADRTBRequestParameters")]
    interface RTBRequestParameters
    {
        // @property (readonly, nonatomic) GADRTBMediationSignalsConfiguration * _Nonnull configuration;
        [Export("configuration")]
        RTBMediationSignalsConfiguration Configuration { get; }

        // @property (readonly, nonatomic) id<GADAdNetworkExtras> _Nullable extras;
        [NullAllowed, Export("extras")]
        AdNetworkExtras Extras { get; }

        // @property (readonly, nonatomic) GADAdSize adSize;
        [Export("adSize")]
        AdSize AdSize { get; }
    }

    // typedef void (^GADRTBSignalCompletionHandler)(NSString * _Nullable, NSError * _Nullable);
    delegate void RTBSignalCompletionHandler([NullAllowed] string arg, [NullAllowed] NSError error);

    // @protocol GADRTBAdapter <GADMediationAdapter>
    [Protocol, Model]
    [BaseType(typeof(MediationAdapter), Name = "GADRTBAdapter")]
    interface RTBAdapter
    {
        // @required -(void)collectSignalsForRequestParameters:(GADRTBRequestParameters * _Nonnull)params completionHandler:(GADRTBSignalCompletionHandler _Nonnull)completionHandler;
        [Abstract]
        [Export("collectSignalsForRequestParameters:completionHandler:")]
        void CompletionHandler(RTBRequestParameters @params, RTBSignalCompletionHandler completionHandler);
    }
}