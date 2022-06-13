namespace Planetas.Web.Helpers
{
    public interface IHttpHandler
    {
        Task<HttpResponseMessage> Get(string url);
    }
}
