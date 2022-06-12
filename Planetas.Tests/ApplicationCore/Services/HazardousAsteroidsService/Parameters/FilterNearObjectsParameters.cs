using Planetas.ApplicationCore.Dtos;
using System.Collections;

namespace Planetas.Tests.ApplicationCore.Services.HazardousAsteroids.Parameters
{
    public class FilterNearObjectsParameters : IEnumerable<object[]>
    {
        private List<HazardousAsteroidDto> hazardousAsteroids = new List<HazardousAsteroidDto>
        {
            new HazardousAsteroidDto("test",
                new EstimatedDiameter(new Kilometers(1, 5)),
                new List<CloseApproachData>
                {
                    new CloseApproachData("2022-01-01", new RelativeVelocity(30M), "Earth")
                },
                false),
            new HazardousAsteroidDto("test",
                new EstimatedDiameter(new Kilometers(1, 5)),
                new List<CloseApproachData>
                {
                    new CloseApproachData("2022-01-01", new RelativeVelocity(30M), "Earth")
                },
                false),
            new HazardousAsteroidDto("test",
                new EstimatedDiameter(new Kilometers(1, 5)),
                new List<CloseApproachData>
                {
                    new CloseApproachData("2022-01-01", new RelativeVelocity(30M), "Earth")
                },
                false),
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { hazardousAsteroids, new HazardousAsteroidsRequestDto("Earth", 0, 0), 0 };
            yield return new object[] { hazardousAsteroids, new HazardousAsteroidsRequestDto("Earth", 1, 1), 1 };
            yield return new object[] { hazardousAsteroids, new HazardousAsteroidsRequestDto("Earth", 0, 2), 2 };
            yield return new object[] { hazardousAsteroids, new HazardousAsteroidsRequestDto("Earth", null, null), 3 };
            yield return new object[] { hazardousAsteroids, new HazardousAsteroidsRequestDto("Mars", null, null), 0};
            yield return new object[] { hazardousAsteroids, new HazardousAsteroidsRequestDto("Earth", 1, 10), 0 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
