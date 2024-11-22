using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    internal class PriceCalculationModel
    {
        public decimal Cost { get; set; }
        public Models.Communication.Message Message { get; set; }
    }
}
