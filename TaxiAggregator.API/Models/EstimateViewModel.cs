using System.Collections.Generic;
using TaxiAggregator.Domain.Models;

namespace TaxiAggregator.API.Models
{
    public class EstimateViewModel
    {
        public Location Origin { get; set; }
        public Location Destination { get; set; }
        public IList<TripViewModel> Trips { get; set; }
    }
}
