using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProjectGolfPapa.Models
{
    public class Location
    {
        public string Type { get; set; } = null!;

        [BsonRepresentation(BsonType.Double)]
        public decimal[] Coordinates { get; set; } = null!;
    }
}