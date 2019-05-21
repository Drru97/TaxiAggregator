using TaxiAggregator.Domain.Models;

namespace TaxiAggregator.API.Models
{
    public class TripViewModel
    {
        public string TaxiService { get; set; }
        public string CarClass { get; set; }
        public TripData Information { get; set; }
    }
}
