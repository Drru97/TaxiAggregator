using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using TaxiAggregator.Bolt.Models.Requests;
using TaxiAggregator.Bolt.Models.Responses;

namespace TaxiAggregator.Bolt
{
    public class BoltHttpClient : IBoltClient
    {
        private readonly HttpClient _http;
        private readonly string _token;

        public BoltHttpClient(HttpClient http, string token)
        {
            _http = http;
            _token = BoltConstants.BOLT_AUTH_TYPE + " " + token;

            SetupHttpClient();
        }

        public async Task<PriceEstimateResponse> EstimatePriceAsync(PriceEstimateRequest request)
        {
            var builder = new UriBuilder(BoltConstants.BOLT_BASE_URL + "/" + BoltConstants.BOLT_PRICE_ESTIMATE_URL);
            var query = HttpUtility.ParseQueryString(builder.Query);

            query["lat"] = request.StartLatitude.ToString(CultureInfo.InvariantCulture);
            query["lng"] = request.StartLongitude.ToString(CultureInfo.InvariantCulture);
            query["destination_lat"] = request.EndLatitude.ToString(CultureInfo.InvariantCulture);
            query["destination_lng"] = request.EndLongitude.ToString(CultureInfo.InvariantCulture);

            builder.Query = query.ToString();
            var url = builder.ToString();
            
            _http.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(_token);
            
            var response = await _http.GetStringAsync(url);

            return JsonConvert.DeserializeObject<PriceEstimateResponse>(response);
        }

        private void SetupHttpClient()
        {
            _http.BaseAddress = new Uri(BoltConstants.BOLT_BASE_URL);

            _http.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(_token);
        }
    }
}
