using Client.Controllers.Communication;
using Client.Models.Communication;
using Client.ServiceManager.Interfaces.Controllers.Communication;
using MindFusion.Gauges;
using System.Data;

namespace Client
{
    public partial class Form1 : Form
    {
        IReadingController readingController;
        float electricityUsage;
        decimal electricityUsageDec;
        public Form1(IReadingController rc)
        {
            readingController = rc;
            InitializeComponent();

            Random rng = new Random();
            electricityUsage = rng.Next(5, 30);
            electricityUsageDec = Convert.ToDecimal(electricityUsage);

            readingController.SetClientDataModel(new()
            {
                Id = Random.Shared.Next(),
                LocationId = 2,
                ElectricityUsage = electricityUsageDec,
                ConnectionDateAndTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ")
            });

            #region GAUGE LOGIC
            today_Gauge.Scales[0].Ranges[0].MaxValue = electricityUsage;
            today_Gauge.Scales[0].Pointers[0].Value = electricityUsage;
            //if(electricityUsage <= 23 && electricityUsage >= 15)
            // {
            //}

            #endregion
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
                ElectricityUsage = electricityUsageDec,
                ConnectionDateAndTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ")
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RichTextBox.CheckForIllegalCrossThreadCalls = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ovalGauge1_Click(object sender, EventArgs e)
        {

        }
    }
}
