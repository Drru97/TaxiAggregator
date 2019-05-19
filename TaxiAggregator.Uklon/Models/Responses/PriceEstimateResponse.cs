using Newtonsoft.Json;

namespace TaxiAggregator.Uklon.Models.Responses
{
    public class PriceEstimateResponse
    {
        [JsonProperty("cost")]
        public int Cost { get; set; }
        [JsonProperty("cost_multiplier")]
        public double CostMultiplier { get; set; }
        [JsonProperty("cost_low")]
        public int LowCost { get; set; }
        [JsonProperty("cost_high")]
        public int HighCost { get; set; }
        [JsonProperty("distance")]
        public double Distance { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
