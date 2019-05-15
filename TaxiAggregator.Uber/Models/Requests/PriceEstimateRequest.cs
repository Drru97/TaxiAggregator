namespace TaxiAggregator.Uber.Models.Requests
{
    public class PriceEstimateRequest
    {
        public double StartLatitude { get; set; }
        public double StartLongitude { get; set; }
        public double EndLatitude { get; set; }
        public double EndLongitude { get; set; }
    }
}
