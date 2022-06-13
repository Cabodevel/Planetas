using Newtonsoft.Json;

namespace Planetas.Infrastructure.Models
{
    public class NasaApiResponse
    {
        [JsonProperty("near_earth_objects")]
        public Dictionary<string, IEnumerable<HazardousAsteroid>> NearObjects { get; }

        public NasaApiResponse(Dictionary<string, IEnumerable<HazardousAsteroid>> nearObjects)
        {
            NearObjects = nearObjects;
        }
    }
}
