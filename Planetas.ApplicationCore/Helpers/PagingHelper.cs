namespace Planetas.ApplicationCore.Helpers
{
    public static class PagingHelper<T>
    {
        public static IEnumerable<T> ApplyPaging(IEnumerable<T> enumerable, int? pageNumber, int? pageSize)
        {
            if (!pageNumber.HasValue || !pageSize.HasValue)
            {
                return enumerable;
            }

            return enumerable.Skip(pageNumber.Value * pageSize.Value).Take(pageSize.Value);
        }

    }
}
