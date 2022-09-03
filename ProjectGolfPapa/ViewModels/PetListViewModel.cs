using ProjectGolfPapa.Models;
using ProjectGolfPapa.ViewModels.Command;
using ProjectGolfPapa.ViewModels.Service;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using MongoDB.Bson;

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
    

    private string _TBAnimalName;
    public string TBAnimalName
    {
        get => _TBAnimalName;
        set
        {
            _TBAnimalName = value;
            UpdateTable();
            OnPropertyChanged(nameof(TBAnimalName));
        }
    }

    private string _TBSectorName;
    public string TBSectorName
    {
        get => _TBSectorName;
        set
        {
            _TBSectorName = value;

            UpdateTable();
            OnPropertyChanged(nameof(TBSectorName));
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

    private LocatedPet _selectedPet;
    public LocatedPet SelectedPet
    {
        get => _selectedPet;
        set
        {
            _selectedPet = value;
            OnPropertyChanged(nameof(SelectedPet));
        }
    }

    public ObservableCollection<SearchCriteria> SearchCriteria { get; set; }

    public ObservableCollection<LocatedPet> NearPetList { get; set; }

    public ObservableCollection<Pet> PetList { get; set; }

    public GetPetListAsyncCommand GetPetListCommand { get; set; }


    public PetListViewModel()
    {
        PetList = new();
        NearPetList = new();
        SearchCriteria = new();
        //SelectedPet = new();

        foreach (var criteria in Enum.GetValues(typeof(SearchCriteria)).Cast<SearchCriteria>())
            SearchCriteria.Add(criteria);

        GetPets();
        UpdateTable();

        GetPetListCommand = new();
    }

    private async void GetPets()
    {
        foreach (var pet in await MongoDbService.GetPets())
            PetList.Add(pet);
    }

    private void UpdateTable()
    {
        NearPetList.Clear();

        Pet pet = new();

        if (SelectedPet is null) //Garantizar que sean seleccionados las mascotaas serca a santo domingo
            pet.Location = new(new(-69.8884, 18.5));
        else
            pet.Location = new(pet.Location.Coordinates);

        foreach (var pet1 in MongoDbService.GetNearPets(pet))
        {
            if (string.IsNullOrWhiteSpace(TBSectorName)
                    && string.IsNullOrWhiteSpace(TBAnimalName))
                NearPetList.Add(new(pet1));

            else if (string.IsNullOrWhiteSpace(TBSectorName))
            {
                if (pet1.Animal.ToLower().Contains(TBAnimalName.ToLower()))
                    NearPetList.Add(new(pet1));
            }

            else if (string.IsNullOrWhiteSpace(TBAnimalName))
            {
                if (MongoDbService.GetPetNeighborhood(pet1).ToLower().Contains(TBSectorName.ToLower()))
                    NearPetList.Add(new(pet1));
            }
            else
            {
                if (MongoDbService.GetPetNeighborhood(pet1).ToLower() == TBSectorName.ToLower()
                            && pet1.Animal.ToLower() == TBAnimalName.ToLower())
                    NearPetList.Add(new(pet1));
            }
        }
    }
}
