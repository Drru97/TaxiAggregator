using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TaxiAggregator.DataAccess.Generic
{
    public interface IUnitOfWork<TDbContext> where TDbContext : DbContext
    {
        Task CommitAsync();
    }
}
