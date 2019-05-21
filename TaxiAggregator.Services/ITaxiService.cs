using System.Threading.Tasks;
using TaxiAggregator.Services.Models;

namespace TaxiAggregator.Services
{
    public interface ITaxiService
    {
        Task<TaxiResponse> EstimateOrderAsync(TaxiRequest order);
    }
}
