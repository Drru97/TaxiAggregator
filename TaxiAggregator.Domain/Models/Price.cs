namespace TaxiAggregator.Domain.Models
{
    public class Price
    {
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public int Cost { get; set; }
        public double? SurgeMultiplier { get; set; }
    }
}