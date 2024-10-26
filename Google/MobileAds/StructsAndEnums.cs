using System;
using System.Runtime.InteropServices;

using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace Google.MobileAds
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
	public enum PublisherPrivacyPersonalizationState : long
	{
		Default = 0,
		Enabled = 1,
		Disabled = 2
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

    [StructLayout(LayoutKind.Sequential)]
    public struct AdSize
    {
        public CGSize Size;
        public uint Flags;
    }

    public enum AdLoaderAdType
    {
        // extern NSString *const GADAdLoaderAdTypeCustomNative;
        [Field("GADAdLoaderAdTypeCustomNative", "__Internal")]
        CustomNative,

        // extern NSString *const GADAdLoaderAdTypeGAMBanner;
        [Field("GADAdLoaderAdTypeGAMBanner", "__Internal")]
        GamBanner,

        // extern NSString *const GADAdLoaderAdTypeNative;
        [Field("GADAdLoaderAdTypeNative", "__Internal")]
        Native
    }
}