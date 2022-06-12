using Microsoft.Extensions.Options;
using Moq;
using Planetas.API.Configuration.Options;
using Planetas.ApplicationCore.Interfaces;
using Planetas.ApplicationCore.Services;
using Planetas.Infrastructure.Interfaces;

namespace Planetas.Tests.ApplicationCore.Services.HazardousAsteroids.Fixture
{
    public class HazardousAsteroidsServiceInvalidResponseFixture
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
