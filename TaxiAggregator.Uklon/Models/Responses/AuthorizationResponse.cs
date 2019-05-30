using Newtonsoft.Json;

namespace TaxiAggregator.Uklon.Models.Responses
{
    public class AuthorizationResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
        [JsonProperty("client_id")]
        public string ClientId { get; set; }
        [JsonProperty("authorized")]
        public bool Authorized { get; set; }
        [JsonProperty("expires_in")]
        public long Expiration { get; set; }
    }
}
