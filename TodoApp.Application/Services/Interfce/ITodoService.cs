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
        Task<TodoModel> GetById(Guid id);
        Task Add(TodoModel entity);
        Task Update(TodoModel entity);
        Task Delete(Guid id);
        Task<QueryResult<TodoModel>> GetBySubCategoryId(Guid Id, UserParamsModel userParams);
    }
}
