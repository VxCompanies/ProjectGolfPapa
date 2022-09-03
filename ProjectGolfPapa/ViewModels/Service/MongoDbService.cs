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
    private static readonly MongoClient _client = new("mongodb://localhost/27017");
    private static readonly IMongoDatabase _database = _client.GetDatabase("projectGolfPapa");
    private static readonly IMongoCollection<Pet> _petCollection = _database.GetCollection<Pet>("pets");
    private static readonly IMongoCollection<Sector> _locationCollection = _database.GetCollection<Sector>("sectors");

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

    public static IEnumerable<Pet> GetNearPets(Pet pet)
    {
        return _petCollection.Find(Builders<Pet>.Filter.Near(x => x.Location, pet.Location, maxDistance: 10000, minDistance: 1)).ToList();
    }

    public static string GetPetNeighborhood(Pet pet)
    {
        var p = _locationCollection.Find(Builders<Sector>.Filter.Near(x => x.Location, pet.Location, maxDistance: 10000, minDistance: 1)).ToList();
        return p.FirstOrDefault()!.neighborhood;
    }

    public static async Task<IEnumerable<Pet>> GetPets() => (await _petCollection.FindAsync(new BsonDocument())).ToList();

    public static async Task<IEnumerable<Pet>> GetPets(string filter, SearchCriteria searchCriteria) => searchCriteria switch
    {
        SearchCriteria.OwnerName => (await _petCollection.FindAsync(p => p.Owner.FirstName == filter)).ToList(),
        SearchCriteria.PetName => (await _petCollection.FindAsync(p => p.Name == filter)).ToList(),
        SearchCriteria.Race => (await _petCollection.FindAsync(p => p.Race == filter)).ToList(),
        SearchCriteria.Animal => (await _petCollection.FindAsync(p => p.Animal == filter)).ToList(),
        //SearchCriteria.Neighborhood => (await _petCollection.FindAsync(p => p.Location.Neighborhood == filter)).ToList()
    };
}

public enum SearchCriteria
{
    PetName,
    Race,
    Animal,
    OwnerName,
    Neighborhood
}
