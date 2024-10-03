using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.ServiceManager.Interfaces.Authentication
{
    internal interface ITokenController
    {
        /// <summary>
        /// Generates a token for a username
        /// </summary>
        /// <param name="username">Usually the meter serial number</param>
        /// <returns></returns>
        public string generateTokenForUsername(string username);
    }
}
