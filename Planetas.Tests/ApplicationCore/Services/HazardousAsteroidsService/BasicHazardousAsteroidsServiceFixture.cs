using Microsoft.Extensions.Options;
using Moq;
using Planetas.API.Configuration.Options;
using Planetas.ApplicationCore.Interfaces;
using Planetas.ApplicationCore.Services;

namespace Planetas.Tests.ApplicationCore.Services.HazardousAsteroids
{
    public class BasicHazardousAsteroidsServiceFixture 
    {
        public IHazardousAsteroidsService Sut { get; }

        public BasicHazardousAsteroidsServiceFixture()
        {
            var nasaOptions = new Mock<IOptions<NasaApiOptions>>();
            nasaOptions.SetupGet(opt => opt.Value).Returns(new NasaApiOptions());

            Sut = new HazardousAsteroidsService(nasaOptions.Object);
        }
    }
}
