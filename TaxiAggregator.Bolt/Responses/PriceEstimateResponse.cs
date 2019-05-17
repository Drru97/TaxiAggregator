using Newtonsoft.Json;
using TaxiAggregator.Bolt.Requests;

namespace TaxiAggregator.Bolt.Responses
{
    public class PriceEstimateResponse
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public Data Data { get; set; }
    }
}
