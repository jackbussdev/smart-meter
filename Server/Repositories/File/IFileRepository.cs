using Server.Models.Client;

namespace Server.Repositories.File
{
    /// <summary>
    /// File Repository
    /// </summary>
    public interface IFileRepository
    {
        /// <summary>
        /// Write Data to file asynchronously
        /// </summary>
        /// <param name="clientData"></param>
        /// <param name="file"></param>
        public Task WriteDataAsync(string file, ClientDataModel clientData);

        /// <summary>
        /// Read Data from a file asynchronously
        /// </summary>
        /// <param name="file"></param>
        public Task<List<ClientDataModel>> ReadDataAsync(string file);
    }
}
