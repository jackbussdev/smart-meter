using Server;
using Server.Factories;
using Server.Repositories.File;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var serviceProvider = BuildServiceProvider();

        var server = serviceProvider.GetRequiredService<ServerController>();
        await server.StartServer();
    }

    private static ServiceProvider BuildServiceProvider()
    {
        var services = new ServiceCollection();
        services.AddSingleton<FileFactory>();
        services.AddSingleton<FileRepository>();
        services.AddSingleton<ServerController>();

        return services.BuildServiceProvider();
    }
}
