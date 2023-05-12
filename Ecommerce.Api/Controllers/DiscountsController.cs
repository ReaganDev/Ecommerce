using ECommerce.Application.Contracts;
using ECommerce.Application.DTO_S.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public DiscountsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Discount(CreateDiscount request)
        {
            var result = await _service.DiscountService.CreateDiscount(request);

            return Ok(result);
        }
    }
}
