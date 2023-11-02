using CommunityToolkit.Maui.Views;
using Resejournal.ViewModels;

namespace Resejournal.Views;

public partial class AddTripPopupPage : Popup
{
    public AddTripPopupPage(AddTripPopupViewModel addTripPopupViewModel)
    {
        InitializeComponent();
        BindingContext = addTripPopupViewModel;
    }

    private void Cancel_Clicked(object sender, EventArgs e)
    {
        this.Close();
    }
}