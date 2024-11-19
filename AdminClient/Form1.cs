using AdminClient.Controllers;
using AdminClient.ServiceManager.Interfaces.Controllers;

namespace AdminClient
{
    public partial class Form1 : Form
    {
        private IInstructionController _instructionController;

        public Form1(IInstructionController instructionController)
        {
            InitializeComponent();
            _instructionController = instructionController;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _instructionController.SendMessage(new()
            {
                Location = cbMessageTargetRegion.Text,
                MessageBody = tbMessageContent.Text
            });
        }

        private void btnDeleteMessage_Click(object sender, EventArgs e)
        {

        }


    }
}
