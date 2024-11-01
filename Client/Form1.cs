using Client.ServiceManager.Interfaces.Controllers.Communication;

namespace Client
{
    public partial class Form1 : Form
    {
        IReadingController readingController;
        MindFusion.Drawing.Brush green;
        MindFusion.Drawing.Brush amber;
        MindFusion.Drawing.Brush red;
        private float electricityUsage;
        private decimal electricityUsageDec;

        public Form1(IReadingController rc)
        {
            readingController = rc;

            InitializeComponent();
            //---------------------------------------------------------
            //---------------------------------------------------------
            //  Left comments under hear for Todd or Jack if needed
            //
            //                   If not just get rid
            //---------------------------------------------------------
            //---------------------------------------------------------


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

        public void rc_ReadingSent(object sender, EventArgs e)
        {
            electricityUsage = readingController.getElectricityUsage();
        }

        public void receivedReading(string reading)
        {
            richTextBox1.AppendText(reading);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            RichTextBox.CheckForIllegalCrossThreadCalls = false;

            readingController.ReadingSent += rc_ReadingSent!;

            readingController.SetRichTextBox(receivedReading);

            Thread t = new Thread(new ThreadStart(readingController.SendReading));
            t.Start();

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
