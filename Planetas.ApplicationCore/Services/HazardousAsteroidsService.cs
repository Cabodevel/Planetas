using Microsoft.Extensions.Options;
using Planetas.API.Configuration.Options;
using Planetas.ApplicationCore.Dtos;
using Planetas.ApplicationCore.Interfaces;

namespace Planetas.ApplicationCore.Services
{
    public class HazardousAsteroidsService : IHazardousAsteroidsService
    {
        private readonly NasaApiOptions _nasaApiOptions;
        public HazardousAsteroidsService(IOptions<NasaApiOptions> nasaApiOptions)
        {
            _nasaApiOptions = nasaApiOptions?.Value ?? throw new ArgumentNullException(nameof(nasaApiOptions));
        }

        public async Task<NasaApiResponseDto> GetHazardousAsteroids(DateTime? fromDate, DateTime? toDate)
        {
            return new NasaApiResponseDto(new Dictionary<string, IEnumerable<HazardousAsteroidDto>>());
        }
    }
}
