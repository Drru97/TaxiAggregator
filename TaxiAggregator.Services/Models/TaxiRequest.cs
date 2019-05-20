using TaxiAggregator.Domain.Models;

namespace TaxiAggregator.Services.Models
{
    public class TaxiRequest
    {
        public Location Origin { get; set; }
        public Location Destination { get; set; }
        public CarType CarType { get; set; }
    }
}
