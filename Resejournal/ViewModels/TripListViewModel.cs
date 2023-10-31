using CommunityToolkit.Mvvm.Input;
using Resejournal.Models;
using Resejournal.Services;
using Resejournal.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Resejournal.ViewModels
{
    public partial class TripListViewModel : BaseViewModel
    {
        private readonly TripService tripService;

        public ObservableCollection<Trip> Trips { get; private set; } = new();

        public TripListViewModel(TripService tripService)
        {
            Title = "Your Trips";
            this.tripService = tripService;
        }

        [RelayCommand]
        async Task GetTripList()
        {
            if (IsLoading) return;

            try
            {
                if (Trips.Any()) Trips.Clear();

                var trips = tripService.GetTrips();
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
            }

        }

        [RelayCommand]
        async Task GetTripDetail(Trip trip)
        {

            if (trip == null) return;

            await Shell.Current.GoToAsync(nameof(TripDetailPage), true, new Directory<string, object>
            {
                {nameof(Trip), trip }
            });


        }

    }
}
