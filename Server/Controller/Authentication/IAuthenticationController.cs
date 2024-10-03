namespace Server.Controller.Authentication
{
    internal interface IAuthenticationController
    {
        /// <summary>
        /// Log in with username and password
        /// </summary>
        /// <param name="username">Usually the serial number</param>
        /// <param name="password">A six-digit code generated using GeneratePasswordForUsername</param>
        /// <returns></returns>
        public string LoginWithUsernamePassword(string username, string password);

        /// <summary>
        /// The one-time-passcode generation for smart meter onboarding
        /// </summary>
        /// <param name="username">Meter serial number</param>
        /// <returns></returns>
        public string GeneratePasswordForUsername(string username);

        /// <summary>
        /// Invalidate the one-time-passcode for a meter
        /// </summary>
        /// <param name="username">Meter serial number</param>
        /// <returns></returns>
        public bool InvalidatePasswordForUsername(string username);
    }
}
