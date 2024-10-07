using Client.Models.Communication;

namespace Client.ServiceManager.Interfaces.Controllers.Communication
{
    public interface IReadingController
    {
        /// <summary>
        /// Sends the reading to the server, to be used by the thread manager to run asynchronously.
        /// </summary>
        public void SendReading();

        /// <summary>
        /// Sets the model via another thread which is periodically pulled by the SendReading process to be sent to server.
        /// </summary>
        /// <param name="cdm">ClientDataModel queued to send to server</param>
        public void SetClientDataModel(ClientDataModel cdm);

        /// <summary>
        /// Updates the callback function for a frontend component that logs all traffic.
        /// </summary>
        /// <param name="callback">Usually a RichTextBox</param>
        public void SetRichTextBox(Action<string> callback);
    }
}
