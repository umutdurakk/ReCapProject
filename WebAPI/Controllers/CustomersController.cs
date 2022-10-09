using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase,IsController<Customer>
    {
        ICustomerService _customerService;

        public CustomersController(ICustomerService custonmerService)
        {
            _customerService = custonmerService;
        }
        [HttpPost("DeleteCustomer")]
        public IActionResult Delete(Customer entity)
        {
            var result = _customerService.Delete(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("CustomerGetAll")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("CustomerGetById")]
        public IActionResult GetById(int id)
        {
            var result = _customerService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("AddCustomer")]
        public IActionResult Insert(Customer entity)
        {
            var result = _customerService.Insert(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("UpdateCustomer")]
        public IActionResult Update(Customer entity)
        {
            var result = _customerService.Update(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
