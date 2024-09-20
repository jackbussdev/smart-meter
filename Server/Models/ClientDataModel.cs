using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    internal class ClientDataModel : IClientDataModel
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public decimal ElectricityUsage { get; set; }
    }
}
