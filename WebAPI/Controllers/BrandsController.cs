using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase,IsController<Brand>
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost("DeleteBrand")]
        public IActionResult Delete(Brand entity)
        {
            var result = _brandService.Delete(entity);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("BrandGetAll")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("BrandGetById")]
        public IActionResult GetById(int id)
        {
            var result = _brandService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("AddBrand")]
        public IActionResult Insert(Brand entity)
        {
            var result = _brandService.Insert(entity);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("UpdateBrand")]
        public IActionResult Update(Brand entity)
        {
            var result = _brandService.Update(entity);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
