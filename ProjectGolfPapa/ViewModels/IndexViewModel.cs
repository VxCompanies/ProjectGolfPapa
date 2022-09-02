﻿using ProjectGolfPapa.ViewModels.Command.Navigation;
using ProjectGolfPapa.ViewModels.Store;

namespace ProjectGolfPapa.ViewModels
{
    public class IndexViewModel : ViewModelBase
    {
        public ViewModelBase? CurrentIndexViewModel => NavigationStore.CurrentIndexViewModel;

        public NavigateHomeCommand NavigateHomeCommand { get; }

        public IndexViewModel()
        {
            NavigationStore.CurrentIndexViewModelChanged += OnCurrentIndexViewModelChanged;

            NavigateHomeCommand = new NavigateHomeCommand();
        }

        private void OnCurrentIndexViewModelChanged() => OnPropertyChanged(nameof(CurrentIndexViewModel));
    }
}
