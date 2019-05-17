using Newtonsoft.Json;

namespace TaxiAggregator.Bolt.Responses
{
    public class SearchCategory
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("pickup_eta")]
        public int? PickupTime { get; set; }

        [JsonProperty("surge_multiplier")]
        public double SurgeMultiplier { get; set; }

        [JsonProperty("price_prediction_str")]
        public string PricePrediction { get; set; }
    }
}
