using TaxiAggregator.Services.Models;

namespace TaxiAggregator.Services
{
    public class TaxiOrderValidator : IOrderValidator
    {
        public bool ValidateOrder(TaxiRequest request)
        {
            // TODO: add validation logic here
            
            return true;
        }
    }
}
