﻿using RatingViewControl.PlatformImplementations;
using Microsoft.Extensions.Logging;
using RatingViewControl.Controls;

namespace RatingViewControl
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
                .ConfigureMauiHandlers(collection =>
                {
                    collection.AddHandler(typeof(RatingView), typeof(RatingViewHandler));
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
