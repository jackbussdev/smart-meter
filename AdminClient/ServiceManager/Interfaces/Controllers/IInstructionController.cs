using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminClient.Models.Instructions;

namespace AdminClient.ServiceManager.Interfaces.Controllers
{
    /// <summary>
    /// Interface for the instruction controller including sendmessage functionality
    /// </summary>
    public interface IInstructionController
    {

        /// <summary>
        /// Send message to clients
        /// </summary>
        /// <param name="msg">Message object with target region and message content</param>
        public void SendMessage(Models.Instructions.Message msg);
    }
}
