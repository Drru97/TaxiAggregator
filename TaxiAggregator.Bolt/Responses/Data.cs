using System.Collections.Generic;
using Newtonsoft.Json;
using TaxiAggregator.Bolt.Requests;

namespace TaxiAggregator.Bolt.Responses
{
    public class Data
    {
        [JsonProperty("search_categories")]
        public List<SearchCategory> SearchCategories { get; set; }
    }
}
