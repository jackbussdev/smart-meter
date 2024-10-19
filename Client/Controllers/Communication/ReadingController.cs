using NetMQ;
using NetMQ.Sockets;
using Client.Models.Communication;
using Newtonsoft.Json;
using Client.ServiceManager.Interfaces.Controllers.Communication;
using Client.Models;

namespace Client.Controllers.Communication
{
    public class ReadingController : IReadingController
    {
        private RequestSocket _rs;
        private RichTextBox _richTextBox;
        private ClientDataModel _clientDataModel;
        private Action<string> callbackToSetBox;

        public string? ValidationMessage { get; set; }

        public ReadingController(RequestSocket socket)
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
                using var client = _rs;
                client.Connect("tcp://localhost:5556");

                while (true)
                {
                    var serializedData = JsonConvert.SerializeObject(_clientDataModel);
                    client.SendFrame(serializedData);
                    var resp = client.ReceiveFrameString();
                    var deserialised = JsonConvert.DeserializeObject<PriceCalculationModel>(resp);

                    if (deserialised is null)
                    {
                        ValidationMessage = "Error when receiving cost from server";
                        Console.WriteLine(ValidationMessage);
                        return;
                    }

                    string cost = deserialised.Cost.ToString();
                    //callbackToSetBox("This costed you " + (cost ?? "NO PRICE RETURNED"));
                    Thread.Sleep(2000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
