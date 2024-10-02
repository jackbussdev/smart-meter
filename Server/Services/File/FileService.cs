﻿using Server.Models.Client;
using Server.Repositories.File;

namespace Server.Services.File
{
    public class FileService(int clientId, FileRepository fileRepository) : IFileService
    {
        private readonly string _fileName = $"{clientId}_Data_Readings";

        private readonly FileRepository _fileRepository = fileRepository ??
            throw new ArgumentNullException(nameof(fileRepository));

        public async Task WriteDataAsync(ClientDataModel clientData)
        {
            try
            {
                // Creates folder in Documents in File Explorer which is where the
                // files for storing data will be located
                var directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var folderPath = Path.Combine(directory, "SmartMeterData");
                Directory.CreateDirectory(folderPath);

                var file = Path.Combine(folderPath, _fileName + ".json");
                await _fileRepository.WriteDataAsync(file, clientData);

                Console.WriteLine($"Data successfully written to file {clientId}.json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<ClientDataModel>> ReadDataAsync(string file)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(file);

            var dataFromFile = await _fileRepository.ReadDataAsync(file);

            return dataFromFile;
        }
    }
}