using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using TaxiAggregator.Uklon.Models;
using TaxiAggregator.Uklon.Models.Requests;
using TaxiAggregator.Uklon.Models.Responses;

namespace TaxiAggregator.Uklon
{
    public class UklonHttpClient : IUklonClient
    {
        private readonly HttpClient _http;
        private readonly string _clientId;
        private string _token;
        private readonly ApiVersion _version;

        public UklonHttpClient(HttpClient http, string clientId, string token, ApiVersion version = ApiVersion.Version2)
        {
            _http = http;
            _clientId = clientId;
            _token = token;
            _version = version;

            SetupHttpClient();
        }

        public async Task<StreetSearchResponse> SearchStreetAsync(StreetSearchRequest request)
        {
            var builder = new UriBuilder(UklonConstants.UKLON_BASE_URL + "/" +
                                         UklonConstants.UKLON_STREET_SEARCH_URL);
            var query = HttpUtility.ParseQueryString(builder.Query);

            query["timestamp"] = request.Timestamp.ToString();
            query["limit"] = request.Limit.ToString();
            query["q"] = request.Search;

            builder.Query = query.ToString();
            var url = builder.ToString();

            var response = await _http.GetStringAsync(url);

            var streets = JsonConvert.DeserializeObject<List<Street>>(response);

            return new StreetSearchResponse {Streets = streets};
        }

        public Task<PriceEstimateResponse> EstimatePriceAsync(PriceEstimateRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<NearestAddressResponse> SearchNearestAddressAsync(NearestAddressRequest request)
        {
            var builder = new UriBuilder(UklonConstants.UKLON_BASE_URL + "/" +
                                         UklonConstants.UKLON_NEAREST_ADDRESS_URL);
            var query = HttpUtility.ParseQueryString(builder.Query);

            query["lat"] = request.Latitude.ToString(CultureInfo.InvariantCulture);
            query["lng"] = request.Longitude.ToString(CultureInfo.InvariantCulture);
            query["total"] = request.Limit.ToString();
            query["radius"] = request.Radius.ToString(CultureInfo.InvariantCulture);
            query["locale"] = request.Locale;

            builder.Query = query.ToString();
            var url = builder.ToString();

            var response = await _http.GetStringAsync(url);

            var addresses = JsonConvert.DeserializeObject<List<Street>>(response);

            return new NearestAddressResponse {Addresses = addresses};
        }

        public async Task<PriceEstimateResponse> EstimatePriceV2Async(PriceEstimateRequestV2 request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8,
                UklonConstants.UKLON_PRICE_ESTIMATE_REQUEST_CONTENT_TYPE);

            _http.DefaultRequestHeaders.Authorization =
                AuthenticationHeaderValue.Parse(UklonConstants.UKLON_AUTH_TYPE + " " + _token);

            const string url = UklonConstants.UKLON_BASE_URL + "/" + UklonConstants.UKLON_PRICE_ESTIMATE_V2_URL;

            var responseMessage = await _http.PostAsync(url, content);
            if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                await GetBearerToken();
                _http.DefaultRequestHeaders.Authorization =
                    AuthenticationHeaderValue.Parse($"{UklonConstants.UKLON_AUTH_TYPE} {_token}");

                responseMessage = await _http.PostAsync(url, content);
            }

            var response = await responseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<PriceEstimateResponse>(response);
        }

        private async Task GetBearerToken()
        {
            var authUrl = $"{UklonConstants.UKLON_BASE_URL}/{UklonConstants.UKLON_AUTH_URL}";
            var content =
                new StringContent(
                    $"client_id={_clientId}&grant_type={UklonConstants.UKLON_GRANT_TYPE}&refresh_token={UklonConstants.UKLON_REFRESH_TOKEN}",
                    Encoding.Default, UklonConstants.UKLON_AUTH_REQUEST_CONTENT_TYPE);

            var responseMessage = await _http.PostAsync(authUrl, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseBody = await responseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<AuthorizationResponse>(responseBody);
                if (response.Authorized)
                {
                    _token = response.AccessToken;
                }
            }
        }

        private void SetupHttpClient()
        {
            _http.BaseAddress = new Uri(UklonConstants.UKLON_BASE_URL);

            if (_version == ApiVersion.Version1)
            {
                SetupVersion1Client();
            }
        }

        private void SetupVersion1Client()
        {
            _http.DefaultRequestHeaders.Add("Cookie", "City=5");
            _http.DefaultRequestHeaders.Add("client_id", _clientId);
        }
    }
}
