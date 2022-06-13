using Planetas.ApplicationCore.Dtos;
using System.Collections;

namespace Planetas.Tests.ApplicationCore.Services.HazardousAsteroids.Parameters
{
    public class FilterNearObjectsParameters : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new HazardousAsteroidsRequestDto("Earth", null, null, 0, 0), 0 };
            yield return new object[] { new HazardousAsteroidsRequestDto("Earth", null, null, 1, 1), 1 };
            yield return new object[] { new HazardousAsteroidsRequestDto("Earth", null, null, 0, 2), 2 };
            yield return new object[] { new HazardousAsteroidsRequestDto("Earth", null, null, null, null), 3 };
            yield return new object[] { new HazardousAsteroidsRequestDto("Mars", null, null, null, null), 0 };
            yield return new object[] { new HazardousAsteroidsRequestDto("Earth", null, null, 1, 10), 0 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
