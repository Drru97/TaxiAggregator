using TaxiAggregator.Services.Models;

namespace TaxiAggregator.API.Validation
{
    public class TaxiRequestValidator : IRequestValidator
    {
        public bool Validate(TaxiRequest request)
        {
            if (request?.Origin == null || request.Destination == null)
            {
                return false;
            }

            return true;
        }
    }
}
