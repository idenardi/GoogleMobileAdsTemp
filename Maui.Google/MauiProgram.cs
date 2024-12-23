﻿using Maui.Google.Services;
using Maui.Google.Views;
using Microsoft.Extensions.Logging;

namespace Maui.Google
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .ConfigureMauiHandlers(h =>
                {
                    h.AddHandler(typeof(AdBannerView), typeof(AdBannerViewHandler));
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<IPrivacyAndConsentService, PrivacyAndConsentService>();

            return builder.Build();
        }
    }
}
