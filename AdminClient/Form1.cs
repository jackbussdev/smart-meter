using AdminClient.Controllers;
using AdminClient.ServiceManager.Events;
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
            _instructionController.InstructionFailed += InstructionError!;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _instructionController.SendMessage(new()
            {
                Location = cbMessageTargetRegion.Text,
                MessageBody = tbMessageContent.Text
            });
        }

        protected void InstructionError(object sender, InstructionFailSendEventArgs ife)
        {
            MessageBox.Show(ife.GetError, "An unexpected error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        private void btnDeleteMessage_Click(object sender, EventArgs e)
        {

        }


    }
}
