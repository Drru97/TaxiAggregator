using Newtonsoft.Json;

namespace TaxiAggregator.EconomTaxi.Models.Requests
{
    public class PriceEstimateRequest
    {
        [JsonProperty("mode")]
        public string Mode { get; set; } = "calculate";
        [JsonProperty("taxiServiceId")]
        public int TaxiServiceId { get; set; } = 16;
        [JsonProperty("data")] 
        public RequestData Data { get; set; }
        
    }
}
