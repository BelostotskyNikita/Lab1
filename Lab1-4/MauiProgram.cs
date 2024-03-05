﻿using Microsoft.Extensions.Logging;
using Lab1_4.Services;
using System.ComponentModel.Design;

namespace Lab1_4
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
                });
            builder.Services.AddTransient<IDbService, SQLiteService>();
            builder.Services.AddTransient<DataBasePage>();
            builder.Services.AddTransient<CurrencyConverterPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
