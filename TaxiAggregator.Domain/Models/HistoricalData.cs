using System;

namespace TaxiAggregator.Domain.Models
{
    public class HistoricalData
    {
        public int Id { get; set; }
        public double OriginLatitude { get; set; }
        public double OriginLongitude { get; set; }
        public double DestinationLatitude { get; set; }
        public double DestinationLongitude { get; set; }
        public double? Distance { get; set; }

        public string TaxiService { get; set; }
        public string CarType { get; set; }

        public int Price { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public double? SurgeMultiplier { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
