namespace Server.Models.File
{
    /// <summary>
    /// File Writer
    /// </summary>
    public interface IFileWriter
    {
        /// <summary>
        /// Write Data to file asynchronously
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="locationId"></param>
        /// <param name="electricityUsage"></param>
        /// <param name="connectionDateAndTime"></param>
        public Task WriteDataAsync(int clientId, int locationId, decimal electricityUsage, string connectionDateAndTime);
    }
}
