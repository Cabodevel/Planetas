using Planetas.ApplicationCore.Dtos;
using Planetas.ApplicationCore.Interfaces;
using Planetas.Tests.ApplicationCore.Services.HazardousAsteroids.Fixture;
using Planetas.Tests.ApplicationCore.Services.HazardousAsteroids.Parameters;

namespace Planetas.Tests.ApplicationCore.Services.HazardousAsteroids
{
    public class HazardousAsteroidsService_FilterNearObjects_Tests
    {
        private readonly IHazardousAsteroidsService _sut;
        
        public HazardousAsteroidsService_FilterNearObjects_Tests()
        {
            _sut = new BasicHazardousAsteroidsServiceFixture().Sut;
        }

        [Fact]
        public void Given_Null_Near_Objects_Should_Throw_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.FilterNearObjects(null, null));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void Given_Invalid_Planet_Name_Should_Throw_ArgumentNullException(string planetName)
        {
            var nearObjects = new List<HazardousAsteroidDto>();
            var filters = new HazardousAsteroidsRequestDto(planetName, null, null);
            Assert.Throws<ArgumentNullException>(() => _sut.FilterNearObjects(nearObjects, filters));
        }

        [Theory]
        [ClassData(typeof(FilterNearObjectsParameters))]
        public void Given_Valid_Inputs_Should_Return_Expected_Paged_Items(IEnumerable<HazardousAsteroidDto> nearObjects, HazardousAsteroidsRequestDto filters, int expected)
        {
            var filteredNearObject = _sut.FilterNearObjects(nearObjects, filters);

            Assert.Equal(filteredNearObject.Data.Count(), expected);
        }

    }
}
