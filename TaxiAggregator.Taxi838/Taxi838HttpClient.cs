using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using TaxiAggregator.Taxi838.Models.Requests;
using TaxiAggregator.Taxi838.Models.Responses;

namespace TaxiAggregator.Taxi838
{
    public class Taxi838HttpClient : ITaxi838Client
    {
        private readonly HttpClient _http;

        public Taxi838HttpClient(HttpClient http)
        {
            _http = http;

            SetupHttpClient();
        }

        public async Task<PriceEstimateResponse> EstimatePriceAsync(PriceEstimateRequest request)
        {
            var builder = new UriBuilder(Taxi838Constants.TAXI838_BASE_URL + "/" +
                                         Taxi838Constants.TAXI838_PRICE_ESTIMATE_URL);
            var query = HttpUtility.ParseQueryString(builder.Query);

            var points = JsonConvert.SerializeObject(request.Points);

            query["city_id"] = request.CityId.ToString();
            query["tarif"] = ((int) request.CarType).ToString();
            query["keypoints"] = points;

            builder.Query = query.ToString();
            var url = builder.ToString();

            var response = await _http.GetStringAsync(url);

            return JsonConvert.DeserializeObject<PriceEstimateResponse>(response);
        }

        private void SetupHttpClient()
        {
            _http.BaseAddress = new Uri(Taxi838Constants.TAXI838_BASE_URL);
        }
    }
}
