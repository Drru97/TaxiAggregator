using System;
using Newtonsoft.Json;

namespace TaxiAggregator.Uber.Models.Responses
{
    public class Price
    {
        [JsonProperty("localized_display_name")]
        public string LocalizedDisplayName { get; set; }

        [JsonProperty("distance")]
        public double Distance { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("product_id")]
        public Guid ProductId { get; set; }

        [JsonProperty("high_estimate")]
        public long HighEstimate { get; set; }

        [JsonProperty("low_estimate")]
        public long LowEstimate { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("estimate")]
        public string Estimate { get; set; }

        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }
    }
}
