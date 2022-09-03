using ProjectGolfPapa.Models;
using ProjectGolfPapa.ViewModels.Service;

namespace ProjectGolfPapa.ViewModels.Command
{
    public class FindNearPetsCommand : CommandBase
    {
        

        public override void Execute(object? parameter)
        {
            var petVM = (PetListViewModel)parameter!;

            

        petVM.NearPetList.Clear();

            Pet pet = new();

            if (petVM.SelectedPet is null)
                pet.Location = new(new(-69.8884, 18.5));
            else
                pet.Location = new(pet.Location.Coordinates);

            foreach (var pet1 in MongoDbService.GetNearPets(pet))
            {
                if (string.IsNullOrWhiteSpace(petVM.TBSectorName)
                        && string.IsNullOrWhiteSpace(petVM.TBRaceName))
                    petVM.NearPetList.Add(new(pet1));

                else if (string.IsNullOrWhiteSpace(petVM.TBSectorName))
                {
                    if (pet1.Race.ToLower() == petVM.TBRaceName.ToLower())
                        petVM.NearPetList.Add(new(pet1));
                }

                else if (string.IsNullOrWhiteSpace(petVM.TBRaceName))
                {
                    if (MongoDbService.GetPetNeighborhood(pet1).ToLower() == petVM.TBSectorName.ToLower())
                        petVM.NearPetList.Add(new(pet1));
                }
                else
                {
                    if (MongoDbService.GetPetNeighborhood(pet1).ToLower() == petVM.TBSectorName.ToLower()
                                && pet1.Race.ToLower() == petVM.TBRaceName.ToLower())
                        petVM.NearPetList.Add(new(pet1));
                }
            }
        }
    }
}
