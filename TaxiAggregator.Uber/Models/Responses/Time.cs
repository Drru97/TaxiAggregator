using System;
using Newtonsoft.Json;

namespace TaxiAggregator.Uber.Models.Responses
{
    public class Time
    {
        [JsonProperty("localized_display_name")]
        public string LocalizedDisplayName { get; set; }

        [JsonProperty("estimate")]
        public long Estimate { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("product_id")]
        public Guid ProductId { get; set; }
    }
}
