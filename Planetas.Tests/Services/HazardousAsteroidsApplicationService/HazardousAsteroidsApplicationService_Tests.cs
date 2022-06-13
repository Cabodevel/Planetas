using Planetas.ApplicationCore.Interfaces;
using Planetas.ApplicationCore.Tests.Services.HazardousAsteroidsApplication.Fixture;

namespace Planetas.ApplicationCore.Tests.Services.HazardousAsteroidsApplication
{
    public class HazardousAsteroidsApplicationService_Tests
    {
        private readonly IHazardousAsteroidsApplicationService _sut;
        
        public HazardousAsteroidsApplicationService_Tests()
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
            Assert.True(_sut is IHazardousAsteroidsApplicationService);
        }


    }
}
