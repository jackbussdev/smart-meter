using Server;
using Server.Factories;
using Server.Repositories;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var fileFactory = new FileFactory();
        var fileRepository = new FileRepository();

        ServerController server = new(fileFactory, fileRepository);
        await server.StartServer();
    }
}
