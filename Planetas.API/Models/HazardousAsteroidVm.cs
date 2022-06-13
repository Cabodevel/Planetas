namespace Planetas.API.Models
{
    public class HazardousAsteroidVm
    {
        public string Name { get; set; }
        public decimal Diameter { get; set; }

        public decimal Speed { get; set; }

        public string Date { get; set; }

        public string Planet { get; set; }
    }
}