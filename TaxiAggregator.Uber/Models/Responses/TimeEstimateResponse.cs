using System.Collections.Generic;
using Newtonsoft.Json;

namespace TaxiAggregator.Uber.Models.Responses
{
    public class TimeEstimateResponse
    {
        [JsonProperty("times")]
        public List<Time> Times { get; set; }
    }
}
