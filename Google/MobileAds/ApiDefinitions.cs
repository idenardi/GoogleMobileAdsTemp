using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
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

        /// 
        /// From ServerToServer (GADAdLoader) category
        /// 

        // -(instancetype _Nonnull)initWithRootViewController:(UIViewController * _Nullable)rootViewController;
        [Export("initWithRootViewController:")]
        NativeHandle Constructor([NullAllowed] UIViewController rootViewController);

        // -(void)loadWithAdResponseString:(NSString * _Nonnull)adResponseString;
        [Export("loadWithAdResponseString:")]
        void LoadWithAdResponseString(string adResponseString);
    }

    interface IAdLoaderDelegate { }

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

    [Model]
    [Protocol]
    [BaseType(typeof(NSObject), Name = "GADAdNetworkExtras")]
    interface AdNetworkExtras
    {
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
        [Export("adView:didReceiveAppEvent:withInfo:")]
        void AdViewDidReceiveAppEvent(BannerView banner, string name, [NullAllowed] string info);

        // @optional -(void)interstitialAd:(GADInterstitialAd * _Nonnull)interstitialAd didReceiveAppEvent:(NSString * _Nonnull)name withInfo:(NSString * _Nullable)info;
        [Export("interstitial:didReceiveAppEvent:withInfo:")]
        void InterstitialDidReceiveAppEvent(InterstitialAd interstitial, string name, [NullAllowed] string info);
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
        void LoadWithAdUnitID(string adUnitId, [NullAllowed] Request request, UIInterfaceOrientation orientation, AppOpenAdLoadCompletionHandler completionHandler);

        // +(void)loadWithAdResponseString:(NSString * _Nonnull)adResponseString completionHandler:(GADAppOpenAdLoadCompletionHandler _Nonnull)completionHandler;
        [Static]
        [Export("loadWithAdResponseString:completionHandler:")]
        void LoadWithAdResponseString(string adResponseString, AppOpenAdLoadCompletionHandler completionHandler);

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

        // -(void)loadWithAdResponseString:(NSString * _Nonnull)adResponseString;
        [Export("loadWithAdResponseString:")]
        void LoadWithAdResponseString(string adResponseString);

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

    interface IBannerViewDelegate { }

    interface IAdSizeDelegate { }

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

    // typedef void (^GADNativeAdCustomClickHandler)(NSString* assetID);
    delegate void NativeAdCustomClickHandle(string assetId);

    // @interface GADCustomNativeAd : UIView
    [BaseType(typeof(UIView), Name = "GADCustomNativeAd")]
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
        void DidRecordImpression(NativeAd nativeAd);

        // -(void)customNativeAdDidRecordClick:(GADCustomNativeAd * _Nonnull)nativeAd;
        [EventArgs("NativeAd")]
        [EventName("ClickRecorded")]
        [Export("customNativeAdDidRecordClick:")]
        void DidRecordClick(NativeAd nativeAd);

        // -(void)customNativeAdWillPresentScreen:(GADCustomNativeAd * _Nonnull)nativeAd;
        [EventArgs("NativeAd")]
        [EventName("ScreenPresenting")]
        [Export("customNativeAdWillPresentScreen:")]
        void WillPresentScreen(NativeAd nativeAd);

        // -(void)customNativeAdWillDismissScreen:(GADCustomNativeAd * _Nonnull)nativeAd;
        [EventArgs("NativeAd")]
        [EventName("ScreenDismissing")]
        [Export("customNativeAdWillDismissScreen:")]
        void WillDismissScreen(NativeAd nativeAd);

        // -(void)customNativeAdDidDismissScreen:(GADCustomNativeAd * _Nonnull)nativeAd;
        [EventArgs("NativeAd")]
        [EventName("ScreenDismissed")]
        [Export("customNativeAdDidDismissScreen:")]
        void DidDismissScreen(NativeAd nativeAd);
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
    [BaseType(typeof(UIViewController), Name = "GADDebugOptionsViewController")]
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
        void LoadWithAdUnitID(string adUnitId, [NullAllowed] Request request, InterstitialAdLoadCompletionHandler completionHandler);

        // +(void)loadWithAdResponseString:(NSString * _Nonnull)adResponseString completionHandler:(GADInterstitialAdLoadCompletionHandler _Nonnull)completionHandler;
        [Static]
        [Export("loadWithAdResponseString:completionHandler:")]
        void LoadWithAdResponseString(string adResponseString, InterstitialAdLoadCompletionHandler completionHandler);

        // -(BOOL)canPresentFromRootViewController:(UIViewController * _Nullable)rootViewController error:(NSError * _Nullable * _Nullable)error;
        [Export("canPresentFromRootViewController:error:")]
        bool CanPresent(UIViewController rootViewController, [NullAllowed] out NSError error);

        // -(void)presentFromRootViewController:(UIViewController * _Nullable)rootViewController;
        [Export("presentFromRootViewController:")]
        void Present([NullAllowed] UIViewController rootViewController);
    }

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

    // typedef void (^GADInitializationCompletionHandler)(GADInitializationStatus * _Nonnull);
    delegate void InitializationCompletionHandler(InitializationStatus status);

    // typedef void (^GADAdInspectorCompletionHandler)(NSError * _Nullable);
    delegate void AdInspectorCompletionHandler(NSError error);

    // typedef void (^GADSignalCompletionHandler)(int * _Nullable, NSError * _Nullable);
    unsafe delegate void SignalCompletionHandler(int arg, NSError error);

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
        int VersionNumber { get; }

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

        // +(void)generateSignal:(id)request completionHandler:(GADSignalCompletionHandler _Nonnull)completionHandler;
        [Static]
        [Export("generateSignal:completionHandler:")]
        void GenerateSignal(NSObject request, SignalCompletionHandler completionHandler);
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

    interface INativeAdDelegate { }

    interface INativeAdLoaderDelegate { }

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

    interface INativeAdUnconfirmedClickDelegate { }

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
    }

    interface IAdNetworkExtras { }

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

        // extern NSString *const _Nonnull GADSimulatorID;
        [Field("GADSimulatorID", "__Internal")]
        NSString SimulatorID { get; }
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

    // typedef void (^GADRewardedAdLoadCompletionHandler)(GADRewardedAd * _Nullable, NSError * _Nullable);
    delegate void RewardedAdLoadCompletionHandler([NullAllowed] RewardedAd rewardedAd, [NullAllowed] NSError error);

    // @interface GADRewardedAd : NSObject <GADAdMetadataProvider, GADFullScreenPresentingAd>
    [BaseType(typeof(FullScreenPresentingAd), Name = "GADRewardedAd")]
    interface RewardedAd : AdMetadataProvider
    {
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
        void LoadWithAdUnitID(string adUnitId, [NullAllowed] Request request, RewardedAdLoadCompletionHandler completionHandler);

        // +(void)loadWithAdResponseString:(NSString * _Nonnull)adResponseString completionHandler:(GADRewardedAdLoadCompletionHandler _Nonnull)completionHandler;
        [Static]
        [Export("loadWithAdResponseString:completionHandler:")]
        void LoadWithAdResponseString(string adResponseString, RewardedAdLoadCompletionHandler completionHandler);

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
        void LoadWithAdUnitID(string adUnitId, [NullAllowed] Request request, RewardedInterstitialAdLoadCompletionHandler completionHandler);

        // +(void)loadWithAdResponseString:(NSString * _Nonnull)adResponseString completionHandler:(GADRewardedInterstitialAdLoadCompletionHandler _Nonnull)completionHandler;
        [Static]
        [Export("loadWithAdResponseString:completionHandler:")]
        void LoadWithAdResponseString(string adResponseString, RewardedInterstitialAdLoadCompletionHandler completionHandler);

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

        // @property (nonatomic, weak) id<GADAdSizeDelegate> _Nullable adSizeDelegate __attribute__((iboutlet));
        [New]
        [NullAllowed, Export("adSizeDelegate", ArgumentSemantic.Weak)]
        IAdSizeDelegate AdSizeDelegate { get; set; }
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
    interface BannerAdLoaderDelegate : Maui.Google.MobileAds.AdLoaderDelegate
    {
        // @required -(NSArray<NSValue *> * _Nonnull)validBannerSizesForAdLoader:(GADAdLoader * _Nonnull)adLoader;
        [Abstract]
        [Export("validBannerSizesForAdLoader:")]
        NSValue[] ValidBannerSizes(Maui.Google.MobileAds.AdLoader adLoader);

        // @required -(void)adLoader:(GADAdLoader * _Nonnull)adLoader didReceiveGAMBannerView:(GAMBannerView * _Nonnull)bannerView;
        [Abstract]
        [Export("adLoader:didReceiveGAMBannerView:")]
        void DidReceiveBannerView(Maui.Google.MobileAds.AdLoader adLoader, BannerView bannerView);
    }

    [BaseType(typeof(Maui.Google.MobileAds.BannerView),
        Name = "GAMBannerView",
        Delegates = new string[] { "AdSizeDelegate" },
        Events = new Type[] { typeof(AdSizeDelegate) })]
    interface BannerView
    {
        // @property (copy, nonatomic) NSString * _Nullable adUnitID;
        [NullAllowed, Export("adUnitID", ArgumentSemantic.Copy)]
        string AdUnitID { get; set; }

        // @property (nonatomic, weak) id<GADAppEventDelegate> _Nullable appEventDelegate __attribute__((iboutlet));
        [NullAllowed, Export("appEventDelegate", ArgumentSemantic.Weak)]
        IAppEventDelegate AppEventDelegate { get; set; }

        // @property (nonatomic, weak) id<GADAdSizeDelegate> _Nullable adSizeDelegate __attribute__((iboutlet));
        [New]
        [NullAllowed, Export("adSizeDelegate", ArgumentSemantic.Weak)]
        AdSizeDelegate AdSizeDelegate { get; set; }

        // @property (copy, nonatomic) NSArray<NSValue *> * _Nullable validAdSizes;
        [NullAllowed, Export("validAdSizes", ArgumentSemantic.Copy)]
        NSValue[] ValidAdSizes { get; set; }

        // @property (nonatomic) BOOL enableManualImpressions;
        [Export("enableManualImpressions")]
        bool EnableManualImpressions { get; set; }

        // @property (readonly, nonatomic) GADVideoController * _Nonnull videoController;
        [Export("videoController")]
        Maui.Google.MobileAds.VideoController VideoController { get; }

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

    interface IAdSizeDelegate { }

    // @interface GAMBannerViewOptions : GADAdLoaderOptions
    [BaseType(typeof(AdLoaderOptions), Name = "GAMBannerViewOptions")]
    interface BannerViewOptions
    {
        // @property(nonatomic, assign) BOOL enableManualImpressions;
        [Export("enableManualImpressions", ArgumentSemantic.Assign)]
        bool EnableManualImpressions { get; set; }
    }

    // @interface GAMInterstitialAd : GADInterstitialAd
    [DisableDefaultCtor]
    [BaseType(typeof(Maui.Google.MobileAds.InterstitialAd), Name = "GAMInterstitialAd")]
    interface InterstitialAd
    {
        // @property (nonatomic, weak) id<GADAppEventDelegate> _Nullable appEventDelegate;
        [NullAllowed, Export("appEventDelegate", ArgumentSemantic.Weak)]
        Maui.Google.MobileAds.IAppEventDelegate AppEventDelegate { get; set; }

        // +(void)loadWithAdManagerAdUnitID:(NSString * _Nonnull)adUnitID request:(id)request completionHandler:(GAMInterstitialAdLoadCompletionHandler _Nonnull)completionHandler;
        [Async]
        [Static]
        [Export("loadWithAdManagerAdUnitID:request:completionHandler:")]
        void LoadWithAdManagerAdUnitID(string adUnitId, [NullAllowed] Request request, InterstitialAdLoadCompletionHandler completionHandler);
    }

    [BaseType(typeof(Maui.Google.MobileAds.Request), Name = "GAMRequest")]
    interface Request
    {
        [NullAllowed, Export("publisherProvidedID", ArgumentSemantic.Copy)]
        string PublisherProvidedID { get; set; }

        [NullAllowed, Export("categoryExclusions", ArgumentSemantic.Copy)]
        string[] CategoryExclusions { get; set; }
    }
}