/*using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasesController<T> : ControllerBase
    {
        IBaseService<T> _baseService;
       
        public BasesController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }

        [HttpPost("BaseDelete")]
        public IActionResult Delete(T entity)
        {
            var result = _baseService.Delete(entity);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("BaseGetAll")]
        public IActionResult GetAll()
        {
            var result = _baseService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("BaseGetById")]
        public IActionResult GetById(int id)
        {
            var result = _baseService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("AddBase")]
        public IActionResult Insert(T entity)
        {
            var result = _baseService.Insert(entity);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("UpdateBase")]
        public IActionResult Update(T entity)
        {
            var result = _baseService.Update(entity);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
*/