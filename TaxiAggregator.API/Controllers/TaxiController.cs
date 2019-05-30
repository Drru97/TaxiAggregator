using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaxiAggregator.API.Filters;
using TaxiAggregator.API.Mappers;
using TaxiAggregator.API.Validation;
using TaxiAggregator.Services;
using TaxiAggregator.Services.Models;

namespace TaxiAggregator.API.Controllers
{
    /// <summary>
    /// Controller for Taxi Aggregator
    /// </summary>
    [Route("api/[controller]")]
    public class TaxiController : ControllerBase
    {
        private readonly ITaxiService _taxi;
        private readonly ITaxiResponseMapper _mapper;
        private readonly IRequestValidator _validator;

        /// <summary>
        /// Creates new Taxi Controller instance
        /// </summary>
        /// <param name="taxi">Taxi Service</param>
        /// <param name="mapper">Taxi Response Mapper</param>
        public TaxiController(ITaxiService taxi, ITaxiResponseMapper mapper, IRequestValidator validator)
        {
            _taxi = taxi;
            _mapper = mapper;
            _validator = validator;
        }

        /// <summary>
        /// Get prices, duration, pickup time estimations for different taxi services
        /// </summary>
        /// <param name="order">Estimation request</param>
        /// <returns>Estimation result</returns>
        [HttpGet("estimate")]
        [RequestValidationFilter]
        public async Task<IActionResult> Estimate([FromQuery] TaxiRequest order)
        {
            if (_validator.Validate(order) == false)
            {
                return BadRequest();
            }

            var price = await _taxi.EstimateOrderAsync(order);
            var vm = _mapper.Map(price);

            return Ok(vm);
        }
    }
}
