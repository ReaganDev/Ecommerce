using ECommerce.Application.Contracts;
using ECommerce.Application.DTO_S.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CustomersController(IServiceManager service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomer request)
        {
            var result = await _service.CustomerService.CreateCustomer(request);

            return Ok(result);
        }

        [HttpPut("{phoneNumber}")]
        public async Task<IActionResult> UpdateCustomer(string phoneNumber, UpdateCustomer request)
        {
            var result = await _service.CustomerService.UpdateCustomer(phoneNumber, request);

            return Ok(result);
        }

        [HttpGet("{phoneNumber}")]
        public async Task<IActionResult> ProfileCustomer([FromRoute] string phoneNumber)
        {
            var result = await _service.CustomerService.ProfileCustomer(phoneNumber);

            return Ok(result);
        }

    }
}
