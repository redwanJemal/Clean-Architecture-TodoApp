using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Application.Services;
using TodoApp.Application.ViewModel;

namespace TodoApp.Api.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly IGenericService<CategoryModel> _service;

        public CategoryController(IGenericService<CategoryModel> service)
        {
            _service = service;
        }
        [HttpPost("add-category")]
        public async Task<IActionResult> Create([FromBody]CategoryModel categoryModel)
        {
            await _service.Add(categoryModel);
            return Ok(categoryModel);
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
        public async Task<IActionResult> Update(Guid id, [FromBody]CategoryModel categoryModel)
        {
            await _service.Update(categoryModel);
            return NoContent();
        }

        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}
