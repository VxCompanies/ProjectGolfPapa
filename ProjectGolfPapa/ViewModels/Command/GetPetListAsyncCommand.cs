using ProjectGolfPapa.Models;
using ProjectGolfPapa.ViewModels.Service;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ProjectGolfPapa.ViewModels.Command;

public class GetPetListAsyncCommand : AsyncCommandBase
{
    public async override Task ExecuteAsync(object? parameter)
    {
        var petList = (ObservableCollection<Pet>)parameter!;

        foreach (var pet in await MongoDbService.GetPets())
            petList.Add(pet);
    }
}
