using TaxiAggregator.API.Models;
using TaxiAggregator.Services.Models;

namespace TaxiAggregator.API.Mappers
{
    public interface ITaxiResponseMapper
    {
        EstimateViewModel Map(TaxiResponse response);
    }
}
