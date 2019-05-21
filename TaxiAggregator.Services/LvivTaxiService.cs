using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAggregator.Bolt;
using TaxiAggregator.Services.Models;
using TaxiAggregator.Taxi838;
using TaxiAggregator.Uber;
using TaxiAggregator.Uklon;
using TaxiAggregator.Uklon.Models.Requests;

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
        private readonly IOrderMapper _mapper;

        public LvivTaxiService(IUberClient uber, IUklonClient uklon, IBoltClient bolt, ITaxi838Client taxi838,
            IRequestFactory factory, IOrderValidator validator, IOrderMapper mapper)
        {
            _uber = uber;
            _uklon = uklon;
            _bolt = bolt;
            _taxi838 = taxi838;
            _factory = factory;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<TaxiResponse> EstimateOrderAsync(TaxiRequest order)
        {
            if (!_validator.ValidateOrder(order))
            {
                throw new InvalidOperationException("Order is not valid!");
            }

            var response = new TaxiResponse
            {
                Origin = order.Origin,
                Destination = order.Destination,
                Details = new List<TripDetail>(4)
            };

            //// //// //// //// //// //// //// UBER //// //// //// //// //// //// ////

            var uberRequest = _factory.CreateUberRequest(order);

            var uberPriceResponse = await _uber.EstimatePriceAsync(uberRequest);
            var uberTimeResponse = await _uber.EstimateTimeAsync(uberRequest);

            var uberTrip = _mapper.FromUber(order, uberPriceResponse, uberTimeResponse);
            response.Details.Add(uberTrip);

            //// //// //// //// //// //// //// UKLON //// //// //// //// //// //// ///

            var uklonRequest = _factory.CreateUklonRequest(order);
            var originAddressRequest = _factory.CreateNearestAddressRequest(order);
            var destinationAddressRequest = _factory.CreateNearestAddressRequest(order, false);

            var origin = (await _uklon.SearchNearestAddressAsync(originAddressRequest)).Addresses.Single();
            var destination = (await _uklon.SearchNearestAddressAsync(destinationAddressRequest)).Addresses.Single();

            uklonRequest.Route.RoutePoints.Add(new Point(origin.Address, origin.HouseNumber));
            uklonRequest.Route.RoutePoints.Add(new Point(destination.Address, destination.HouseNumber));

            var uklonPriceResponse = await _uklon.EstimatePriceV2Async(uklonRequest);

            var uklonTrip = _mapper.FromUklon(order, uklonPriceResponse);
            response.Details.Add(uklonTrip);

            //// //// //// //// //// //// //// BOLT //// //// //// //// //// //// ////

            var boltRequest = _factory.CreateBoltRequest(order);

            var boltPriceResponse = await _bolt.EstimatePriceAsync(boltRequest);

            var boltTrip = _mapper.FromBolt(order, boltPriceResponse);
            response.Details.Add(boltTrip);

            //// //// //// //// //// //// //// 838 //// //// //// //// //// //// /////

            var taxi838Request = _factory.CreateTaxi838Request(order);

            var taxi838PriceResponse = await _taxi838.EstimatePriceAsync(taxi838Request);

            var taxi838Trip = _mapper.FromTaxi838(order, taxi838PriceResponse);
            response.Details.Add(taxi838Trip);

            //// //// //// //// //// //// //// //// //// //// //// //// //// //// ////

            return response;
        }
    }
}
