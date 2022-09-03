using ProjectGolfPapa.ViewModels.Service;
using System.Threading.Tasks;

namespace ProjectGolfPapa.ViewModels.Command
{
    public class FilterPetListAsyncCommand : AsyncCommandBase
    {
        public async override Task ExecuteAsync(object? parameter)
        {
            var petListViewModel = (PetListViewModel)parameter!;

            petListViewModel.PetList.Clear();

            switch (petListViewModel.SelectedCriteria)
            {
                case SearchCriteria.PetName:
                    foreach (var pet in await MongoDbService.GetPets(petListViewModel.Filter, SearchCriteria.PetName))
                        petListViewModel.PetList.Add(pet);
                    break;
                case SearchCriteria.Race:
                    foreach (var pet in await MongoDbService.GetPets(petListViewModel.Filter, SearchCriteria.Race))
                        petListViewModel.PetList.Add(pet);
                    break;
                case SearchCriteria.Animal:
                    foreach (var pet in await MongoDbService.GetPets(petListViewModel.Filter, SearchCriteria.Animal))
                        petListViewModel.PetList.Add(pet);
                    break;
                case SearchCriteria.OwnerName:
                    foreach (var pet in await MongoDbService.GetPets(petListViewModel.Filter, SearchCriteria.OwnerName))
                        petListViewModel.PetList.Add(pet);
                    break;
                case SearchCriteria.Neighborhood:
                    foreach (var pet in await MongoDbService.GetPets(petListViewModel.Filter, SearchCriteria.Neighborhood))
                        petListViewModel.PetList.Add(pet);
                    break;
            }
        }
    }
}
