using Server.Models.File;
using Server.Repositories;

namespace Server.Services
{
    internal class FileService(int clientId, FileRepository fileRepository) : IFileWriter
    {
        private readonly string _fileName = GenerateFileName(clientId) ?? 
            throw new NotImplementedException(nameof(_fileName));

        private readonly FileRepository _fileRepository = fileRepository ?? 
            throw new NotImplementedException(nameof(fileRepository));

        public async Task WriteDataAsync(int clientId, int locationId, decimal electricityUsage, string connectionDateAndTime)
        {
            try
            {
                // Creates folder in Documents in File Explorer which is where
                // the files for storing data will be located
                var directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var folderPath = Path.Combine(directory, "SmartMeterData");
                Directory.CreateDirectory(folderPath);

                var file = Path.Combine(folderPath, _fileName);

                await _fileRepository.WriteDataAsync(file, clientId, locationId, electricityUsage, connectionDateAndTime);  

                Console.WriteLine($"Data successfully written to file {clientId}.txt");
            }
            catch
            {
                Console.WriteLine($"Error when storing data for client {clientId}");
            }
        }

        private static string GenerateFileName(int clientId)
        {
            return $"{clientId}.txt";
        }
    }
}
