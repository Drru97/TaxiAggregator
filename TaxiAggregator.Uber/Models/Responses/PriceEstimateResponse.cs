using System.Collections.Generic;
using Newtonsoft.Json;

namespace TaxiAggregator.Uber.Models.Responses
{
    public class PriceEstimateResponse
    {
        [JsonProperty("prices")]
        public List<Price> Prices { get; set; }
    }
}
