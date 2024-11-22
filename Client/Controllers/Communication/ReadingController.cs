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

        public string currentStatusMessage { get; private set; }

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

        public string getMessage()
        {
            return currentStatusMessage;
        }

        public void SendReading()
        {

            Random rng = new Random();

            try
            {
                using var client = _rs;
                client.Connect("tcp://localhost:5556"); // TODO: domain potentially?

                while (true)
                {

                    electricityUsage = rng.Next(5, 30);
                    electricityUsageDec = Convert.ToDecimal(electricityUsage);

                    // trigger the event listener
                    ReadingSent.Invoke(this, EventArgs.Empty);

                    // set the data object to be received by the server
                    this.SetClientDataModel(new()
                    {
                        Id = Environment.ProcessId,
                        LocationId = 2,
                        ElectricityUsage = electricityUsageDec,
                        ConnectionDateAndTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ")
                    });

                    var serializedData = JsonConvert.SerializeObject(_clientDataModel); // make it JSON
                    client.SendFrame(serializedData); // send the data to 0MQ Server
                    var resp = client.ReceiveFrameString(); // Await the received
                    var deserialised = JsonConvert.DeserializeObject<PriceCalculationModel>(resp); // deserialise as a PCM

                    if (deserialised is null) // catch when not there
                    {
                        ValidationMessage = "Error when receiving cost from server";
                        Console.WriteLine(ValidationMessage);
                        return; // end loop
                    }

                    string cost = deserialised.Cost.ToString(); // this is the cost
                    currentStatusMessage = deserialised.Message.MessageContent;

                    var sleepFor = rng.Next(15, 60) * 1000; // sleep for rng between 15 and 60 secs
                    Thread.Sleep(sleepFor); // Meet criteria for assignment

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
