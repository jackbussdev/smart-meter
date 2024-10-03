using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.Communication
{
    public class ClientDataModel
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public decimal ElectricityUsage { get; set; }
    }
}

