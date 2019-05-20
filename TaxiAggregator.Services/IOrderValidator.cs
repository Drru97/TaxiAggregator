using TaxiAggregator.Services.Models;

namespace TaxiAggregator.Services
{
    public interface IOrderValidator
    {
        bool ValidateOrder(TaxiRequest request);
    }
}
