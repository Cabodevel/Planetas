using Newtonsoft.Json;

namespace Planetas.ApplicationCore.Dtos
{
    public class HazardousAsteroidDto
    {
        [JsonProperty("name")]
        public string Name { get; }

        [JsonProperty("estimated_diameter")]
        public EstimatedDiameter EstimatedDiameter { get; }

        [JsonProperty("close_approach_data")]
        public List<CloseApproachData> CloseApproachData { get; }

        [JsonProperty("is_potentially_hazardous_asteroid")]
        public bool IsPotentiallyHazardous { get; }

        public HazardousAsteroidDto(string name,
            EstimatedDiameter estimatedDiameter,
            List<CloseApproachData> closeApproachData,
            bool isPotentiallyHazardous)
        {
            Name = name;
            EstimatedDiameter = estimatedDiameter;
            CloseApproachData = closeApproachData;
            IsPotentiallyHazardous = isPotentiallyHazardous;
        }
    }

    public class CloseApproachData
    {
        [JsonProperty("close_approach_date")]
        public string CloseApproachDate { get; }

        [JsonProperty("relative_velocity")]
        public RelativeVelocity RelativeVelocity { get; }

        [JsonProperty("orbiting_body")]
        public string OrbitingBody { get; }

        public CloseApproachData(string closeApproachDate, RelativeVelocity relativeVelocity, string orbitingBody)
        {
            CloseApproachDate = closeApproachDate;
            RelativeVelocity = relativeVelocity;
            OrbitingBody = orbitingBody;
        }
    }

    public class EstimatedDiameter
    {
        [JsonProperty("kilometers")]
        public Kilometers Kilometers { get; }

        public EstimatedDiameter(Kilometers kilometers)
        {
            Kilometers = kilometers;
        }
    }

    public class Kilometers
    {
        [JsonProperty("estimated_diameter_min")]
        public decimal MinEstimatedDiameter { get; }

        [JsonProperty("estimated_diameter_max")]
        public decimal MaxEstimatedDiameter { get; }

        public Kilometers(decimal minEstimatedDiameter, decimal maxEstimatedDiameter)
        {
            MinEstimatedDiameter = minEstimatedDiameter;
            MaxEstimatedDiameter = maxEstimatedDiameter;
        }
    }

    public class RelativeVelocity
    {
        [JsonProperty("kilometers_per_hour")]
        public decimal KilometersPerHour { get; }

        public RelativeVelocity(decimal kilometersPerHour)
        {
            KilometersPerHour = kilometersPerHour;
        }
    }
}
