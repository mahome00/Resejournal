using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Resejournal.Data;
using Resejournal.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Resejournal.ViewModels
{
    public partial class HotelSearchViewModel : BaseViewModel
    {

        private readonly HotelService _hotelService = new HotelService();

        public ObservableCollection<HotelData> HotelDatas { get; private set; } = new();

        [ObservableProperty]
        DateTime checkIn;

        [ObservableProperty]
        DateTime checkOut;

        [ObservableProperty]
        string cityName;


        [RelayCommand]
        async Task SearchHotels()
        {
            IsLoading = true;
            try
            {
                if (HotelDatas.Any()) HotelDatas.Clear();

                var geoId = await _hotelService.GetGeoIdByCityName(CityName);
                if (geoId.HasValue)
                {
                    var hotels = await _hotelService.GetHotelsByGeoIdAndDates(geoId.Value, CheckIn, CheckOut);
                    HotelDatas.Clear();
                    foreach (var hotel in hotels)
                    {
                        HotelDatas.Add(hotel);
                    }
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Try another city", "Ok");
                }

            }
            catch (Exception ex)
            {

                Debug.WriteLine($"Unable to get hotels:{ex.Message}");
                await Shell.Current.DisplayAlert("Error", "Failed to get hotel info", "Ok");
            }

            finally { IsLoading = false; }

        }



    }
}
