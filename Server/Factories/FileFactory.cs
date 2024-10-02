using Server.Repositories.File;
using Server.Services.File;

namespace Server.Factories
{
    public class FileFactory
    {
        public IFileService CreateFileWriter(int clientId, FileRepository fileRepository)
        {
            return new FileService(clientId, fileRepository);
        }
    }
}
