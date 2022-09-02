using ProjectGolfPapa.Models;
using ProjectGolfPapa.ViewModels.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGolfPapa.ViewModels.Command
{
    public class FindNearPetsCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            var petVM = (PetListViewModel)parameter!;

            Pet pet = new()
            {
                Location = new(new(-69.8884, 18.5))
                //Location = new(petVM.SelectedPet.Location.Coordinates)

            };

            foreach (var pet1 in MongoDbService.GetNearPets(pet))
                petVM.NearPetList.Add(new(pet1));
        }
    }
}
