using Client.Controllers.Communication;
using Client.Models.Communication;
using Client.ServiceManager.Interfaces.Controllers.Communication;

namespace Client
{
    public partial class Form1 : Form
    {
        IReadingController readingController;
        public Form1(IReadingController rc)
        {
            readingController = rc;
            InitializeComponent();

            readingController.SetClientDataModel(new()
            {
                Id = Random.Shared.Next(),
                LocationId = 2,
                ElectricityUsage = 23,
                ConnectionDateAndTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ")
            });

            readingController.SendReading();
        }

        public void receivedReading(string reading)
        {
            richTextBox1.AppendText(reading);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            readingController.SetRichTextBox(receivedReading);

            //readingController.SendReading();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            readingController.SetClientDataModel(new()
            {
                Id = Random.Shared.Next(),
                LocationId = 2,
                ElectricityUsage = 23,
                ConnectionDateAndTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ")
            });

            readingController.SendReading();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RichTextBox.CheckForIllegalCrossThreadCalls = false;
        }
    }
}
