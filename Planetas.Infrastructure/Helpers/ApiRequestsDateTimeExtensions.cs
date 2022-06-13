namespace Planetas.Infrastructure.Helpers
{
    public static class ApiRequestsDateTimeExtensions
    {
        public static string ParseToApiRequestDateTime(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }
    }
}
