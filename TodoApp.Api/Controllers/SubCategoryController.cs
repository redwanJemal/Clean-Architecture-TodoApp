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
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService _service;

        public SubCategoryController(ISubCategoryService service)
        {
            _service = service;
        }
        [HttpPost("add-subCategory")]
        public async Task<IActionResult> Create([FromBody]SubCategoryModel model)
        {
            await _service.Add(model);
            return Ok(model);
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery]UserParamsModel userParams)
        {
            var categories = await _service.GetAll(userParams);
            Response.AddPaginationHeader(categories.CurrentPage, userParams.PageSize, categories.TotalItems, categories.TotalPage);

            return Ok(categories);
        }


        [HttpGet("get-by-category-id/{id}")]
        public async Task<IActionResult> GetByCategoryId(Guid id, [FromQuery]UserParamsModel userParams)
        {
            var categories = await _service.GetByCategoryId(id, userParams);
            Response.AddPaginationHeader(categories.CurrentPage, userParams.PageSize, categories.TotalItems, categories.TotalPage);

            return Ok(categories);
        }

        [HttpPost("get-ById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var subCategory = await _service.GetById(id);
            return Ok(subCategory);
        }

        [HttpPost("update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody]SubCategoryModel model)
        {
            await _service.Update(model);
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
