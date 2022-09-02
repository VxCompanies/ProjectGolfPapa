using ProjectGolfPapa.ViewModels.Service;

namespace ProjectGolfPapa.ViewModels.Command.Navigation
{
    public class NavigateRegisterPetCommand : CommandBase
    {
        public override void Execute(object? parameter) => NavigationService.IndexNavigate(new RegisterPetViewModel());
    }
}
