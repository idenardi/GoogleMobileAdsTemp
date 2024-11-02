using Maui.Google.MobileAds;
using Microsoft.Maui.Handlers;
using UIKit;

namespace Maui.Google.Views;

public partial class AdBannerViewHandler : ViewHandler<AdBannerView, BannerView>
{
    protected override BannerView CreatePlatformView()
    {
        BannerView adBannerView = CreateAdView();
        return adBannerView;
    }

    protected override void ConnectHandler(BannerView platformView)
    {
        base.ConnectHandler(platformView);
        platformView.AdUnitId = VirtualView.AdUnitId;
    }

    private static void MapAdUnitId(AdBannerViewHandler handler, AdBannerView view)
    {
        if (handler != null)
        {
            handler.PlatformView.AdUnitId = view.AdUnitId;
        }
    }

    private BannerView CreateAdView()
    {
        int currentWidth = (int)(Math.Min(2560, DeviceDisplay.MainDisplayInfo.Width)
            / DeviceDisplay.MainDisplayInfo.Density);

        AdSize adSize = AdSizeCons.GetCurrentOrientationAnchoredAdaptiveBannerAdSize(currentWidth);

        BannerView bannerView = new(size: adSize)
        {
            AdUnitId = VirtualView.AdUnitId,
            RootViewController = GetVisibleViewController()
        };

        bannerView.LoadRequest(Request.GetDefaultRequest());

        return bannerView;
    }

    private static UIViewController? GetVisibleViewController()
    {
        //var windows = UIApplication.SharedApplication.Windows;
        IEnumerable<UIWindow> windows = UIApplication.SharedApplication.ConnectedScenes
            .OfType<UIWindowScene>()
            .SelectMany(s => s.Windows);

        foreach (UIWindow? window in windows)
        {
            if (window.RootViewController != null)
            {
                return window.RootViewController;
            }
        }
        return null;
    }
}
