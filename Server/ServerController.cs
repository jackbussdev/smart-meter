using NetMQ;
using NetMQ.Sockets;
using Newtonsoft.Json;
using Server.Factories;
using Server.Models.Client;
using Server.Repositories.File;
using System.Runtime.CompilerServices;

namespace Server;

public class ServerController(FileFactory fileFacotry, FileRepository fileRepository)
{
    private readonly FileFactory _fileFactory = fileFacotry ??
                throw new ArgumentNullException(nameof(fileFacotry));

    private readonly FileRepository _fileRepository = fileRepository ??
                throw new ArgumentNullException(nameof(fileRepository));

    public async Task StartServer()
    {
        Console.WriteLine("Starting Server...\n");

        // Start server and accept client message
        using var server = new ResponseSocket();
        server.Bind("tcp://*:5556");
        var dataFromClient = server.ReceiveFrameString();

        if (dataFromClient is null)
        {
            Console.WriteLine("Error: Client data is empty...");
            return;
        }

        var clientDataAsString = JsonConvert.DeserializeObject<ClientDataModel>(dataFromClient);

        if (!IsClientDataValid(clientDataAsString!)) 
        { 
            return; 
        }

        var fileService = _fileFactory.CreateFileWriter(clientDataAsString!.Id, _fileRepository);

        await fileService.WriteDataAsync(clientDataAsString);

        Console.ReadLine();
    }

    private bool IsClientDataValid(ClientDataModel clientData)
    {
        if (clientData.Id == 0)
        {
            Console.WriteLine("Error when verifying client");
            Console.ReadLine();
            return false;
        }

        if (clientData.LocationId == 0)
        {
            Console.WriteLine("Error when verifying client's location");
            Console.ReadLine();
            return false;
        }

        if (string.IsNullOrEmpty(clientData.ConnectionDateAndTime))
        {
            Console.WriteLine("Error when verifying client's time of connection");
            Console.ReadLine();
            return false;
        }

        return true;
    }
}