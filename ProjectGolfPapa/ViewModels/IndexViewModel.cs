using ProjectGolfPapa.ViewModels.Command.Navigation;
using ProjectGolfPapa.ViewModels.Store;

namespace ProjectGolfPapa.ViewModels
{
    public class IndexViewModel : ViewModelBase
    {
        public ViewModelBase? CurrentIndexViewModel => NavigationStore.CurrentIndexViewModel;

        public NavigateHomeCommand NavigateHomeCommand { get; }

        public NavigateRegisterPetCommand NavigateRegisterPetCommand { get; set; }

        public NavigatePetListCommad NavigatePetListCommad { get; set; }

        public IndexViewModel()
        {
            NavigationStore.CurrentIndexViewModelChanged += OnCurrentIndexViewModelChanged;

            NavigateHomeCommand = new();
            NavigateRegisterPetCommand = new();
            NavigatePetListCommad = new();
        }

        private void OnCurrentIndexViewModelChanged() => OnPropertyChanged(nameof(CurrentIndexViewModel));
    }
}
