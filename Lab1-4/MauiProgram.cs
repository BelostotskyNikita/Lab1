using Microsoft.Extensions.Logging;
using Lab1_4.Services;

namespace Lab1_4
{
    public static class MauiProgram
    {
        public static IServiceCollection services = new ServiceCollection();
        public static IDbService? sqliteService = new SQLiteService();
        public static IRateService? rateService = new RateService(new HttpClient());
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
            services.AddTransient<IDbService, SQLiteService>();
            services.AddTransient<IRateService, RateService>();
            services.AddHttpClient<IRateService, RateService>(opt => opt.BaseAddress = new Uri("https://api.nbrb.by/exrates/rates?ondate="));
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
