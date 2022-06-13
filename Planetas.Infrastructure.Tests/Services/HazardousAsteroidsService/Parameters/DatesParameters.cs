using System.Collections;

namespace Planetas.Infrastructure.Tests.Services.HazardousAsteroids.Parameters
{
    public class DatesParameters : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { null, null };
            yield return new object[] { null, DateTime.Now };
            yield return new object[] { DateTime.Now, null };
            yield return new object[] { DateTime.Now, DateTime.Now };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
