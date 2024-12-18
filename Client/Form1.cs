using Client.Models.Communication;
using Client.ServiceManager.Interfaces.Controllers.Communication;
using System.Linq.Expressions;

// https://mindfusion.eu/gauges-winforms-pack.html - Package that was used for UI Gauge Implementation.

namespace Client
{
    public partial class Form1 : Form
    {
        IReadingController readingController;
        MindFusion.Drawing.Brush green;
        MindFusion.Drawing.Brush amber;
        MindFusion.Drawing.Brush red;

        private float electricityUsage;
        private float collectiveElectricityUsage;
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

            green = today_Gauge.Scales[0].Ranges[0].Fill;
            amber = today_Gauge.Scales[0].Ranges[1].Fill;
            red = today_Gauge.Scales[0].Ranges[2].Fill;
        }

        public void rc_ReadingSent(object sender, EventArgs e)
        {
            electricityUsage = readingController.getElectricityUsage();
            collectiveElectricityUsage += electricityUsage;
            currentMessage = readingController.getMessage();

            #region TODAY GAUGE LOGIC
            today_Gauge.Scales[0].Ranges[0].MaxValue = collectiveElectricityUsage;
            today_Gauge.Scales[0].Pointers[0].Value = collectiveElectricityUsage;
            todayLbl.Text = collectiveElectricityUsage + "kW/h";
            if (collectiveElectricityUsage <= 6.9 && collectiveElectricityUsage >= 4.5)
            {
                today_Gauge.Scales[0].Ranges[0].Fill = amber;
            }
            else if (collectiveElectricityUsage >= 7)
            {
                today_Gauge.Scales[0].Ranges[0].Fill = red;
            }
            else
            {
                today_Gauge.Scales[0].Ranges[0].Fill = green;
            }
            #endregion

            #region NOW GAUGE LOGIC
            now_Gauge.Scales[0].Ranges[0].MaxValue = electricityUsage;
            now_Gauge.Scales[0].Pointers[0].Value = electricityUsage;
            nowLbl.Text = electricityUsage + "kW/h";
            if (electricityUsage <= 0.00280 && electricityUsage >= 0.00156)  
            {
                now_Gauge.Scales[0].Ranges[0].Fill = amber;
            }
            else if (electricityUsage >= 0.00281)
            {
                now_Gauge.Scales[0].Ranges[0].Fill = red;
            }
            else
            {
                now_Gauge.Scales[0].Ranges[0].Fill = green;
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

        private void todayLbl_Click(object sender, EventArgs e)
        {

        }
    }
}
