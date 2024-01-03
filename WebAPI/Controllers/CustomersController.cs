using Business.Abstracts;
using Business.Dtos.Requests;
using Core.DataAccess.Paging;
using Entities.Concretes;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateCustomerRequest createCustomerRequest)
        {
            var result = await _customerService.Add(createCustomerRequest);
            return Ok(result);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _customerService.GetAll(pageRequest);
            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerRequest updateCustomerRequest)
        {
            var result=await _customerService.Update(updateCustomerRequest);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            var result=await _customerService.Delete(id);
            return Ok(result);
        }
    }
}
