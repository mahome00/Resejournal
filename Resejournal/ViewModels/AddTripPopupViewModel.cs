using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Resejournal.Models;
using Resejournal.Views;

namespace Resejournal.ViewModels
{
    public partial class AddTripPopupViewModel : BaseViewModel
    {

        public AddTripPopupPage PopupPage { get; set; }


        public AddTripPopupViewModel()
        {
            Titlepage = "Add trip";

        }

        [ObservableProperty]
        string title;
        [ObservableProperty]
        string tripDate;


        [RelayCommand]
        async Task SaveTrip()
        {
            if (string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(TripDate))
            {
                await Shell.Current.DisplayAlert("Invalid Data", "Please enter valid data", "Ok");
                return;
            }

            var newTrip = new Trip
            {
                Title = this.Title,
                TripDate = DateTime.Parse(this.TripDate) // Antar att tripDate är en sträng
            };
            App.TripService.AddTrip(newTrip);
            // Close the popup
            PopupPage?.Close();


        }

    }
}
