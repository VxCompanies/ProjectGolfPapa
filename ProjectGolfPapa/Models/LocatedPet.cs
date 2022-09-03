using ProjectGolfPapa.ViewModels.Service;

namespace ProjectGolfPapa.Models
{
    public class LocatedPet : Pet
    {
        public string Neighborhood { get; set; } = null!;
        public LocatedPet()
        {
        }

        public LocatedPet(Pet pet)
        {
            Name = pet.Name;
            Species = pet.Species;
            Race = pet.Race;
            Gender = pet.Gender;
            BirthDate = pet.BirthDate;
            Owner = pet.Owner;
            Location = pet.Location;
            Geometry = pet.Geometry;
            Neighborhood = MongoDbService.GetPetNeighborhood(pet);
        }
    }
}
