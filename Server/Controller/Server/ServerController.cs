﻿using NetMQ;
using NetMQ.Sockets;
using Newtonsoft.Json;
using Server.Factories;
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

    public string? ValidationMessage { get; set; }

    public async Task StartServer()
    {
        Console.WriteLine("Starting Server...\n");
        try
        {
            // Handle the _server's ReceiveReady event
            _server.ReceiveReady += async (sender, e) => await Server_ReceiveReady(sender, e);

            _poller.Add(_server);

            // Run the _poller asynchronously
            _poller.RunAsync();
            _server.Bind("tcp://*:5556");

            ValidationMessage = "Server successfully started!";
            Console.WriteLine($"{ValidationMessage}\n");
        }
        catch (Exception ex)
        {
            ValidationMessage = $"Server failed to start with error message {ex.Message}";
            Console.WriteLine($"{ValidationMessage}\n");
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
        string dataFromClient = e.Socket.ReceiveFrameString();
        Console.WriteLine($"From Client: {dataFromClient}\n");

        if (dataFromClient is null)
        {
            ValidationMessage = "Error: Client data is empty...";
            Console.WriteLine($"{ValidationMessage}\n");
            return;
        }

        var clientData = JsonConvert.DeserializeObject<ClientDataModel>(dataFromClient);

        if (!IsClientDataValid(clientData!))
        {
            return;
        }

        var cost = await _dataCalculationService.CalculateClientCostAsync(clientData);

        await ProcessClientDataToFileAsync(clientData);
    }

    public async Task ProcessClientDataToFileAsync(ClientDataModel clientData)
    {
        var fileService = _fileFactory.CreateFileService(clientData!.Id, _fileRepository);

        await fileService.WriteDataAsync(clientData);
    }
}