using Microsoft.Extensions.Options;
using Planetas.API.Configuration.Options;
using Planetas.ApplicationCore.Dtos;
using Planetas.ApplicationCore.Interfaces;

namespace Planetas.ApplicationCore.Services
{
    public class HazardousAsteroidsService : IHazardousAsteroidsService
    {
        private readonly NasaApiOptions _nasaApiOptions;
        private readonly IHttpRequestService _httpRequestService;
        public HazardousAsteroidsService(IOptions<NasaApiOptions> nasaApiOptions, IHttpRequestService httpRequestService)
        {
            _nasaApiOptions = nasaApiOptions?.Value ?? throw new ArgumentNullException(nameof(nasaApiOptions));
            _httpRequestService = httpRequestService ?? throw new ArgumentNullException(nameof(httpRequestService));
        }

        public async Task<NasaApiResponseDto> GetHazardousAsteroids(DateTime? fromDate, DateTime? toDate)
        {
            return new NasaApiResponseDto(new Dictionary<string, IEnumerable<HazardousAsteroidDto>>());
        }
    }
}
