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
        }

        public void receivedReading(string reading)
        {
            richTextBox1.AppendText(reading);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            readingController.SetRichTextBox(receivedReading);

            Thread t = new Thread(new ThreadStart(readingController.SendReading));
            t.Start();
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RichTextBox.CheckForIllegalCrossThreadCalls = false;
        }
    }
}
