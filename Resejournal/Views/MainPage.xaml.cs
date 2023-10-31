using Resejournal.ViewModels;

namespace Resejournal
{
    public partial class MainPage : ContentPage
    {



        public MainPage(TripListViewModel tripListViewModel)
        {
            InitializeComponent();
            BindingContext = tripListViewModel;



        }


    }
}