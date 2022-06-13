namespace Planetas.Web.Models
{
    public class HazardousAsteroidsApiResponse
    {
        public int TotalItemsCount { get; set; }
        public IEnumerable<HazardousAsteroid> HazardousAsteroids { get; set; }
    }
}
