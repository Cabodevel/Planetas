using Moq;
using Planetas.ApplicationCore.Interfaces;
using Planetas.ApplicationCore.Services;
using Planetas.Infrastructure.Interfaces;
using Planetas.Infrastructure.Models;

namespace Planetas.ApplicationCore.Tests.Services.HazardousAsteroidsApplication.Fixture
{
    public class BasicHazardousAsteroidsServiceFixture
    {
        public IHazardousAsteroidsApplicationService Sut { get; }

        public BasicHazardousAsteroidsServiceFixture()
        {
            var hazardousAsteroids = new List<HazardousAsteroid>
            {
                new HazardousAsteroid("test",
                    new EstimatedDiameter(new Kilometers(1, 5)),
                    new List<CloseApproachData>
                    {
                        new CloseApproachData("2022-01-01", new RelativeVelocity(30M), "Earth")
                    },
                    false),
                new HazardousAsteroid("test",
                    new EstimatedDiameter(new Kilometers(1, 5)),
                    new List<CloseApproachData>
                    {
                        new CloseApproachData("2022-01-01", new RelativeVelocity(30M), "Earth")
                    },
                    false),
                new HazardousAsteroid("test",
                    new EstimatedDiameter(new Kilometers(1, 5)),
                    new List<CloseApproachData>
                    {
                        new CloseApproachData("2022-01-01", new RelativeVelocity(30M), "Earth")
                    },
                    false),
            };

            var nasaApiResponse = new NasaApiResponse(new Dictionary<string, IEnumerable<HazardousAsteroid>>
            {
                { "test", hazardousAsteroids }
            });

            var hazardousAsteroidsService = new Mock<IHazardousAsteroidsService>();

            hazardousAsteroidsService.Setup(s => s.GetHazardousAsteroids(It.IsAny<DateTime?>(), It.IsAny<DateTime?>()))
                .ReturnsAsync(nasaApiResponse);

            Sut = new HazardousAsteroidsApplicationService(hazardousAsteroidsService.Object);
        }
    }
}
