using Microsoft.Extensions.Options;
using Moq;
using Newtonsoft.Json;
using Planetas.Infrastructure.Interfaces;
using Planetas.Infrastructure.Models;
using Planetas.Infrastructure.Options;
using Planetas.Infrastructure.Services;

namespace Planetas.Infrastructure.Tests.Services.HazardousAsteroids.Fixture
{
    public class BasicHazardousAsteroidsServiceFixture
    {
        public IHazardousAsteroidsService Sut { get; }

        public BasicHazardousAsteroidsServiceFixture()
        {
            var nasaOptions = new Mock<IOptions<NasaApiOptions>>();

            nasaOptions.SetupGet(opt => opt.Value)
                .Returns(new NasaApiOptions { ApiKey = "test", Url = "http://localhost" });

            var apiDataMock = JsonConvert.SerializeObject(new NasaApiResponse(new Dictionary<string, IEnumerable<HazardousAsteroid>>()));

            var httpService = new Mock<IHttpRequestService>();

            httpService.Setup(s => s.Get(It.IsAny<string>()))
                .ReturnsAsync(
                    new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                    {
                        Content = new StringContent(apiDataMock)
                    });

            Sut = new HazardousAsteroidsService(nasaOptions.Object, httpService.Object);
        }
    }
}
