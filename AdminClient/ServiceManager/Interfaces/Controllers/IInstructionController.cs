using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminClient.Models.Instructions;

namespace AdminClient.ServiceManager.Interfaces.Controllers
{
    public interface IInstructionController
    {
        public void SendMessage(Models.Instructions.Message msg);
    }
}
