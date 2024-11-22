using Client.ServiceManager.Interfaces.Controllers.Communication;
using System.Linq.Expressions;

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
        private string currentMessage;

        Thread t;

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


        }

        public void rc_ReadingSent(object sender, EventArgs e)
        {
            electricityUsage = readingController.getElectricityUsage();
            currentMessage = readingController.getMessage();

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

            lblMsgCentreContent.Text = currentMessage;

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
            // Allow cross threading calls to manipulate the richtextbox
            RichTextBox.CheckForIllegalCrossThreadCalls = false;
            
            // set listener function for when the reading is sent
            readingController.ReadingSent += rc_ReadingSent!;

            // set the callback function for rich text box to pass from RC to frontend
            readingController.SetRichTextBox(receivedReading);

            // assign the thread
            t = new Thread(new ThreadStart(readingController.SendReading));

            // set the thread to run in background so when main thread is killed, so is this
            t.IsBackground = true;

            // start the thread
            t.Start();

        }

        void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
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
            timer_Lbl.Text = DateTime.Now.ToString("HH:mm");
        }
    }
}
