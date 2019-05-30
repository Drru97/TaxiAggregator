using TaxiAggregator.Services.Models;

namespace TaxiAggregator.API.Validation
{
    public interface IRequestValidator
    {
        bool Validate(TaxiRequest request);
    }
}
