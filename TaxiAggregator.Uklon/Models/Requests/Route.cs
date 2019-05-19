using System.Collections.Generic;
using Newtonsoft.Json;

namespace TaxiAggregator.Uklon.Models.Requests
{
    public class Route
    {
        [JsonProperty("route_points")]
        public List<Point> RoutePoints { get; set; }
    }
}
