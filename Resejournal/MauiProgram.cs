using Microsoft.Extensions.Logging;
using Resejournal.Services;
using Resejournal.ViewModels;
using Resejournal.Views;

namespace Resejournal
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

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<TripService>();

            builder.Services.AddSingleton<TripListViewModel>();
            builder.Services.AddTransient<TripDetailViewModel>();
            builder.Services.AddTransient<TripDetailPage>();

            builder.Services.AddSingleton<MainPage>();

            return builder.Build();
        }
    }
}