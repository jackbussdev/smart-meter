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
        public event EventHandler ReadingSent;

        private RequestSocket _rs;
        private RichTextBox _richTextBox;
        private ClientDataModel _clientDataModel;
        private Action<string> callbackToSetBox;


        public float electricityUsage { get; private set; }
        public decimal electricityUsageDec { get; private set; }

        public string? ValidationMessage { get; set; }

        public ReadingController(RequestSocket socket)
        {
            _rs = socket;
        }

        public float getElectricityUsage()
        {
            return this.electricityUsage;
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

            Random rng = new Random();

            try
            {
                using var client = _rs;
                client.Connect("tcp://localhost:5556");

                while (true)
                {

                    electricityUsage = rng.Next(5, 30);
                    electricityUsageDec = Convert.ToDecimal(electricityUsage);

                    ReadingSent.Invoke(this, EventArgs.Empty);

                    this.SetClientDataModel(new()
                    {
                        Id = Random.Shared.Next(),
                        LocationId = 2,
                        ElectricityUsage = electricityUsageDec,
                        ConnectionDateAndTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ")
                    });

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
