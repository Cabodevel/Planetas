using Newtonsoft.Json;

namespace Planetas.ApplicationCore.Dtos
{
    public class NasaApiResponseDto
    {
        [JsonProperty("near_earth_objects")]
        public Dictionary<string, IEnumerable<HazardousAsteroidDto>> NearObjects { get; }

        public NasaApiResponseDto(Dictionary<string, IEnumerable<HazardousAsteroidDto>> nearObjects)
        {
            NearObjects = nearObjects;
        }
    }
}
