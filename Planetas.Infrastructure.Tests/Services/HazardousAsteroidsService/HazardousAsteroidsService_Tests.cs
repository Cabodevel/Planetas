using Planetas.Infrastructure.Interfaces;
using Planetas.Infrastructure.Tests.Services.HazardousAsteroids.Fixture;

namespace Planetas.Infrastructure.Tests.Services.HazardousAsteroids
{
    public class HazardousAsteroidsService_Tests
    {
        private readonly IHazardousAsteroidsService _sut;

        public HazardousAsteroidsService_Tests()
        {
            _sut = new BasicHazardousAsteroidsServiceFixture().Sut;
        }

        [Fact]
        public void Exists()
        {
            Assert.NotNull(_sut);
        }

        [Fact]
        public void Is_IHazardousAsteroidsService()
        {
            Assert.True(_sut is IHazardousAsteroidsService);
        }
    }
}
