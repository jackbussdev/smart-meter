using NetMQ;
using Server.Models.Client;

namespace Server.Controller.Server
{
    /// <summary>
    /// Server Controller
    /// </summary>
    public interface IServerController
    {
        /// <summary>
        /// Starts the server 
        /// </summary>
        /// <returns></returns>
        public Task StartServer();

        /// <summary>
        /// Checks if client data is valid
        /// </summary>
        /// <param cref="ClientDataModel" name="clientData"></param>
        /// <returns>True if client data properties exist, otherwise false</returns>
        public bool IsClientDataValid(ClientDataModel clientData);

        /// <summary>
        /// The server's Receive Ready function
        /// </summary>
        /// <param cref="object" name="sender"></param>
        /// <param cref="NetMQSocketEventArgs" name="e"></param>
        /// <returns></returns>
        public Task Server_ReceiveReady(object sender, NetMQSocketEventArgs e);

        /// <summary>
        /// Process the client data
        /// </summary>
        /// <param cref="string" name="dataFromClient"></param>
        /// <returns></returns>
        public Task ProcessClientData(string dataFromClient);
    }
}
