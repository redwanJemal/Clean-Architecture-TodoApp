using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Interface
{
    public interface ITodoRepository: IGenericRepository
    {
        Task<QueryResult<Todo>> GetAll(UserParams userParams);
        Task<QueryResult<Todo>> GetBySubCategoryId(Guid Id, UserParams userParams);
        Task<Todo> GetById(Guid id);
    }
}
