using System.Threading.Tasks;
using TaxiAggregator.Services.Models;

namespace TaxiAggregator.Services
{
    public interface IDistanceProvider
    {
        Task<DistanceResponse> GetDistanceAsync(DistanceRequest request);
    }
}
