using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models.Client
{
    internal class AdminClientInstructionModel
    {
        public string TargetArea { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
