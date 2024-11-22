using AdminClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminClient.ServiceManager.Events
{
    public class InstructionFailSendEventArgs : EventArgs
    {
        private readonly InstructionFailedError _instructionFailedError;

        public InstructionFailSendEventArgs(InstructionFailedError ife) => _instructionFailedError = ife;

        public string GetError
        {
            get { return _instructionFailedError.ExceptionMessage; }
        }

    }
}
