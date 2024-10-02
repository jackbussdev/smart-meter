using Client.Controllers.Communication;
using Client.Models.Communication;
using NetMQ.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ServiceManager.Interfaces.Controllers.Communication
{
    public interface IReadingController
    {
        public void SendReading();
        public void setClientDataModel(ClientDataModel cdm);
        public void setRichTextBox(Action<string> callback);
    }
}
