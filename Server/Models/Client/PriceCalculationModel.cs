namespace Server.Models.Client
{
    internal class PriceCalculationModel
    {
        public decimal Cost { get; set; }
        public MessageModel Message { get; set; } = null!;
    }
}
