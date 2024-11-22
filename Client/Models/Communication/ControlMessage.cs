using Client.ServiceManager.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.Communication
{
    internal class ControlMessage
    {
        public string Title { get; set; }
        public string MessageBody { get; set; }
        public DateTime DateOfMessage { get; set; }
        public DateTime AlertActiveUntil { get; set; }
        public MessageType MessageType { get; set; }
    }
}
