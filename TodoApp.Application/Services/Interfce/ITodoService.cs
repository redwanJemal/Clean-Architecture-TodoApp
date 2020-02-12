using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.ViewModel;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Services.Interfce
{
    public interface ITodoService
    {
        Task<QueryResult<TodoModel>> GetAll(UserParamsModel userParams);
        TodoModel GetById(Guid id);
        TodoModel Add(TodoModel entity);
        TodoModel Update(TodoModel entity);
        TodoModel Delete(Guid id);
        Task<QueryResult<TodoModel>> GetBySubCategoryId(Guid Id, UserParamsModel userParams);
    }
}
