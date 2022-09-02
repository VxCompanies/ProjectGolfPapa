using ProjectGolfPapa.ViewModels.Service;

namespace ProjectGolfPapa.ViewModels.Command.Navigation
{
    public class NavigateHomeCommand : CommandBase
    {
        public override void Execute(object? parameter) => NavigationService.IndexNavigate(new HomeViewModel());
    }
}
