namespace TaxiAggregator.Uklon.Models.Requests
{
    public class PriceEstimateRequest
    {
        public int CityId { get; set; } = 5;
        public bool IsRouteUndefined { get; set; } = false;
        public string TimeType { get; set; } = "now";
        public string CarType { get; set; } = "Standart";
        public string PaymentType { get; set; } = "Cash";
        public bool RememberUser { get; set; } = false;
        public int ExtraCost { get; set; } = 0;
        public Point From { get; set; }
        public Point To { get; set; }
    }
}
