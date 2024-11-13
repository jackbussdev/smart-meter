using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminClient.Models
{
    internal class AdminClientInstructionReceivedModel
    {
        public string TargetRegion { get; set; } = string.Empty;
        public bool MessageReceived { get; set; }
    }
}
