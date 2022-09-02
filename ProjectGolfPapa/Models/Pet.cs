using MongoDB.Bson;
using MongoDB.Driver.GeoJsonObjectModel;
using System;

namespace ProjectGolfPapa.Models
{
    public class Pet
    {
        public ObjectId _id { get; set; }
        public string Name { get; set; } = null!;
        public string Species { get; set; } = null!;
        public string Race { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public Owner Owner { get; set; } = null!;
        public GeoJsonPoint<GeoJson2DCoordinates> Location { get; set; } = null!;
        public GeoJsonPoint<GeoJson2DCoordinates> Geometry { get; set; } = null!;
        //public Location Location { get; set; } = null!;
    }
}
