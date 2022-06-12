using Planetas.ApplicationCore.Exceptions;
using Planetas.ApplicationCore.Interfaces;
using Planetas.Tests.ApplicationCore.Services.HazardousAsteroids.Fixture;
using Planetas.Tests.ApplicationCore.Services.HazardousAsteroids.Parameters;

namespace Planetas.Tests.ApplicationCore.Services.HazardousAsteroids
{
    public class HazardousAsteroidsService_GetHazardousAsteroids_InvalidResponse_Tests
    {
        private readonly IHazardousAsteroidsService _sut;

        public HazardousAsteroidsService_GetHazardousAsteroids_InvalidResponse_Tests()
        {
            _sut = new HazardousAsteroidsServiceInvalidResponseFixture().Sut;
        }


        [Theory]
        [ClassData(typeof(DatesParameters))]
        public async void Given_Any_Valid_Date_Should_Throw_UnexpectedApiResponseException(DateTime? fromDate, DateTime? toDate)
        {
            await Assert.ThrowsAsync<UnexpectedResponseException>(async ()
                => await _sut.GetHazardousAsteroids(fromDate, toDate));
        }


    }
}
