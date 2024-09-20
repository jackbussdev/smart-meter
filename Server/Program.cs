using Server;

internal class Program
{
    private static async Task Main(string[] args)
    {
        ServerStartup server = new();
        await server.StartServer();
    }
}
