using CommunityToolkit.Mvvm.ComponentModel;
using Resejournal.Models;

namespace Resejournal.ViewModels
{

    [QueryProperty(nameof(Trip), "Trip")]
    public partial class TripDetailViewModel : BaseViewModel
    {

        [ObservableProperty]
        Trip trip;

    }


    // [RelayCommand]
    //private async Task Takepicture()

    // {

    //     if (MediaPicker.Default.IsCaptureSupported)
    //     {
    //         FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

    //         if (photo != null)
    //         {
    //             // save the file into local storage
    //             string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

    //             using Stream sourceStream = await photo.OpenReadAsync();
    //             using FileStream localFileStream = File.OpenWrite(localFilePath);

    //             await sourceStream.CopyToAsync(localFileStream);
    //         }
    //     }
    // }


}
