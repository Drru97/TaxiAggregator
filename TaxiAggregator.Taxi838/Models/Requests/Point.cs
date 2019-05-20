using Newtonsoft.Json;

namespace TaxiAggregator.Taxi838.Models.Requests
{
    public class Point
    {
        public Point() { }
        
        public Point(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
        
        [JsonProperty("name")] 
        public string Name { get; } = "Городоцька вул.";
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        [JsonProperty("lng")]
        public double Longitude { get; set; }
    }
}
