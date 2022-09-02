using ProjectGolfPapa.ViewModels;
using ProjectGolfPapa.ViewModels.Store;

namespace ProjectGolfPapa.ViewModels.Service
{
    internal static class NavigationService
    {
        /// <summary>
        /// Changes the main navigation current viewmodel.
        /// </summary>
        /// <typeparam name="TMainViewModel">Initializes the new main navigation viewmodel.</typeparam>
        /// <param name="newViewModel"></param>
        public static void MainNavigate<TMainViewModel>(TMainViewModel newMainViewModel) where TMainViewModel : ViewModelBase => NavigationStore.CurrentMainViewModel = newMainViewModel;

        /// <summary>
        /// Navigates the index navigation viewmodel.
        /// </summary>
        /// <typeparam name="TIndexViewModel">Initializes the new index navigation viewmodel.</typeparam>
        /// <param name="newIndexViewModel"></param>
        public static void IndexNavigate<TIndexViewModel>(TIndexViewModel newIndexViewModel) where TIndexViewModel : ViewModelBase => NavigationStore.CurrentIndexViewModel = newIndexViewModel;
    }
}
