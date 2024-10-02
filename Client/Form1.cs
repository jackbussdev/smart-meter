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

        private void button1_Click(object sender, EventArgs e)
        {
            readingController.SendReading(new()
            {
                Id = 2,
                LocationId = 47,
                ElectricityUsage = 500,
            });
        }
    }
}
