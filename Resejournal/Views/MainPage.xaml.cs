using CommunityToolkit.Maui.Views;
using Resejournal.ViewModels;
using Resejournal.Views;

namespace Resejournal
{
    public partial class MainPage : ContentPage
    {



        public MainPage(TripListViewModel tripListViewModel)
        {
            InitializeComponent();
            BindingContext = tripListViewModel;

        }

        private void ShowPopup_Clicked(object sender, EventArgs e)
        {



            var addTripPopupViewModel = new AddTripPopupViewModel();
            var popupPage = new AddTripPopupPage(addTripPopupViewModel);
            addTripPopupViewModel.PopupPage = popupPage;
            this.ShowPopup(popupPage);

        }
    }
}