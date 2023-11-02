using Resejournal.ViewModels;

namespace Resejournal.Views;

public partial class TripDetailPage : ContentPage
{
    public TripDetailPage(TripDetailViewModel tripDetailViewModel)
    {
        InitializeComponent();
        BindingContext = tripDetailViewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }

    //private async void Button_Pressed(object sender, EventArgs e)
    //{
    //    if (MediaPicker.Default.IsCaptureSupported)
    //    {
    //        FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

    //        if (photo != null)
    //        {
    //            // save the file into local storage
    //            string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

    //            using Stream sourceStream = await photo.OpenReadAsync();
    //            using FileStream localFileStream = File.OpenWrite(localFilePath);

    //            await sourceStream.CopyToAsync(localFileStream);
    //        }
    //    }
    //}



    //public async Task ImageButton_PressedAsync(object sender, EventArgs e)
    //{
    //    if (MediaPicker.Default.IsCaptureSupported)
    //    {
    //        FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

    //        if (photo != null)
    //        {
    //            // save the file into local storage
    //            string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

    //            using Stream sourceStream = await photo.OpenReadAsync();
    //            using FileStream localFileStream = File.OpenWrite(localFilePath);

    //            await sourceStream.CopyToAsync(localFileStream);
    //        }
    //    }
    //}
}