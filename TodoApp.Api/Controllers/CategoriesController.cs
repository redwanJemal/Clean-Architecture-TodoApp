using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Application.Services;
using TodoApp.Application.ViewModel;

namespace TodoApp.Api.Controllers
{
    [Route("api/category/")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }
        [HttpPost("add-category")]
        public IActionResult Create([FromBody]CategoryModel categoryModel)
        {
            CategoryModel category = _service.Add(categoryModel);
            return Ok(category);
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery]UserParamsModel userParams)
        {
            var categories = await _service.GetAll(userParams);
            Response.AddPaginationHeader(categories.CurrentPage, userParams.PageSize, categories.TotalItems, categories.TotalPage);

            return Ok(categories);
        }

        [HttpPost("get-ById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var category = await _service.GetById(id);
            return Ok(category);
        }

        [HttpPost("update/{id}")]
        public IActionResult Update(Guid id, [FromBody]CategoryModel categoryModel)
        {
            _service.Update(categoryModel);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
