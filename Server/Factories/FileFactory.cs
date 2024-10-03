using Server.Repositories.File;
using Server.Services.File;

// https://refactoring.guru/design-patterns/factory-method/csharp/example - tought how to implement
// the fatory design pattern in C#

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
