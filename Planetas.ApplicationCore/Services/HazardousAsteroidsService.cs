using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Planetas.API.Configuration.Options;
using Planetas.ApplicationCore.Dtos;
using Planetas.ApplicationCore.Exceptions;
using Planetas.ApplicationCore.Helpers;
using Planetas.ApplicationCore.Interfaces;
using Planetas.Infrastructure.Interfaces;

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
            var requestUrl = MapRequestUrl(fromDate, toDate);

            var requestResponseMessage = await _httpRequestService.Get(requestUrl);

            if (!requestResponseMessage.IsSuccessStatusCode)
            {
                throw new UnexpectedResponseException(
                    $"{nameof(HazardousAsteroidsService)}, {nameof(GetHazardousAsteroids)}" +
                    $": unexpected response message, see inner exception for details"
                    , new Exception(requestResponseMessage.ReasonPhrase));
            }

            var content = await requestResponseMessage.Content.ReadAsStringAsync();

            var apiResponse = JsonConvert.DeserializeObject<NasaApiResponseDto>(content);

            return apiResponse;
        }

        private string MapRequestUrl(DateTime? start, DateTime? end)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"api_key", _nasaApiOptions.ApiKey }
            };

            if (start.HasValue)
            {
                queryParameters.Add("start_date", start.Value.ParseToApiRequestDateTime());
            }

            if (end.HasValue)
            {
                queryParameters.Add("end_date", end.Value.ParseToApiRequestDateTime());
            }

            var queryUrl = new Uri(QueryHelpers.AddQueryString(_nasaApiOptions.Url, queryParameters));

            return queryUrl.ToString();
        }
    }
}
