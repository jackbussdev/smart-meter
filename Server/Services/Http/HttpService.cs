using System.Reflection.Metadata.Ecma335;

namespace Server.Services.Http
{
    public class HttpService(HttpClient httpClient) : IHttpService
    {
        private readonly HttpClient _httpClient = httpClient
            ?? throw new ArgumentNullException(nameof(httpClient));

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await _httpClient.GetAsync(url);
        }
    }
}
