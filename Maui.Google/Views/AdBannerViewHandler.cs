namespace Maui.Google.Views;

public partial class AdBannerViewHandler
{
    private static PropertyMapper<AdBannerView, AdBannerViewHandler> AdBannerViewMapper =
        new(ViewMapper)
        {
            [nameof(AdBannerView.AdUnitId)] = MapAdUnitId
        };

    public AdBannerViewHandler(PropertyMapper mapper) : base(mapper)
    {
    }

    public AdBannerViewHandler() : base(AdBannerViewMapper)
    {
    }
}
