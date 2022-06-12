namespace Planetas.Infrastructure.Interfaces
{
    public interface IHttpRequestService
    {
        Task<HttpResponseMessage> Get(string url);
    }
}
