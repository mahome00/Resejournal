using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Resejournal.Models;
using Resejournal.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;


namespace Resejournal.ViewModels
{
    public partial class TripListViewModel : BaseViewModel
    {


        public ObservableCollection<Trip> Trips { get; private set; } = new();

        public TripListViewModel()
        {
            Titlepage = "Your Trips";
            GetTripList();

        }

        [ObservableProperty]
        bool isRefreshing;


        [RelayCommand]
        async Task GetTripList()
        {
            if (IsLoading) return;

            try
            {

                IsLoading = true;
                if (Trips.Any()) Trips.Clear();

                var trips = App.TripService.GetTrips();
                foreach (var trip in trips)
                {
                    Trips.Add(trip);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get trips:{ex.Message}");
                await Shell.Current.DisplayAlert("Error", "Failed to get list of trips", "Ok");
            }

            finally
            {
                IsLoading = false;
                IsRefreshing = false;
            }

        }

        [RelayCommand]
        async Task GoToTripDetail(Trip trip)
        {

            if (trip == null) return;

            await Shell.Current.GoToAsync(nameof(TripDetailPage), true, new Dictionary<string, object>
            {

                {nameof(Trip), trip }
            });
        }



    }
}
