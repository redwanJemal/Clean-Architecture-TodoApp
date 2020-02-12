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
    public class TodoService: BaseService, ITodoService
    {
        private readonly ITodoRepository _repo;
        private readonly IMapper _mapper;


        public TodoService(IUnitOfWork uow, IMapper mapper)
        {
            _repo = uow.TodoRepository;
            _mapper = mapper;
            this.UoW = uow;
        }

        public TodoModel Add(TodoModel entity)
        {
            try
            {
                _repo.Add(_mapper.Map<Todo>(entity));

                UoW.Commit();
                return entity;
            }
            catch (Exception)
            {
                UoW.RollBack();
                return null;
            }
        }

        public TodoModel Delete(Guid id)
        {
            try
            {
                Todo todo = _mapper.Map<Todo>(GetById(id));
                if (todo != null)
                {
                    _repo.Delete(todo);

                    this.UoW.Commit();
                    return _mapper.Map<TodoModel>(todo);
                }
            }
            catch (Exception)
            {
                this.UoW.RollBack();
                return null;
            }

            return null;
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

        public TodoModel Update(TodoModel entity)
        {
            if (entity != null)
            {
                try
                {
                    Todo todo = _mapper.Map<Todo>(entity);
                    _repo.Update(todo);

                    UoW.Commit();
                    return entity;
                }
                catch (Exception)
                {
                    UoW.RollBack();
                    return null;
                }
            }
            return null;
        }
    }
}
