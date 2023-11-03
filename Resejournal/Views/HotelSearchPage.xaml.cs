using Resejournal.ViewModels;

namespace Resejournal.Views;

public partial class HotelSearchPage : ContentPage
{
    public HotelSearchPage(HotelSearchViewModel hotelSearchViewModel)
    {
        InitializeComponent();
        BindingContext = hotelSearchViewModel;
    }
}