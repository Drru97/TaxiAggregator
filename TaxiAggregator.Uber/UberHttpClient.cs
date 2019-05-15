using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using TaxiAggregator.Uber.Models.Requests;
using TaxiAggregator.Uber.Models.Responses;

namespace TaxiAggregator.Uber
{
    public class UberHttpClient : IUberClient
    {
        private readonly HttpClient _http;
        private readonly string _token;

        public UberHttpClient(HttpClient http, string token)
        {
            _http = http;
            _token = UberConstants.UBER_AUTH_TYPE + " " + token;

            SetupHttpClient();
        }

        public async Task<PriceEstimateResponse> EstimatePriceAsync(PriceEstimateRequest request)
        {
            var builder = new UriBuilder(UberConstants.UBER_BASE_URL + "/" + UberConstants.UBER_PRICE_ESTIMATE_URL);
            var query = HttpUtility.ParseQueryString(builder.Query);

            query["start_latitude"] = request.StartLatitude.ToString(CultureInfo.InvariantCulture);
            query["start_longitude"] = request.StartLongitude.ToString(CultureInfo.InvariantCulture);
            query["end_latitude"] = request.EndLatitude.ToString(CultureInfo.InvariantCulture);
            query["end_longitude"] = request.EndLongitude.ToString(CultureInfo.InvariantCulture);

            builder.Query = query.ToString();
            var url = builder.ToString();

            var response = await _http.GetStringAsync(url);

            return JsonConvert.DeserializeObject<PriceEstimateResponse>(response);
        }

        public async Task<TimeEstimateResponse> EstimateTimeAsync(TimeEstimateRequest request)
        {
            var builder = new UriBuilder(UberConstants.UBER_BASE_URL + "/" + UberConstants.UBER_TIME_ESTIMATE_URL);
            var query = HttpUtility.ParseQueryString(builder.Query);

            query["start_latitude"] = request.StartLatitude.ToString(CultureInfo.InvariantCulture);
            query["start_longitude"] = request.StartLongitude.ToString(CultureInfo.InvariantCulture);

            builder.Query = query.ToString();
            var url = builder.ToString();

            var response = await _http.GetStringAsync(url);

            return JsonConvert.DeserializeObject<TimeEstimateResponse>(response);
        }

        private void SetupHttpClient()
        {
            _http.BaseAddress = new Uri(UberConstants.UBER_BASE_URL);

            _http.DefaultRequestHeaders.AcceptLanguage.Add(
                new StringWithQualityHeaderValue(UberConstants.UBER_ACCEPT_LANGUAGE));
            _http.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(_token);
        }
    }
}
