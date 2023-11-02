using CommunityToolkit.Maui;
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
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "trips.db3");

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<TripService>(s, dbPath));

            builder.Services.AddSingleton<TripListViewModel>();
            builder.Services.AddTransient<TripDetailViewModel>();
            builder.Services.AddTransient<TripDetailPage>();
            builder.Services.AddTransient<AddTripPopupViewModel>();

            builder.Services.AddSingleton<MainPage>();

            return builder.Build();
        }
    }
}