using Planetas.ApplicationCore.Dtos;
using Planetas.ApplicationCore.Helpers;
using Planetas.ApplicationCore.Interfaces;
using Planetas.Infrastructure.Interfaces;
using Planetas.Infrastructure.Models;

namespace Planetas.ApplicationCore.Services
{
    public class HazardousAsteroidsApplicationService : IHazardousAsteroidsApplicationService
    {
        private readonly IHazardousAsteroidsService _hazardousAsteroidsService;

        public HazardousAsteroidsApplicationService(IHazardousAsteroidsService hazardousAsteroidsService)
        {
            _hazardousAsteroidsService = hazardousAsteroidsService ?? throw new ArgumentNullException(nameof(hazardousAsteroidsService));
        }
            
        public async Task<HazardousAsteroidsFilteredDataDto> FilterNearObjects( HazardousAsteroidsRequestDto filters)
        {
            if (string.IsNullOrWhiteSpace(filters?.PlanetName))
            {
                throw new ArgumentNullException(nameof(filters));
            }

            var nearObjects = await _hazardousAsteroidsService.GetHazardousAsteroids(filters.FromDate, filters.ToDate);

            var hazardousAsteroids = nearObjects.NearObjects.Values
                .SelectMany(no => no)
                .GroupBy(no => no.CloseApproachData.Select(cad => cad.OrbitingBody.ToLowerInvariant()))
                .Where(group => group.Key.ToList().Contains(filters.PlanetName.ToLowerInvariant()))
                .SelectMany(groupResult => groupResult);

            var filteredCount = hazardousAsteroids.Count();

            var pagedAsteroids = PagingHelper<HazardousAsteroid>.ApplyPaging(hazardousAsteroids, filters.PageNumber, filters.PageSize);

            return new HazardousAsteroidsFilteredDataDto(filteredCount, pagedAsteroids);
        }

      
    }
}
