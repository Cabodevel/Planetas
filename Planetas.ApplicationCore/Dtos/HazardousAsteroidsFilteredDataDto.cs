using Planetas.Infrastructure.Models;

namespace Planetas.ApplicationCore.Dtos
{
    public class HazardousAsteroidsFilteredDataDto
    {
        public int FilteredCount { get; }
        public IEnumerable<HazardousAsteroid> Data { get; }

        public HazardousAsteroidsFilteredDataDto(int filteredCount, IEnumerable<HazardousAsteroid> data)
        {
            FilteredCount = filteredCount;
            Data = data;
        }
    }
}
