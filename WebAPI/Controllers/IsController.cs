using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
   
    public interface IsController <T>
    {
        [HttpGet]
        IActionResult GetAll();
        [HttpGet]
        IActionResult GetById(int id);

        [HttpPost]
        IActionResult Insert(T entity);
        [HttpPost]
        IActionResult Update(T entity);
        [HttpPost]
        IActionResult Delete(T entity);
    }
}
