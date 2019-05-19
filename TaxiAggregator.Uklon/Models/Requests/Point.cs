using Newtonsoft.Json;

namespace TaxiAggregator.Uklon.Models.Requests
{
    public class Point
    {
        public Point() { }
        
        public Point(string street, string building)
        {
            Street = street;
            Building = building;
        }
        
        [JsonProperty("address_name")]
        public string Street { get; set; }
        [JsonProperty("house_number")]
        public string Building { get; set; }
    }
}
