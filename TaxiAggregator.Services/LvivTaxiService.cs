using System;
using System.Threading.Tasks;
using TaxiAggregator.Bolt;
using TaxiAggregator.Services.Models;
using TaxiAggregator.Taxi838;
using TaxiAggregator.Uber;
using TaxiAggregator.Uklon;

namespace TaxiAggregator.Services
{
    public class LvivTaxiService : ITaxiService
    {
        private readonly IUberClient _uber;
        private readonly IUklonClient _uklon;
        private readonly IBoltClient _bolt;
        private readonly ITaxi838Client _taxi838;

        private readonly IRequestFactory _factory;
        private readonly IOrderValidator _validator;

        public LvivTaxiService(IUberClient uber, IUklonClient uklon, IBoltClient bolt, ITaxi838Client taxi838,
            IRequestFactory factory, IOrderValidator validator)
        {
            _uber = uber;
            _uklon = uklon;
            _bolt = bolt;
            _taxi838 = taxi838;
            _factory = factory;
            _validator = validator;
        }

        public async Task<TaxiResponse> EstimateOrderAsync(TaxiRequest request)
        {
            if (!_validator.ValidateOrder(request))
            {
                throw new InvalidOperationException("Order is not valid!");
            }

            var response = new TaxiResponse();

            //// //// //// //// //// //// //// UBER //// //// //// //// //// //// ////

            var uberRequest = _factory.CreateUberRequest(request);
            var uberResponse = _uber.EstimatePriceAsync(uberRequest);

            //// //// //// //// //// //// //// UKLON //// //// //// //// //// //// ///

            //// //// //// //// //// //// //// BOLT //// //// //// //// //// //// ////

            //// //// //// //// //// //// //// 838 //// //// //// //// //// //// /////

            //// //// //// //// //// //// //// //// //// //// //// //// //// //// ////

            throw new NotImplementedException();
        }
    }
}