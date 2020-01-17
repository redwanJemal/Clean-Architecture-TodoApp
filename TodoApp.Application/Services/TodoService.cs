using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.Services.Interfce;
using TodoApp.Application.ViewModel;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Interface;

namespace TodoApp.Application.Services
{
    public class TodoService: ITodoService
    {
        private readonly ITodoRepository _repo;
        private readonly IMapper _mapper;


        public TodoService(ITodoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task Add(TodoModel entity)
        {
            var newEntity = _mapper.Map<Todo>(entity);
            await _repo.Add(newEntity);
        }

        public async Task Delete(Guid id)
        {
            var entity = await _repo.GetById(id);
            await _repo.Delete(entity);
        }

        public async Task<QueryResult<TodoModel>> GetAll(UserParamsModel userParams)
        {
            var result = new QueryResult<TodoModel>();
            var subCategories = await _repo.GetAll(_mapper.Map<UserParams>(userParams));

            List<TodoModel> categoryModels = _mapper.Map<List<Todo>, List<TodoModel>>(subCategories.Items);

            result.Items = categoryModels;
            result.TotalItems = subCategories.TotalItems;
            result.CurrentPage = subCategories.CurrentPage;
            result.TotalPage = subCategories.TotalPage;

            return result;
        }
        public async Task<QueryResult<TodoModel>> GetBySubCategoryId(Guid Id, UserParamsModel userParams)
        {
            var result = new QueryResult<TodoModel>();
            var entities = await _repo.GetBySubCategoryId(Id, _mapper.Map<UserParams>(userParams));
            List<TodoModel> models = _mapper.Map<List<Todo>, List<TodoModel>>(entities.Items);

            result.Items = models;
            result.TotalItems = entities.TotalItems;
            result.CurrentPage = entities.CurrentPage;
            result.TotalPage = entities.TotalPage;

            return result;
        }

        public async Task<TodoModel> GetById(Guid id)
        {
            var entity = await _repo.GetById(id);
            return _mapper.Map<TodoModel>(entity);
        }

        public async Task Update(TodoModel entity)
        {
            await _repo.Update(_mapper.Map<Todo>(entity));
        }
    }
}
