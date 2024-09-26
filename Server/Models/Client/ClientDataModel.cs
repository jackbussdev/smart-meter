namespace Server.Models.Client
{
    internal class ClientDataModel : IClientDataModel
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public decimal ElectricityUsage { get; set; }
        public string ConnectionDateAndTime { get; set; }
    }
}
