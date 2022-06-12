namespace Planetas.ApplicationCore.Dtos
{
    public class HazardousAsteroidsFilteredDataDto
    {
        public int FilteredCount { get; }
        public IEnumerable<HazardousAsteroidDto> Data { get; }

        public HazardousAsteroidsFilteredDataDto(int filteredCount, IEnumerable<HazardousAsteroidDto> data)
        {
            FilteredCount = filteredCount;
            Data = data;
        }
    }
}
