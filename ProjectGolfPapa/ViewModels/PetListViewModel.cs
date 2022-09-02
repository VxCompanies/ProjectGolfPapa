using ProjectGolfPapa.Models;
using ProjectGolfPapa.ViewModels.Command;
using ProjectGolfPapa.ViewModels.Service;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProjectGolfPapa.ViewModels;

public class PetListViewModel : ViewModelBase
{
    private string _filter;
    public string Filter
    {
        get => _filter;
        set
        {
            _filter = value;
            OnPropertyChanged(nameof(Filter));
        }
    }

    private SearchCriteria _selectedCriteria;
    public SearchCriteria SelectedCriteria
    {
        get => _selectedCriteria;
        set
        {
            _selectedCriteria = value;
            OnPropertyChanged(nameof(SelectedCriteria));
        }
    }

    public ObservableCollection<SearchCriteria> SearchCriteria { get; set; }

    public ObservableCollection<Pet> PetList { get; set; }

    public GetPetListAsyncCommand GetPetListCommand { get; set; }

    public PetListViewModel()
    {
        PetList = new();
        SearchCriteria = new();

        foreach (var criteria in Enum.GetValues(typeof(SearchCriteria)).Cast<SearchCriteria>())
            SearchCriteria.Add(criteria);

        GetPets();

        GetPetListCommand = new();
    }

    private async void GetPets()
    {
        foreach (var pet in await MongoDbService.GetPets())
            PetList.Add(pet);
    }
}
