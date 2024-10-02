using Server.Models.Client;

namespace Server.Services.File
{
    /// <summary>
    /// File Service
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Write Data to file asynchronously
        /// </summary>
        /// <param name="clientData"></param>
        public Task WriteDataAsync(ClientDataModel clientData);

        /// <summary>
        /// Read Data from a file asynchronously
        /// </summary>
        /// <param name="file"></param>
        public Task<List<ClientDataModel>> ReadDataAsync(string file);
    }
}
