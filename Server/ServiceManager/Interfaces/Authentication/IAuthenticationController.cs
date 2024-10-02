using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.ServiceManager.Interfaces.Authentication
{
    internal interface IAuthenticationController
    {
        /// <summary>
        /// Log in with username and password
        /// </summary>
        /// <param name="username">Usually the serial number</param>
        /// <param name="password">A six-digit code generated using generatePasswordForUsername</param>
        /// <returns></returns>
        public string loginWithUsernamePassword(string username, string password);

        /// <summary>
        /// The one-time-passcode generation for smart meter onboarding
        /// </summary>
        /// <param name="username">Meter serial number</param>
        /// <returns></returns>
        public string generatePasswordForUsername(string username);

        /// <summary>
        /// Invalidate the one-time-passcode for a meter
        /// </summary>
        /// <param name="username">Meter serial number</param>
        /// <returns></returns>
        public bool invalidatePasswordForUsername(string username);
    }
}
