namespace Planetas.Web.Helpers
{
    public class HttpHandler : IHttpHandler
    {
        public async Task<HttpResponseMessage> Get(string url)
        {
            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                throw new ArgumentException(nameof(url));
            }

            using var client = new HttpClient();
            return await client.GetAsync(url);
        }
    }
}
