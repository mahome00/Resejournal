using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Resejournal.Models;
using System.Collections.ObjectModel;

namespace Resejournal.ViewModels
{

    [QueryProperty(nameof(Trip), "Trip")]
    public partial class TripDetailViewModel : BaseViewModel
    {

        public ObservableCollection<TripPhoto> TripPhotos { get; private set; } = new();

        [ObservableProperty]
        Trip trip;


        [RelayCommand]
        private async Task TakePicture()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo != null)
                {
                    // save the file into local storage
                    string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                    using Stream sourceStream = await photo.OpenReadAsync();
                    using FileStream localFileStream = File.OpenWrite(localFilePath);

                    await sourceStream.CopyToAsync(localFileStream);
                }
            }
        }

    }






}
