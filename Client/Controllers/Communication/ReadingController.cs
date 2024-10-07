using NetMQ;
using NetMQ.Sockets;
using Client.Models.Communication;
using Newtonsoft.Json;
using Client.ServiceManager.Interfaces.Controllers.Communication;

namespace Client.Controllers.Communication
{
    public class ReadingController : IReadingController
    {
        private DealerSocket _rs;

        private RichTextBox _richTextBox;
        private ClientDataModel _clientDataModel;
        private Action<string> callbackToSetBox;

        public ReadingController(DealerSocket socket)
        {
            _rs = socket;
        }

        public void SetClientDataModel(ClientDataModel cdm)
        {
            _clientDataModel = cdm;
        }

        public void SetRichTextBox(Action<string> callback)
        {
            callbackToSetBox = callback;
        }

        public void SendReading()
        {
            try
            {
                while (true)
                {
                    using var client = _rs;

                    client.Connect("tcp://localhost:5556");
                    var serialisedData = JsonConvert.SerializeObject(_clientDataModel);

                    client.SendMoreFrame("").SendFrame(serialisedData);

                    Thread.Sleep(3000);
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
