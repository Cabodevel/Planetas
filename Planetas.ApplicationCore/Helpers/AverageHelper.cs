namespace Planetas.ApplicationCore.Helpers
{
    public static class AverageHelper
    {
        public static decimal DecimalAverage(params decimal[] decimals)
        {
            return decimals.Average();
        }
    }
}
