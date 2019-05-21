using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaxiAggregator.API.Mappers;
using TaxiAggregator.Services;
using TaxiAggregator.Services.Models;

namespace TaxiAggregator.API.Controllers
{
    [Route("api/[controller]")]
    public class TaxiController : ControllerBase
    {
        private readonly ITaxiService _taxi;
        private readonly ITaxiResponseMapper _mapper;

        public TaxiController(ITaxiService taxi, ITaxiResponseMapper mapper)
        {
            _taxi = taxi;
            _mapper = mapper;
        }

        [HttpGet("estimate")]
        public async Task<IActionResult> Estimate([FromQuery] TaxiRequest order)
        {
            var price = await _taxi.EstimateOrderAsync(order);
            var vm = _mapper.Map(price);

            return Ok(vm);
        }
    }
}
