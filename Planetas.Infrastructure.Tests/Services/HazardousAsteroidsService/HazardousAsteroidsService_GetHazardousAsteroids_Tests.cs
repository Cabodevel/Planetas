using Planetas.Infrastructure.Interfaces;
using Planetas.Infrastructure.Models;
using Planetas.Infrastructure.Tests.Services.HazardousAsteroids.Fixture;
using Planetas.Infrastructure.Tests.Services.HazardousAsteroids.Parameters;

namespace Planetas.Infrastructure.Tests.Services.HazardousAsteroids
{ 
    public class HazardousAsteroidsService_GetHazardousAsteroids_Tests
    {
        private readonly IHazardousAsteroidsService _sut;
        public HazardousAsteroidsService_GetHazardousAsteroids_Tests()
        {
            _sut = new BasicHazardousAsteroidsServiceFixture().Sut;
        }

        [Theory]
        [ClassData(typeof(DatesParameters))]
        public async void Given_Any_Valid_Date_Should_Not_Throw_ArgumentException(DateTime? fromDate, DateTime? toDate)
        {
            var exception = await Record.ExceptionAsync(async () => await _sut.GetHazardousAsteroids(fromDate, toDate));

            Assert.True(exception is not ArgumentException);
        }

        [Theory]
        [ClassData(typeof(DatesParameters))]
        public async void Given_Any_Valid_Date_Should_Return_NasaApiResponseDto(DateTime? fromDate, DateTime? toDate)
        {
            var response = await _sut.GetHazardousAsteroids(fromDate, toDate);

            Assert.IsType<NasaApiResponse>(response);
        }
    }
}
