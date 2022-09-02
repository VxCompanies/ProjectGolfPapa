using ProjectGolfPapa.Models;
using ProjectGolfPapa.ViewModels.Command;
using ProjectGolfPapa.ViewModels.Service;
using System.Collections.ObjectModel;

namespace ProjectGolfPapa.ViewModels;

public class PetListViewModel : ViewModelBase
{
    public ObservableCollection<Pet> PetList { get; set; }

    public GetPetListAsyncCommand GetPetListCommand { get; set; }

    public PetListViewModel()
    {
        PetList = new();

        GetPets();

        GetPetListCommand = new();
    }

    private async void GetPets()
    {
        foreach (var pet in await MongoDbService.GetPets())
            PetList.Add(pet);
    }
}
