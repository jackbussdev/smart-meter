using Client.ServiceManager.Interfaces.Controllers.Communication;

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

            //readingController.SetClientDataModel(new()
            //{
            //    Id = Random.Shared.Next(),
            //    LocationId = 2,
            //    ElectricityUsage = electricityUsageDec,
            //    ConnectionDateAndTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ")
            //});

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

            readingController.SendReading();
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

            readingController.SendReading();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer_Lbl.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
        }
    }
}
