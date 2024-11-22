using NetMQ;
using NetMQ.Sockets;
using Newtonsoft.Json;
using Server.Factories;
using Server.Models;
using Server.Models.Client;
using Server.Repositories.File;
using Server.Services.DataCalculation;

// https://zeromq.org/languages/csharp/ - Tought the basics of how to allow communication between clients 
// and servers using ZeroMQ in C#

namespace Server.Controller.Server;

public class ServerController(FileFactory fileFacotry, 
    FileRepository fileRepository, 
    DataCalculationService dataCalculationService)
{
    private readonly FileFactory _fileFactory = fileFacotry 
        ?? throw new ArgumentNullException(nameof(fileFacotry));

    private readonly FileRepository _fileRepository = fileRepository 
        ?? throw new ArgumentNullException(nameof(fileRepository));

    private readonly DataCalculationService _dataCalculationService = dataCalculationService
        ?? throw new ArgumentNullException(nameof(dataCalculationService));

    private NetMQPoller _poller = [];
    private ResponseSocket _server = new();

    private MessageModel message;

    private ResponseSocket _instructionalServer = new();

    public string? ValidationMessage { get; set; }

    public async Task StartServer()
    {
        Console.WriteLine("Starting Server...\n");

        try
        {
            _server.Bind("tcp://*:5556");

            _server.ReceiveReady += async (sender, e) => await Server_ReceiveReady(sender!, e);

            _instructionalServer.Bind("tcp://*:5557");
            _instructionalServer.ReceiveReady += async (sender, e) => await InsServer_ReceiveReady(sender!, e);

            // Polling for incoming messages
            _poller.Add(_server);
            _poller.Add(_instructionalServer);
            _poller.RunAsync();

            Console.WriteLine("Server(s) successfully started!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Server(s) failed to start with error message {ex.Message}");
        }

        Console.ReadLine();
    }

    public bool IsClientDataValid(ClientDataModel clientData)
    {
        if (clientData.Id == 0)
        {
            ValidationMessage = "Error when verifying client";
            Console.WriteLine($"{ValidationMessage}\n");
            return false;
        }

        if (clientData.LocationId == 0)
        {
            ValidationMessage = "Error when verifying client's location";
            Console.WriteLine($"{ValidationMessage}\n");
            return false;
        }

        if (string.IsNullOrEmpty(clientData.ConnectionDateAndTime))
        {
            ValidationMessage = "Error when verifying client's time of connection";
            Console.WriteLine($"{ValidationMessage}\n");
            return false;
        }

        return true;
    }

    public async Task Server_ReceiveReady(object sender, NetMQSocketEventArgs e)
    {

        var serializedData = e.Socket.ReceiveFrameString();

        Console.WriteLine($"From Client: {serializedData}\n");

        if (serializedData is null)
        {
            ValidationMessage = "Error: client data is empty...";
            Console.WriteLine($"{ValidationMessage}\n");
            return;
        }

        await ProcessClientData(serializedData);

        var msg = message;

        PriceCalculationModel pcm = new()
        {
            Cost = 20.00m,
            Message = msg ?? new()
            {
                MessageContent = ""
            }!
        };

        var serialisedCost = JsonConvert.SerializeObject(pcm);

        // Sends the cost back to the client
        e.Socket.SendFrame(serialisedCost); 
    }


    public async Task InsServer_ReceiveReady(object sender, NetMQSocketEventArgs e)
    {

        var serializedData = e.Socket.ReceiveFrameString();

        Console.WriteLine($"From Client: {serializedData}\n");

        if (serializedData is null)
        {
            ValidationMessage = "Error: client data is empty...";
            Console.WriteLine($"{ValidationMessage}\n");
            return;
        }

        dynamic acim = JsonConvert.DeserializeObject(serializedData)!;

        message = new() // set new messagemodel to messages queue
        {
            Region = acim.data.region,
            MessageContent = acim.data.message
        };

        AdminClientInstructionReceivedModel acirm = new()
        {
            Action = acim.action,
            Data = acim.data

        };

        var acirmToReturn = JsonConvert.SerializeObject(acirm);

        // Sends the cost back to the client
        e.Socket.SendFrame(acirmToReturn);
    }

    public async Task ProcessClientData(string dataFromClient)
    {
        var clientData = JsonConvert.DeserializeObject<ClientDataModel>(dataFromClient);

        if (!IsClientDataValid(clientData!) || clientData is null)
        {
            return;
        }

        var cost = await _dataCalculationService.GetClientCostAsync(clientData);

        if (cost == 0)
        {
            ValidationMessage = "Error when calculating client electricity cost";
            Console.WriteLine($"{ValidationMessage}\n");
            return;
        }

        clientData.Cost = cost;

        await ProcessClientDataToFileAsync(clientData);
    }

    public async Task ProcessClientDataToFileAsync(ClientDataModel clientData)
    {
        var fileService = _fileFactory.CreateFileService(clientData!.Id, _fileRepository);

        await fileService.WriteDataAsync(clientData);
    }
}