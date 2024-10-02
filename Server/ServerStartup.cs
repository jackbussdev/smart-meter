using System;
using System.Threading.Tasks;
using NetMQ;
using NetMQ.Sockets;
using Newtonsoft.Json;
using Server.Models;

namespace Server;

internal class ServerStartup
{
    public async Task StartServer()
    {
        Console.WriteLine("Starting Server...");

        using (var poller = new NetMQPoller())
        {

            using var server = new ResponseSocket());

            server.ReceiveReady += Server_ReceiveReady;
            poller.Add(server);
            poller.RunAsync();
            server.Bind("tcp://*:5556");

            Console.ReadLine();

        }
    }

    private static void Server_ReceiveReady(object sender, NetMQSocketEventArgs e)
    {
        string fromClientMessage = e.Socket.ReceiveFrameString();
        Console.WriteLine("From Client: {0}", fromClientMessage);
        e.Socket.SendFrame("Hi Back");
    }

}