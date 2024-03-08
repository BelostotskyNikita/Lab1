using Microsoft.Extensions.Logging;
using Lab1_4.Services;

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
            builder.Services.AddTransient<DataBasePage>();
            builder.Services.AddTransient<IDbService, SQLiteService>();
            builder.Services.AddTransient<CurrencyConverterPage>();
            builder.Services.AddTransient<IRateService, RateService>();
            builder.Services.AddHttpClient<IRateService, RateService>(t => t.BaseAddress = new Uri("https://api.nbrb.by/exrates/rates"));
            
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
