namespace ProjectGolfPapa.Models
{
    public class Location
    {
        public string Type { get; set; } = null!;
        public decimal[] Coordinates { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string Neighborhood { get; set; } = null!;
    }
}