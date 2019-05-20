using TaxiAggregator.Domain.Models;

namespace TaxiAggregator.Services.Models
{
    public class TripDetail
    {
        public TaxiService TaxiService { get; set; }
        public CarType CarType { get; set; }
        public TripData Details { get; set; }
    }
}
