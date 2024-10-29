namespace Server.Models.OctopusApi
{
    public  class Result
    {
        public decimal Value_exc_vat { get; set; }
        public decimal Value_inc_vat { get; set; }
        public DateTime Valid_from { get; set; }
        public DateTime Valid_to { get; set; }
    }
}
