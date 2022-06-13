namespace Planetas.ApplicationCore.Dtos
{
    public class HazardousAsteroidsRequestDto
    {
        public string PlanetName { get; }
        public DateTime? FromDate { get; }
        public DateTime? ToDate { get; }
        public int? PageNumber { get; }
        public int? PageSize { get; }

        public HazardousAsteroidsRequestDto(
            string planetName, 
            DateTime? fromDate, 
            DateTime? toDate, 
            int? pageNumber, 
            int? pageSize)
        {
            PlanetName = planetName;
            FromDate = fromDate;
            ToDate = toDate;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
