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
        MindFusion.Drawing.Brush green;
        MindFusion.Drawing.Brush amber;
        MindFusion.Drawing.Brush red;

        public Form1(IReadingController rc)
        {
            readingController = rc;

            InitializeComponent();

            //Random rng = new Random();
            //electricityUsage = rng.Next(5, 30);
            //electricityUsageDec = Convert.ToDecimal(electricityUsage);

            green = today_Gauge.Scales[0].Ranges[0].Fill;
            amber = today_Gauge.Scales[0].Ranges[1].Fill;
            red = today_Gauge.Scales[0].Ranges[2].Fill;
            readingController.SetClientDataModel(new()
            {
                Id = Random.Shared.Next(),
                LocationId = 2,
                ElectricityUsage = electricityUsageDec,
                ConnectionDateAndTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ")
            });

            //readingController.SendReading();

            #region GAUGE LOGIC
            today_Gauge.Scales[0].Ranges[0].MaxValue = electricityUsage;
            today_Gauge.Scales[0].Pointers[0].Value = electricityUsage;
            if (electricityUsage <= 23 && electricityUsage >= 15)
            {
                today_Gauge.Scales[0].Ranges[0].Fill = amber;
            }
            else if (electricityUsage >= 24)
            {
                today_Gauge.Scales[0].Ranges[0].Fill = red;
            }
            else
            {
                today_Gauge.Scales[0].Ranges[0].Fill = green;
            }
            #endregion
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
            //readingController.SetClientDataModel(new()
            //{
            //    Id = Random.Shared.Next(),
            //    LocationId = 2,
            //    ElectricityUsage = electricityUsageDec,
            //    ConnectionDateAndTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ")
            //});

            //readingController.SendReading();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            while (true)
            {
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

                readingController.SendReading();

                RichTextBox.CheckForIllegalCrossThreadCalls = false;

                Thread.Sleep(2000);
            }
    
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

        private void clock_Tmr_Tick(object sender, EventArgs e)
        {
            timer_Lbl.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
        }
    }
}
