using Resejournal.Views;

namespace Resejournal
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TripDetailPage), typeof(TripDetailPage));
        }
    }
}