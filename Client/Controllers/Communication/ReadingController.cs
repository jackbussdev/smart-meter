using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetMQ;
using NetMQ.Sockets;
using Client.Models.Communication;
using Newtonsoft.Json;
using Client.ServiceManager.Interfaces.Controllers.Communication;

namespace Client.Controllers.Communication
{
    internal class ReadingController : IReadingController
    {
        private RequestSocket rs;

        public ReadingController(RequestSocket socket)
        {
            rs = socket;
        }

        public void SendReading(ClientDataModel cdm)
        {
            using (var client = rs)
            {
                //client.Connect("tcp://127.0.0.1:5556");

                var serialisedData = JsonConvert.SerializeObject(cdm);
                client.SendFrame(serialisedData);
            }
        }
    }
}
