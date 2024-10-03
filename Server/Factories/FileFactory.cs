using Server.Repositories.File;
using Server.Services.File;

namespace Server.Factories
{
    public class FileFactory
    {
        public virtual IFileService CreateFileService(int clientId, FileRepository fileRepository)
        {
            return new FileService(clientId, fileRepository);
        }
    }
}
