using System;

namespace ProjectGolfPapa.Models
{
    public class Pet
    {
        public string Name { get; set; } = null!;
        public string Species { get; set; } = null!;
        public string Race { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public Owner Owner { get; set; } = null!;
        public Location Location { get; set; } = null!;
    }
}
