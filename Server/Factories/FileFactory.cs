using Server.Models.File;
using Server.Repositories;
using Server.Services;

namespace Server.Factories
{
    public class FileFactory
    {
        public IFileWriter CreateFileWriter(int clientId, FileRepository fileRepository)
        {
            return new FileService(clientId, fileRepository);
        }
    }
}
