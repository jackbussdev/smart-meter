using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models.Client
{
    internal class AdminClientInstructionReceivedModel
    {
        public string Action { get; set; }
        public dynamic Data { get; set; }
    }
}
