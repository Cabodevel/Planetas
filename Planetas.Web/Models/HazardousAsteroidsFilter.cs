namespace Planetas.Web.Models
{
    public class HazardousAsteroidsFilter
    {
        public string PlanetName { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }
}
