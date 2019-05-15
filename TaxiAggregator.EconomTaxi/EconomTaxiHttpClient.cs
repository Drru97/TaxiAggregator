using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using TaxiAggregator.EconomTaxi.Models.Requests;
using TaxiAggregator.EconomTaxi.Models.Responses;

namespace TaxiAggregator.EconomTaxi
{
    public class EconomTaxiHttpClient : IEconomTaxiClient
    {
        private readonly HttpClient _http;

        public EconomTaxiHttpClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<SearchStreetResponse> SearchStreetAsync(StreetSearchRequest request)
        {
            var builder = new UriBuilder(EconomTaxiConstants.ECONOM_TAXI_BASE_URL + "/" +
                                         EconomTaxiConstants.ECONOM_TAXI_STREET_SEARCH_URL);
            var query = HttpUtility.ParseQueryString(builder.Query);

            query["taxi_service_id"] = request.TaxiServiceId.ToString();
            query["settlement_id"] = request.SettlementId.ToString();
            query["language"] = request.Language;
            query["search"] = request.Search;

            builder.Query = query.ToString();
            var url = builder.ToString();

            var response = await _http.GetStringAsync(url);

            return JsonConvert.DeserializeObject<SearchStreetResponse>(response);
        }

        public async Task<PriceEstimateResponse> EstimatePriceAsync(PriceEstimateRequest request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8,
                EconomTaxiConstants.ECONOM_TAXI_PRICE_ESTIMATE_REQUEST_CONTENT_TYPE);

            const string url = EconomTaxiConstants.ECONOM_TAXI_BASE_URL + "/" +
                               EconomTaxiConstants.ECONOM_TAXI_PRICE_ESTIMATE_URL;

            var responseMessage = await _http.PostAsync(url, content);

            return JsonConvert.DeserializeObject<PriceEstimateResponse>(
                await responseMessage.Content.ReadAsStringAsync());
        }

        private void SetupHttpClient()
        {
            _http.BaseAddress = new Uri(EconomTaxiConstants.ECONOM_TAXI_BASE_URL);
        }
    }
}
