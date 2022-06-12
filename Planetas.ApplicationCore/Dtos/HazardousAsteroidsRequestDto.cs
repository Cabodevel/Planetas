namespace Planetas.ApplicationCore.Dtos
{
    public class HazardousAsteroidsRequestDto
    {
        public string PlanetName { get; }
        public int? PageNumber { get; }
        public int? PageSize { get; }

        public HazardousAsteroidsRequestDto(string planetName,

            int? pageNumber,
            int? pageSize)
        {
            PlanetName = planetName;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
