namespace TaxiAggregator.Domain.Models
{
    public class Trip
    {
        public Location Origin { get; set; }
        public Location Destination { get; set; }
        public CarType CarType { get; set; }
        public TaxiService TaxiService { get; set; }

        public TripData Details { get; set; }
    }
}
