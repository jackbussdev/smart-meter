using System;
using System.Threading.Tasks;
using NetMQ;
using NetMQ.Sockets;
using Newtonsoft.Json;
using Server.Models;

namespace Server;

internal class ServerStartup
{
    public void StartServer()
    {
        Console.WriteLine("Starting Server...");

        using var server = new ResponseSocket();

        server.Bind("tcp://*:5556");
        var msg = server.ReceiveFrameString();
        Console.WriteLine("From Client: {0}", msg);

        Console.ReadLine();


        // use the code below to send date to the server. You will need to create a model similar to the 
        // one i have in order to send the data 
        //
        //
        //
        // using (var client = new RequestSocket())
        //{
        //    client.Connect("tcp://127.0.0.1:5556");
        //    var data = new ClientDataModel()
        //    {
        //        Id = 1,
        //        LocationId = 1,
        //        ElectricityUsage = 0,
        //    };

        //    var serialisedData = JsonConvert.SerializeObject(data);
        //    client.SendFrame(serialisedData);
        //}
    }
}