using NetMQ;
using NetMQ.Sockets;
using Newtonsoft.Json;
using Server.Factories;
using Server.Models.Client;
using Server.Repositories;

namespace Server;

public class ServerController(FileFactory fileFacotry, FileRepository fileRepository)
{
    private readonly FileFactory _fileFactory = fileFacotry ??
                throw new ArgumentNullException(nameof(fileFacotry));

    private readonly FileRepository _fileRepository = fileRepository ??
                throw new ArgumentNullException(nameof(fileRepository));

    public async Task StartServer()
    {
        Console.WriteLine("Starting Server...");

        // Start server and accept client message
        using var server = new ResponseSocket();
        server.Bind("tcp://*:5556");
        var message = server.ReceiveFrameString();

        if (message is null)
        {
            Console.WriteLine("Client data is empty...");
            return;
        }

        var clientData = JsonConvert.DeserializeObject<ClientDataModel>(message);

        var fileService = _fileFactory.CreateFileWriter(clientData!.Id, _fileRepository);

        await fileService.WriteDataAsync(clientData.Id, clientData.LocationId, clientData.ElectricityUsage, clientData.ConnectionDateAndTime);

        Console.ReadLine();
    }
}