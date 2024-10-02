namespace Server.Models.Client
{
    /// <summary>
    /// Client Data Model
    /// </summary>
    public interface IClientDataModel
    {
        /// <summary>
        /// Client Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///  Client Location Id
        /// </summary>
        public int LocationId { get; set; } //to be enum maybe

        /// <summary>
        ///  Electricity Usage in kWh
        /// </summary>
        public decimal ElectricityUsage { get; set; }

        /// <summary>
        /// Tarif
        /// </summary>
        //public Tarif Tarif { get; set; }

        /// <summary>
        ///  Date and Time of client connection
        /// </summary>
        public string ConnectionDateAndTime { get; set; }
    }
}
