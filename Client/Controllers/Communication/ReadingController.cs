using NetMQ;
using NetMQ.Sockets;
using Client.Models.Communication;
using Newtonsoft.Json;
using Client.ServiceManager.Interfaces.Controllers.Communication;

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
                //-------------------------------------------------------
                //
                //
                //  Ive had a quick look, i think the reason its sending null
                //  is because you're serialising clientDataModel but not
                //  assigning any of the values (Id, LocationId etc)
                //
                //
                //-------------------------------------------------------
                var serialisedData = JsonConvert.SerializeObject(_clientDataModel);
                client.SendFrame(serialisedData);
                var resp = client.ReceiveFrameString();
                callbackToSetBox(resp);

                Thread.Sleep(2000);
            }
        }
    }
}
