using Newtonsoft.Json;

namespace TaxiAggregator.EconomTaxi.Models.Requests
{
    public class Point
    {
        [JsonProperty("settlement_id")]
        public int SettlementId { get; set; } = 1;
        [JsonProperty("street_id")]
        public int StreetId { get; set; }
        [JsonProperty("building_number")]
        public string BuildingNumber { get; set; }
    }
}
