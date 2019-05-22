namespace TaxiAggregator.Domain.Models
{
    public class TripData
    {
        public Price Price { get; set; }
        public double? Distance { get; set; }
        public int? Duration { get; set; }
        public int? PickupTime { get; set; }
        public int? Seats { get; set; }
    }
}
