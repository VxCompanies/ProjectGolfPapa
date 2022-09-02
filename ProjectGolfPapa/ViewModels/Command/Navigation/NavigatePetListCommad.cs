using ProjectGolfPapa.ViewModels.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGolfPapa.ViewModels.Command.Navigation
{
    public class NavigatePetListCommad : CommandBase
    {
        public override void Execute(object? parameter) => NavigationService.IndexNavigate(new PetListViewModel());
    }
}
