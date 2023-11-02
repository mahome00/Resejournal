using Resejournal.Services;

namespace Resejournal
{
    public partial class App : Application
    {
        public static TripService TripService { get; private set; }
        public App(TripService tripService)
        {
            InitializeComponent();

            MainPage = new AppShell();
            TripService = tripService;
        }
    }
}