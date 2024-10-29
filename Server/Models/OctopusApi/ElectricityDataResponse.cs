namespace Server.Models.OctopusApi
{
    public class ElectricityDataResponse
    {
        public decimal Count { get; set; }
        public string? Unit { get; set; }
        public string? Previous { get; set; }
        public IEnumerable<Result>? Results { get; set; }
    }
}
