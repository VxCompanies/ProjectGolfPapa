using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGolfPapa.Models
{
    public class Sector
    {
        public Location Location { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string Neighborhood { get; set; } = null!;
    }
}
