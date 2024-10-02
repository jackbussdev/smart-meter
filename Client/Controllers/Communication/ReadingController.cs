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
using System.ServiceModel.Dispatcher;
using System.Threading;

namespace Client.Controllers.Communication
{
    public class ReadingController : IReadingController
    {
        private RequestSocket _rs;

        private RichTextBox _richTextBox;
        private ClientDataModel _clientDataModel;
        private Action<string> callbackToSetBox;

        public ReadingController(RequestSocket socket)
        {
            _rs = socket;
        }

        public void setClientDataModel(ClientDataModel cdm)
        {
            _clientDataModel = cdm;
        }

        public void setRichTextBox(Action<string> callback)
        {
            callbackToSetBox = callback;
        }

        public void SendReading()
        {
            using var client = _rs;
            while (true)
            {
                var serialisedData = JsonConvert.SerializeObject(_clientDataModel);
                client.SendFrame(serialisedData);
                var resp = client.ReceiveFrameString();
                callbackToSetBox(resp);

                Thread.Sleep(2000);
            }
        }
    }
}
