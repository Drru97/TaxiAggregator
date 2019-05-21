namespace TaxiAggregator.Uklon.Models.Requests
{
    public class NearestAddressRequest
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Limit { get; set; } = 1;
        public double Radius { get; set; } = 0.1;
        public string Locale { get; set; } = "en";
    }
}
