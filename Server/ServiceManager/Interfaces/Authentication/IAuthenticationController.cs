using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.ServiceManager.Interfaces.Authentication
{
    internal interface IAuthenticationController
    {
        public string loginWithUsernamePassword(string username, string password);

        public string generatePasswordForUsername(string username);
        public bool invalidatePasswordForUsername(string username);
    }
}
