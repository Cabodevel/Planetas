
using Planetas.Infrastructure.Interfaces;
using Planetas.Infrastructure.Services;

namespace Planetas.Tests.ApplicationCore.Services.HttpRequest
{
    public class HttpRequestService_Get_Tests
    {
        private readonly IHttpRequestService _sut;

        public HttpRequestService_Get_Tests()
        {
            _sut = new HttpRequestService();
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("/")]
        [InlineData("http://.com")]
        [InlineData("connection")]
        [InlineData("123456")]
        public async void Given_Malformed_Url_Should_Throw_ArgumentException(string malformedUrl)
        {
            await Assert.ThrowsAsync<ArgumentException>(async () =>await _sut.Get(malformedUrl));
        }
    }
}
