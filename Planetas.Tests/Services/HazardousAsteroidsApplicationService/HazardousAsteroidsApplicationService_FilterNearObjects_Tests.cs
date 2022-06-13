using Planetas.ApplicationCore.Dtos;
using Planetas.ApplicationCore.Interfaces;
using Planetas.ApplicationCore.Tests.Services.HazardousAsteroidsApplication.Fixture;
using Planetas.Tests.ApplicationCore.Services.HazardousAsteroids.Parameters;

namespace Planetas.ApplicationCore.Tests.Services.HazardousAsteroidsApplication
{
    public class HazardousAsteroidsApplicationService_FilterNearObjects_Tests
    {
        private readonly IHazardousAsteroidsApplicationService _sut;
        
        public HazardousAsteroidsApplicationService_FilterNearObjects_Tests()
        {
            _sut = new BasicHazardousAsteroidsServiceFixture().Sut;
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async void Given_Invalid_Planet_Name_Should_Throw_ArgumentNullException(string planetName)
        {
            var filters = new HazardousAsteroidsRequestDto(planetName, null, null, null, null);
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await _sut.FilterNearObjects( filters));
        }

        [Theory]
        [ClassData(typeof(FilterNearObjectsParameters))]
        public async void Given_Valid_Inputs_Should_Return_Expected_Paged_Items(HazardousAsteroidsRequestDto filters, int expected)
        {
            var filteredNearObject = await _sut.FilterNearObjects(filters);

            Assert.Equal(filteredNearObject.Data.Count(), expected);
        }
    }
}
