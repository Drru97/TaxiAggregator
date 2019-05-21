using System.Collections.Generic;
using TaxiAggregator.API.Models;
using TaxiAggregator.Services.Models;

namespace TaxiAggregator.API.Mappers
{
    public class TaxiResponseMapper : ITaxiResponseMapper
    {
        public EstimateViewModel Map(TaxiResponse response)
        {
            if (response == null)
            {
                return null;
            }

            var vm = new EstimateViewModel
            {
                Origin = response.Origin,
                Destination = response.Destination,
                Trips = new List<TripViewModel>()
            };

            if (response.Details == null)
            {
                return vm;
            }

            foreach (var detail in response.Details)
            {
                var trip = new TripViewModel
                {
                    Information = detail.Details,
                    CarClass = detail.CarType.ToString(),
                    TaxiService = detail.TaxiService.ToString()
                };
                vm.Trips.Add(trip);
            }

            return vm;
        }
    }
}
