namespace Planetas.API.Models
{
    public class HazardousAsteroidsFilter
    {
        public string PlanetName { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
