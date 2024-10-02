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
        }

        public void receivedReading(string reading)
        {
            richTextBox1.AppendText(reading);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            readingController.setRichTextBox(receivedReading);

            Thread t = new Thread(new ThreadStart(readingController.SendReading));
            t.Start();




            /*readingController.SendReading(new()
            {
                Id = 2,
                LocationId = 47,
                ElectricityUsage = 500,
            }, richTextBox1);*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            readingController.setClientDataModel(new()
            {
                Id = 1,
                LocationId = 45,
                ElectricityUsage = Random.Shared.NextInt64()
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RichTextBox.CheckForIllegalCrossThreadCalls = false;
        }
    }
}
