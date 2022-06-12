using Planetas.ApplicationCore.Interfaces;
using Planetas.ApplicationCore.Services;

namespace Planetas.Tests.ApplicationCore.Services.HazardousAsteroids
{
    public class BasicHazardousAsteroidsServiceFixture 
    {
        public IHazardousAsteroidsService Sut { get; }

        public BasicHazardousAsteroidsServiceFixture()
        {

            Sut = new HazardousAsteroidsService();
        }
    }
}
