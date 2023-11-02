using CommunityToolkit.Mvvm.ComponentModel;

namespace Resejournal.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {

        [ObservableProperty]
        string titlepage;


        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotLoading))]
        bool isLoading;

        public bool IsNotLoading => !isLoading;
    }
}
