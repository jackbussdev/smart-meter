namespace Server.Models.Client
{
    public class ClientDataModel : IClientDataModel
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public decimal ElectricityUsage { get; set; }
        public string ConnectionDateAndTime { get; set; } = string.Empty;
    }
}
