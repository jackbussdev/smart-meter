namespace Server.Services.Http
{
    /// <summary>
    /// Http Service
    /// </summary>
    public interface IHttpService
    {
        /// <summary>
        /// Get data asynchronously 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> GetAsync(string url);
    }
}
