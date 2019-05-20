using System;

namespace TaxiAggregator.Domain.Models
{
    [Flags]
    public enum CarType
    {
        Economy = 1,
        Standard = 7,
        Business = 5,
        Minibus = 3,
        Variant = 4
    }
}
