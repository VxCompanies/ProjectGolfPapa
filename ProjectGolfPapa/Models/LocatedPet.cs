using ProjectGolfPapa.ViewModels.Service;
using System;

namespace ProjectGolfPapa.Models
{
    public class LocatedPet
    {
        public string Name { get; set; } = null!;
        public string Species { get; set; } = null!;
        public string Race { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Owner { get; set; } = null!;
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
            Owner = $"{pet.Owner.FirstName} {pet.Owner.LastName}";
            Neighborhood = MongoDbService.asd(pet);
        }
    }
}
