using System;
using System.Runtime.InteropServices;

using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using WebKit;

namespace Maui.Google.MobileAds
{
	[Native]
	public enum AdChoicesPosition : long
	{
		TopRightCorner,
		TopLeftCorner,
		BottomRightCorner,
		BottomLeftCorner
	}

	[Native]
	public enum AdFormat : long
	{
		Banner = 0,
		Interstitial = 1,
		Rewarded = 2,
		Native = 3,
		RewardedInterstitial = 4,
		AppOpen = 6
	}

    [StructLayout(LayoutKind.Sequential)]
    public struct AdSize
    {
        public CGSize Size;
        public uint Flags;
    }

    [Native]
	public enum AdValuePrecision : long
	{
		Unknown = 0,
		Estimated = 1,
		PublisherProvided = 2,
		Precise = 3
	}

	[Native]
	public enum AdapterInitializationState : long
	{
		NotReady = 0,
		Ready = 1
	}

	[Native]
	public enum MediaAspectRatio : long
	{
		Unknown = 0,
		Any = 1,
		Landscape = 2,
		Portrait = 3,
		Square = 4
	}

	[Native]
	public enum PublisherPrivacyPersonalizationState : long
	{
		Default = 0,
		Enabled = 1,
		Disabled = 2
	}

    [StructLayout(LayoutKind.Sequential)]
    public struct VersionNumber
    {
        public uint majorVersion;

        public uint minorVersion;

        public uint patchVersion;
    }

    [Native]
    public enum PresentationErrorCode : long
    {
        AdNotReady = 15,
        AdTooLarge = 16,
        Internal = 17,
        AdAlreadyUsed = 18,
        NotMainThread = 21,
        Mediation = 22
    }

    [Native]
	public enum ErrorCode : long
	{
		InvalidRequest = 0,
		NoFill = 1,
		NetworkError = 2,
		ServerError = 3,
		OSVersionTooLow = 4,
		Timeout = 5,
		MediationDataError = 7,
		MediationAdapterError = 8,
		MediationInvalidAdSize = 10,
		InternalError = 11,
		InvalidArgument = 12,
		ReceivedInvalidResponse = 13,
		MediationNoFill = 9,
		AdAlreadyUsed = 19,
		ApplicationIdentifierMissing = 20
	}

    [Native]
    public enum BannerAnimationType : long
    {
        None = 0,
        FlipFromLeft = 1,
        FlipFromRight = 2,
        CurlUp = 3,
        CurlDown = 4,
        SlideFromLeft = 5,
        SlideFromRight = 6,
        FadeIn = 7,
        Random = 8
    }

    public enum AdLoaderAdType
    {
        CustomNative,
        GamBanner,
        Native
    }

    #region Extensions

    [Preserve(AllMembers = true)]
    [System.Runtime.Versioning.SupportedOSPlatform("ios11.0")]
    public partial class AdSizeCons
    {
        // GAD_EXTERN GADAdSize GADPortraitInlineAdaptiveBannerAdSizeWithWidth(CGFloat width);
        [DllImport("__Internal", EntryPoint = "GADPortraitInlineAdaptiveBannerAdSizeWithWidth")]
        public static extern AdSize GetPortraitInlineAdaptiveBannerAdSize(nfloat width);

        // GAD_EXTERN GADAdSize GADLandscapeInlineAdaptiveBannerAdSizeWithWidth(CGFloat width);
        [DllImport("__Internal", EntryPoint = "GADLandscapeInlineAdaptiveBannerAdSizeWithWidth")]
        public static extern AdSize GetLandscapeInlineAdaptiveBannerAdSize(nfloat width);

        // GAD_EXTERN GADAdSize GADCurrentOrientationInlineAdaptiveBannerAdSizeWithWidth(CGFloat width);
        [DllImport("__Internal", EntryPoint = "GADCurrentOrientationInlineAdaptiveBannerAdSizeWithWidth")]
        public static extern AdSize GetCurrentOrientationInlineAdaptiveBannerAdSize(nfloat width);

        // GAD_EXTERN GADAdSize GADInlineAdaptiveBannerAdSizeWithWidthAndMaxHeight(CGFloat width, CGFloat maxHeight);
        [DllImport("__Internal", EntryPoint = "GADInlineAdaptiveBannerAdSizeWithWidthAndMaxHeight")]
        public static extern AdSize GetInlineAdaptiveBannerAdSizeWithMaxHeight(nfloat width, nfloat maxHeight);

        //GAD_EXTERN GADAdSize GADPortraitAnchoredAdaptiveBannerAdSizeWithWidth (CGFloat width);
        [DllImport("__Internal", EntryPoint = "GADPortraitAnchoredAdaptiveBannerAdSizeWithWidth")]
        public static extern AdSize GetPortraitAnchoredAdaptiveBannerAdSize(nfloat width);

        //GAD_EXTERN GADAdSize GADLandscapeAnchoredAdaptiveBannerAdSizeWithWidth (CGFloat width);
        [DllImport("__Internal", EntryPoint = "GADLandscapeAnchoredAdaptiveBannerAdSizeWithWidth")]
        public static extern AdSize GetLandscapeAnchoredAdaptiveBannerAdSize(nfloat width);

        //GAD_EXTERN GADAdSize GADCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth (CGFloat width);
        [DllImport("__Internal", EntryPoint = "GADCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth")]
        public static extern AdSize GetCurrentOrientationAnchoredAdaptiveBannerAdSize(nfloat width);

        // GADAdSize GADAdSizeFromCGSize(CGSize size);
        [DllImport("__Internal", EntryPoint = "GADAdSizeFromCGSize")]
        public static extern AdSize GetFromCGSize(CGSize size);

        // GADAdSize GADAdSizeFullWidthPortraitWithHeight(CGFloat height);
        [DllImport("__Internal", EntryPoint = "GADAdSizeFullWidthPortraitWithHeight")]
        public static extern AdSize GetFullWidthPortrait(nfloat height);

        // GADAdSize GADAdSizeFullWidthLandscapeWithHeight (CGFloat height);
        [DllImport("__Internal", EntryPoint = "GADAdSizeFullWidthLandscapeWithHeight")]
        public static extern AdSize GetFullWidthLandscape(nfloat height);

        // BOOL GADAdSizeEqualToSize(GADAdSize size1, GADAdSize size2);
        [DllImport("__Internal", EntryPoint = "GADAdSizeEqualToSize")]
        public static extern bool Equals(AdSize size, AdSize toSize);

        // CGSize CGSizeFromGADAdSize(GADAdSize size);
        [DllImport("__Internal", EntryPoint = "CGSizeFromGADAdSize")]
        public static extern CGSize GetCGSize(AdSize size);

        // BOOL IsGADAdSizeValid(GADAdSize size);
        [DllImport("__Internal", EntryPoint = "IsGADAdSizeValid")]
        public static extern bool IsAdSizeValid(AdSize size);

        // GAD_EXTERN BOOL GADAdSizeIsFluid(GADAdSize size);
        [DllImport("__Internal", EntryPoint = "GADAdSizeIsFluid")]
        public static extern bool AdSizeIsFluid(AdSize size);

        // NSString *NSStringFromGADAdSize(GADAdSize size);
        [DllImport("__Internal", EntryPoint = "NSStringFromGADAdSize")]
        static extern IntPtr _GetNSString(AdSize size);

        // NSValue *NSValueFromGADAdSize(GADAdSize size);
        [DllImport("__Internal", EntryPoint = "NSValueFromGADAdSize")]
        static extern IntPtr _GetNSValue(AdSize size);

        // GADAdSize GADAdSizeFromNSValue(NSValue *value);
        [DllImport("__Internal", EntryPoint = "GADAdSizeFromNSValue")]
        public static extern AdSize _GetFromNSValue(IntPtr value);

        // extern NSString * _Nonnull GADGetStringFromVersionNumber (GADVersionNumber version);
        [DllImport("__Internal", EntryPoint = "GADGetStringFromVersionNumber")]
        public static extern NSString GetString(VersionNumber version);

        // extern GADAdSize GADClosestValidSizeForAdSizes (GADAdSize original, NSArray<NSValue *> * _Nonnull possibleAdSizes);
        [DllImport("__Internal", EntryPoint = "GADClosestValidSizeForAdSizes")]
        public static extern AdSize ClosestValidSizeForAdSizes(AdSize original, IntPtr[] possibleAdSizes);

        public static NSString? GetNSString(AdSize size)
        {
            return Runtime.GetNSObject<NSString>(_GetNSString(size));
        }

        public static NSValue? GetNSValue(AdSize size)
        {
            return Runtime.GetNSObject<NSValue>(_GetNSValue(size));
        }

        public static AdSize GetFromNSValue(NSValue value)
        {
            return _GetFromNSValue(value.Handle);
        }

        static AdSize? banner;
        public static AdSize? Banner
        {
            get
            {
                if (banner is null)
                {
                    IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen(null, 0);
                    IntPtr ptr = Dlfcn.dlsym(RTLD_MAIN_ONLY, "GADAdSizeBanner");
                    banner = (AdSize?)Marshal.PtrToStructure(ptr, typeof(AdSize));
                    _ = Dlfcn.dlclose(RTLD_MAIN_ONLY);
                }

                return banner.HasValue ? banner.Value : null;
            }
        }

        static AdSize? largeBanner;
        public static AdSize? LargeBanner
        {
            get
            {
                if (largeBanner is null)
                {
                    IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen(null, 0);
                    IntPtr ptr = Dlfcn.dlsym(RTLD_MAIN_ONLY, "GADAdSizeLargeBanner");
                    largeBanner = (AdSize?)Marshal.PtrToStructure(ptr, typeof(AdSize));
                    _ = Dlfcn.dlclose(RTLD_MAIN_ONLY);
                }

                return largeBanner.HasValue ? largeBanner.Value : null;
            }
        }

        static AdSize? mediumRectangle;
        public static AdSize? MediumRectangle
        {
            get
            {
                if (mediumRectangle is null)
                {
                    IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen(null, 0);
                    IntPtr ptr = Dlfcn.dlsym(RTLD_MAIN_ONLY, "GADAdSizeMediumRectangle");
                    mediumRectangle = (AdSize?)Marshal.PtrToStructure(ptr, typeof(AdSize));
                    _ = Dlfcn.dlclose(RTLD_MAIN_ONLY);
                }

                return mediumRectangle.HasValue ? mediumRectangle.Value : null;
            }
        }

        static AdSize? fullBanner;
        public static AdSize? FullBanner
        {
            get
            {
                if (fullBanner is null)
                {
                    IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen(null, 0);
                    IntPtr ptr = Dlfcn.dlsym(RTLD_MAIN_ONLY, "GADAdSizeFullBanner");
                    fullBanner = (AdSize?)Marshal.PtrToStructure(ptr, typeof(AdSize));
                    _ = Dlfcn.dlclose(RTLD_MAIN_ONLY);
                }

                return fullBanner.HasValue ? fullBanner.Value : null;
            }
        }

        static AdSize? leaderboard;
        public static AdSize? Leaderboard
        {
            get
            {
                if (leaderboard is null)
                {
                    IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen(null, 0);
                    IntPtr ptr = Dlfcn.dlsym(RTLD_MAIN_ONLY, "GADAdSizeLeaderboard");
                    leaderboard = (AdSize?)Marshal.PtrToStructure(ptr, typeof(AdSize));
                    _ = Dlfcn.dlclose(RTLD_MAIN_ONLY);
                }

                return leaderboard.HasValue ? leaderboard.Value : null;
            }
        }

        static AdSize? skyscraper;
        public static AdSize? Skyscraper
        {
            get
            {
                if (skyscraper is null)
                {
                    IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen(null, 0);
                    IntPtr ptr = Dlfcn.dlsym(RTLD_MAIN_ONLY, "GADAdSizeSkyscraper");
                    skyscraper = (AdSize?)Marshal.PtrToStructure(ptr, typeof(AdSize));
                    _ = Dlfcn.dlclose(RTLD_MAIN_ONLY);
                }

                return skyscraper.HasValue ? skyscraper.Value : null;
            }
        }

        static AdSize? fluid;
        public static AdSize? Fluid
        {
            get
            {
                if (fluid is null)
                {
                    IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen(null, 0);
                    IntPtr ptr = Dlfcn.dlsym(RTLD_MAIN_ONLY, "GADAdSizeFluid");
                    fluid = (AdSize?)Marshal.PtrToStructure(ptr, typeof(AdSize));
                    _ = Dlfcn.dlclose(RTLD_MAIN_ONLY);
                }

                return fluid.HasValue ? fluid.Value : null;
            }
        }

        static AdSize? invalid;
        public static AdSize? Invalid
        {
            get
            {
                if (invalid is null)
                {
                    IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen(null, 0);
                    IntPtr ptr = Dlfcn.dlsym(RTLD_MAIN_ONLY, "GADAdSizeInvalid");
                    invalid = (AdSize?)Marshal.PtrToStructure(ptr, typeof(AdSize));
                    _ = Dlfcn.dlclose(RTLD_MAIN_ONLY);
                }

                return invalid.HasValue ? invalid.Value : null;
            }
        }

        public static string GetString(AdSize size)
        {
            return GetNSString(size);
        }
    }

    public partial class AdLoader : NSObject
    {
        public AdLoader(string adUnitId, UIViewController rootViewController, AdLoaderAdType[] adTypes, AdLoaderOptions[] options) :
            this(adUnitId, rootViewController, CastAdTypes(adTypes), options)
        {
        }

        static NSString[] CastAdTypes(AdLoaderAdType[] adTypes)
        {
            if (adTypes is null)
                return null;

            var adLoaderAdTypes = new NSString[adTypes.Length];
            for (int i = 0; i < adTypes.Length; i++)
            {
                if (adTypes[i] == AdLoaderAdType.CustomNative)
                {
                    adLoaderAdTypes[i] = AdLoaderAdTypeConstants.CustomNative;
                }
                else if (adTypes[i] == AdLoaderAdType.GamBanner)
                {
                    adLoaderAdTypes[i] = AdLoaderAdTypeConstants.GamBanner;
                }
                else if (adTypes[i] == AdLoaderAdType.Native)
                {
                    adLoaderAdTypes[i] = AdLoaderAdTypeConstants.Native;
                }
            }

            return adLoaderAdTypes;
        }
    }

    [System.Runtime.Versioning.SupportedOSPlatform("ios11.0")]
    public partial class CustomNativeAd
    {
        public static string MediaViewKey { get; } = _MediaViewKey.ToString();
    }

    public partial class Request
    {
        public static readonly string GADGoogleAdMobNetworkName = "GoogleAdMobAds";
    }
    #endregions
}