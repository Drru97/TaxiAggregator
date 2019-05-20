using System.Collections.Generic;
using Newtonsoft.Json;

namespace TaxiAggregator.Bolt.Models.Responses
{
    public class Data
    {
        [JsonProperty("search_categories")]
        public List<SearchCategory> SearchCategories { get; set; }
    }
}
