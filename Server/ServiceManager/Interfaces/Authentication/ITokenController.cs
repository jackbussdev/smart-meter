using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.ServiceManager.Interfaces.Authentication
{
    internal interface ITokenController
    {
        public string generateTokenForUsername(string username);
    }
}
