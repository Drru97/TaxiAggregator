using Newtonsoft.Json;

namespace TaxiAggregator.EconomTaxi.Models.Responses
{
    public class Street
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("full_name")]
        public string FullName { get; set; }
    }
}
