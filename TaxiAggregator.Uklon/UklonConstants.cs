namespace TaxiAggregator.Uklon
{
    public class UklonConstants
    {
        public const string UKLON_BASE_URL = "https://www.uklon.com.ua";
        public const string UKLON_STREET_SEARCH_URL = "api/v1/addresses";
        public const string UKLON_PRICE_ESTIMATE_URL = "api/v1/orders/cost";
        public const string UKLON_NEAREST_ADDRESS_URL = "api/v1/addresses/nearest";
        public const string UKLON_PRICE_ESTIMATE_V2_URL = "api/v2/orders/cost";
        public const string UKLON_AUTH_URL = "api/auth";
        public const string UKLON_AUTH_TYPE = "Bearer";
        public const string UKLON_GRANT_TYPE = "refresh_token";
        public const string UKLON_REFRESH_TOKEN = "a7b18026-1444-464a-904f-bc139da28988";
        public const string UKLON_PRICE_ESTIMATE_REQUEST_CONTENT_TYPE = "application/json";
        public const string UKLON_AUTH_REQUEST_CONTENT_TYPE = "application/x-www-form-urlencoded";
    }
}
