using System.Collections.Generic;
using TaxiAggregator.Domain.Models;

namespace TaxiAggregator.Services.Models
{
    public class TaxiResponse
    {
        public Location Origin { get; set; }
        public Location Destination { get; set; }
        public IList<TripDetail> Details { get; set; }
    }
}
