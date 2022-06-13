using Microsoft.Extensions.Options;
using Moq;
using Planetas.Infrastructure.Interfaces;
using Planetas.Infrastructure.Options;
using Planetas.Infrastructure.Services;

namespace Planetas.Infrastructure.Tests.Services.HazardousAsteroids.Fixture
{
    internal class HazardousAsteroidsServiceInvalidResponseFixture
    {
        public IHazardousAsteroidsService Sut { get; }

        public HazardousAsteroidsServiceInvalidResponseFixture()
        {
            var nasaOptions = new Mock<IOptions<NasaApiOptions>>();

            nasaOptions.SetupGet(opt => opt.Value)
                .Returns(new NasaApiOptions { ApiKey = "test", Url = "http://localhost" });


            var httpService = new Mock<IHttpRequestService>();

            httpService.Setup(s => s.Get(It.IsAny<string>()))
                .ReturnsAsync(new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest));

            Sut = new HazardousAsteroidsService(nasaOptions.Object, httpService.Object);
        }
    }
}
