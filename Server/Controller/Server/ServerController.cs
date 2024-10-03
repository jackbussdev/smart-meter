using NetMQ;
using NetMQ.Sockets;
using Newtonsoft.Json;
using Server.Factories;
using Server.Models.Client;
using Server.Repositories.File;

// https://zeromq.org/languages/csharp/ - Tought me the basics of how to allow communication between clients 
// and servers using ZeroMQ in C#

namespace Server.Controller.Server;

public class ServerController(FileFactory fileFacotry, FileRepository fileRepository)
{
    private readonly FileFactory _fileFactory = fileFacotry ??
                throw new ArgumentNullException(nameof(fileFacotry));

    private readonly FileRepository _fileRepository = fileRepository ??
                throw new ArgumentNullException(nameof(fileRepository));

    private NetMQPoller poller;
    private ResponseSocket server;

    public string ValidationError { get; set; }

    public async Task StartServer()
    {
        Console.WriteLine("Starting Server...\n");
        try
        {
            poller = [];
            server = new ResponseSocket();

            // Handle the server's ReceiveReady event
            server.ReceiveReady += async (sender, e) => await Server_ReceiveReady(sender, e);

            poller.Add(server);

            // Run the poller asynchronously
            poller.RunAsync();
            server.Bind("tcp://*:5556");

            ValidationError = "Server successfully started!\n";
        }
        catch (Exception ex)
        {
            ValidationError = $"Server failed to start with error message {ex.Message}";
        }

        Console.ReadLine();
    }

    public bool IsClientDataValid(ClientDataModel clientData)
    {
        if (clientData.Id == 0)
        {
            ValidationError = "Error when verifying client";
            return false;
        }

        if (clientData.LocationId == 0)
        {
            ValidationError = "Error when verifying client's location";
            return false;
        }

        if (string.IsNullOrEmpty(clientData.ConnectionDateAndTime))
        {
            ValidationError = "Error when verifying client's time of connection";
            return false;
        }

        return true;
    }

    private async Task Server_ReceiveReady(object sender, NetMQSocketEventArgs e)
    {
        string dataFromClient = e.Socket.ReceiveFrameString();
        Console.WriteLine("From Client: {0}", dataFromClient);

        if (dataFromClient is null)
        {
            Console.WriteLine("Error: Client data is empty...");
            return;
        }

        await ProcessClientData(dataFromClient);
    }

    public async Task ProcessClientData(string dataFromClient)
    {
        var clientData = JsonConvert.DeserializeObject<ClientDataModel>(dataFromClient);

        if (!IsClientDataValid(clientData!))
        {
            return;
        }

        var fileService = _fileFactory.CreateFileService(clientData!.Id, _fileRepository);

        await fileService.WriteDataAsync(clientData);
    }
}