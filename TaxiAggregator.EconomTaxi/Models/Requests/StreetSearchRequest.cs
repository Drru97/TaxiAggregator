namespace TaxiAggregator.EconomTaxi.Models.Requests
{
    public class StreetSearchRequest
    {
        public int TaxiServiceId { get; set; } = 16;
        public int SettlementId { get; set; } = 1;
        public string Language { get; set; } = "uk";
        public string Search { get; set; }
    }
}
