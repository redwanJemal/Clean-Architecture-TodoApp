using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Application.Services;
using TodoApp.Application.Services.Interfce;
using TodoApp.Application.ViewModel;

namespace TodoApp.Api.Controllers
{
    [Route("api/note/")]
    public class NoteController : Controller
    {
        private readonly INoteService _service;

        public NoteController(INoteService service)
        {
            _service = service;
        }
        [HttpPost("add-note")]
        public async Task<IActionResult> Create([FromBody]NoteModel model)
        {
            await _service.Add(model);
            return Ok(model);
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery]UserParamsModel userParams)
        {
            var entities = await _service.GetAll(userParams);
            Response.AddPaginationHeader(entities.CurrentPage, userParams.PageSize, entities.TotalItems, entities.TotalPage);

            return Ok(entities);
        }


        [HttpGet("get-by-sub-category-id/{id}")]
        public async Task<IActionResult> GetByCategoryId(Guid id, [FromQuery]UserParamsModel userParams)
        {
            var entities = await _service.GetBySubCategoryId(id, userParams);
            Response.AddPaginationHeader(entities.CurrentPage, userParams.PageSize, entities.TotalItems, entities.TotalPage);

            return Ok(entities);
        }

        [HttpPost("get-by-Id/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var entity = await _service.GetById(id);
            return Ok(entity);
        }

        [HttpPost("update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody]NoteModel model)
        {
            await _service.Update(model);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}
