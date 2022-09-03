﻿using ProjectGolfPapa.Models;
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

    public FindNearPetsCommand FindNearPetsCommand { get; set; }

    public PetListViewModel()
    {
        PetList = new();
        NearPetList = new();
        SearchCriteria = new();
        //SelectedPet = new();

        foreach (var criteria in Enum.GetValues(typeof(SearchCriteria)).Cast<SearchCriteria>())
            SearchCriteria.Add(criteria);

        GetPets();

        GetPetListCommand = new();

        FindNearPetsCommand = new();
    }

    private async void GetPets()
    {
        foreach (var pet in await MongoDbService.GetPets())
            PetList.Add(pet);
    }
}
