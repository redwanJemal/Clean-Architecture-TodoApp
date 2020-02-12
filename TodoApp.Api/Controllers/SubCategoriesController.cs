﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Application.Services;
using TodoApp.Application.ViewModel;

namespace TodoApp.Api.Controllers
{
    [Route("api/subcategory/")]
    public class SubCategoriesController : Controller
    {
        private readonly ISubCategoryService _service;

        public SubCategoriesController(ISubCategoryService service)
        {
            _service = service;
        }
        [HttpPost("add")]
        public IActionResult Create([FromBody]SubCategoryModel model)
        {
            _service.Add(model);
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

        [HttpPost("get-by-id/{id}")]
        public IActionResult GetById(Guid id)
        {
            var subCategory = _service.GetById(id);
            return Ok(subCategory);
        }

        [HttpPost("update/{id}")]
        public IActionResult Update(Guid id, [FromBody]SubCategoryModel model)
        {
            _service.Update(model);
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
