namespace Planetas.ApplicationCore.Interfaces
{
    public interface IHttpRequestService
    {
        Task<HttpResponseMessage> Get(string url);
    }
}
