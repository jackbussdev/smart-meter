namespace Server.Models.Client
{
    public class ClientDataModel : IClientDataModel
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public decimal ElectricityUsage { get; set; }
        public string ConnectionDateAndTime { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public string Tariff {  get; set; } = "E-1R-AGILE-FLEX-22-11-25-C"; // Place holder
    }
}
