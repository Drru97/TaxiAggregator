namespace TaxiAggregator.Uklon.Models.Requests
{
    public class StreetSearchRequest
    {
        public int CityId { get; set; } = 5;
        public int Limit { get; set; } = 1;
        public long Timestamp { get; set; } = 1557250402913;
        public string Search { get; set; }
    }
}
