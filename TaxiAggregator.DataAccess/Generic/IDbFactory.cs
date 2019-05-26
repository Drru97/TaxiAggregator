using Microsoft.EntityFrameworkCore;

namespace TaxiAggregator.DataAccess.Generic
{
    public interface IDbFactory<TDbContext> where TDbContext : BaseDbContext
    {
        TDbContext Initialize();
    }
}
