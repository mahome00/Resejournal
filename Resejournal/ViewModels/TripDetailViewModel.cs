﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Resejournal.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Resejournal.ViewModels
{

    [QueryProperty(nameof(Trip), "Trip")]
    public partial class TripDetailViewModel : BaseViewModel
    {

        public ObservableCollection<TripPhoto> TripPhotos { get; private set; } = new();

        [ObservableProperty]
        Trip trip;

        [ObservableProperty]
        bool isRefreshing;




        [RelayCommand]
        public async Task LoadTripPhotos()
        {

            IsLoading = true;
            if (TripPhotos.Any()) TripPhotos.Clear();
            try
            {
                var photos = App.TripService.GetPhotosForTrip(Trip.Id);
                foreach (var photo in photos)
                {
                    TripPhotos.Add(photo);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to load photos:{ex.Message}");
                await Shell.Current.DisplayAlert("Error", "Failed to load photos", "Ok");
            }

            finally
            {
                IsLoading = false;
            }


        }



        [RelayCommand]
        private async Task TakePicture()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo != null)
                {

                    string localFilePath = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);

                    using Stream sourceStream = await photo.OpenReadAsync();
                    using FileStream localFileStream = File.OpenWrite(localFilePath);

                    await sourceStream.CopyToAsync(localFileStream);

                    // Save the photos path in the database 
                    var tripPhoto = new TripPhoto
                    {
                        TripID = Trip.Id,
                        PhotoPath = localFilePath,
                        Description = ""
                    };

                    App.TripService.AddPhoto(tripPhoto);
                    TripPhotos.Add(tripPhoto);
                }
            }
        }

    }






}
