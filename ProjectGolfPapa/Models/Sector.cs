using MongoDB.Bson;
using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGolfPapa.Models
{
    public class Sector
    {
        public ObjectId _id { get; set; }
        public GeoJsonPoint<GeoJson2DCoordinates> Location { get; set; } = null!;
        public string zip_code { get; set; } = null!;
        public string neighborhood { get; set; } = null!;
    }
}
