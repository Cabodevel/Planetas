using Microsoft.Extensions.Options;
using Moq;
using Newtonsoft.Json;
using Planetas.API.Configuration.Options;
using Planetas.ApplicationCore.Dtos;
using Planetas.ApplicationCore.Interfaces;
using Planetas.ApplicationCore.Services;
using Planetas.Infrastructure.Interfaces;

namespace Planetas.Tests.ApplicationCore.Services.HazardousAsteroids
{
    public class BasicHazardousAsteroidsServiceFixture
    {
        public IHazardousAsteroidsService Sut { get; }

        public BasicHazardousAsteroidsServiceFixture()
        {
            var nasaOptions = new Mock<IOptions<NasaApiOptions>>();

            nasaOptions.SetupGet(opt => opt.Value)
                .Returns(new NasaApiOptions { ApiKey = "test", Url = "http://localhost" });

            var apiDataMock = JsonConvert.SerializeObject(new NasaApiResponseDto(new Dictionary<string, IEnumerable<HazardousAsteroidDto>>()));

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
