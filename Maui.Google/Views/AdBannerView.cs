﻿namespace Maui.Google.Views;

public class AdBannerView : View, IAdBannerView
{
    public static readonly BindableProperty AdUnitIdProperty = BindableProperty.Create(
        nameof(AdUnitId),
        typeof(string),
        typeof(AdBannerView),
        string.Empty);

    public string AdUnitId
    {
        get => (string)GetValue(AdUnitIdProperty);
        set => SetValue(AdUnitIdProperty, value);
    }
}
