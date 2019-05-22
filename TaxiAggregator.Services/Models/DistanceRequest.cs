using TaxiAggregator.Domain.Models;

namespace TaxiAggregator.Services.Models
{
    public class DistanceRequest
    {
        public Location Origin { get; set; }
        public Location Destination { get; set; }
    }
}
