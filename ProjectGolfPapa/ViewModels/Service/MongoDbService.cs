using MongoDB.Bson;
using MongoDB.Driver;
using ProjectGolfPapa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGolfPapa.ViewModels.Service;

public static class MongoDbService
{
    private static readonly MongoClient _client = new(App.mongoDbConnectionString);
    private static readonly IMongoDatabase _database = _client.GetDatabase("projectGolfPapa");
    private static readonly IMongoCollection<Pet> _petCollection = _database.GetCollection<Pet>("pets");

    public static async Task<bool> RegisterPet(Pet pet)
    {
        try
        {
            await _petCollection.InsertOneAsync(pet);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static async Task<IEnumerable<Pet>> GetPets() => (await _petCollection.FindAsync(new BsonDocument())).ToList();

    public static async Task<IEnumerable<Pet>> GetPets(Pet pet, SearchCriteria searchCriteria) => searchCriteria switch
    {
        SearchCriteria.PetName => (await _petCollection.FindAsync(p => p.Name == pet.Name)).ToList(),
        SearchCriteria.Race => (await _petCollection.FindAsync(p => p.Race == pet.Race)).ToList(),
        SearchCriteria.Species => (await _petCollection.FindAsync(p => p.Species == pet.Species)).ToList(),
        SearchCriteria.OwnerName => (await _petCollection.FindAsync(p => p.Owner.FirstName == pet.Owner.FirstName)).ToList(),
        SearchCriteria.Neighborhood => (await _petCollection.FindAsync(p => p.Location.Neighborhood == pet.Location.Neighborhood)).ToList()
    };
}

public enum SearchCriteria
{
    PetName,
    Race,
    Species,
    OwnerName,
    Neighborhood
}
