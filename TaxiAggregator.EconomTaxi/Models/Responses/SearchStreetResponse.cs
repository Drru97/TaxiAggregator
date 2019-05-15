using System.Collections.Generic;
using Newtonsoft.Json;

namespace TaxiAggregator.EconomTaxi.Models.Responses
{
    public class SearchStreetResponse
    {
        [JsonProperty("data")]
        public List<Street> Streets { get; set; }
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
