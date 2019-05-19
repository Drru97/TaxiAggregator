using Newtonsoft.Json;

namespace TaxiAggregator.Uklon.Models.Responses
{
    public class Street
    {
        [JsonProperty("address_name")]
        public string Address { get; set; }
        [JsonProperty("is_place")]
        public bool IsPlace { get; set; }
        [JsonProperty("house_number")]
        public string HouseNumber { get; set; }
        [JsonProperty("city_id")]
        public int CityId { get; set; }
        [JsonProperty("atype")] 
        public string Type { get; set; }
    }
}
