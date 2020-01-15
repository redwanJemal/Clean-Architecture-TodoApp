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
    public class CategoryController: Controller
    {
        private readonly IGenericService<CategoryModel> _categoryService;

        public CategoryController(IGenericService<CategoryModel> categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost("add-category")]
        public async Task<IActionResult> Create([FromBody]CategoryModel categoryModel)
        {
            await _categoryService.Add(categoryModel);
            return Ok(categoryModel);
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAll();
            return Ok(categories);
        }

        [HttpPost("get-ById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var category = await _categoryService.GetById(id);
            return Ok(category);
        }

        [HttpPost("update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody]CategoryModel categoryModel)
        {
            await _categoryService.Update(categoryModel);
            return NoContent();
        }

        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _categoryService.Delete(id);
            return NoContent();
        }
    }
}
