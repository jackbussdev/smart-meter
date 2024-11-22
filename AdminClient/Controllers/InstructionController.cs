﻿using AdminClient.Models;
using AdminClient.Models.Instructions;
using AdminClient.ServiceManager.Events;
using AdminClient.ServiceManager.Interfaces.Controllers;
using NetMQ;
using NetMQ.Sockets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminClient.Controllers
{
    internal class InstructionController : IInstructionController
    {
        public event EventHandler<InstructionFailSendEventArgs> InstructionFailed;

        public RequestSocket _rs;

        public InstructionController(RequestSocket socket)
        {
            _rs = socket;
        }


        public void SendMessage(AdminClient.Models.Instructions.Message msg)
        {
            object message = new
            {
                action = "send_message",
                data = new
                {
                    region = msg.Location,
                    message = msg.MessageBody
                }
            };

            try
            {

                var client = _rs;

                var serializedData = JsonConvert.SerializeObject(message); // make it JSON
                client.SendFrame(serializedData); // send the data to 0MQ Server
                var resp = client.ReceiveFrameString(); // Await the received
                dynamic deserialised = JsonConvert.DeserializeObject<AdminClientInstructionReceivedModel>(resp)!; // deserialise as a ACIRM

                if (deserialised is null) // catch when not there
                {
                    var ValidationMessage = "Error when receiving cost from server";
                    Console.WriteLine(ValidationMessage);
                    return; // end loop
                }

                switch (deserialised.Action)
                {
                    case "send_message":
                        if(deserialised.message == msg.MessageBody)
                        {
                            Console.WriteLine("EQUAL");
                        }
                        else
                        {
                            Console.WriteLine("NOT EQUAL");
                        }
                        break;
                    case "retrieve_otp":
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                InstructionFailedError ife = new()
                {
                    ExceptionMessage = ex.Message
                };

                InstructionFailed?.Invoke(this, new(ife));
            }


        }
    }
}