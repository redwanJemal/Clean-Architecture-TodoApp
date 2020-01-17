using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Interface
{
    public interface ICategoryRepository
    {
        Task<QueryResult<Category>> GetAll(UserParams userParams);
        Task<Category> GetById(Guid id);
        Task Add(Category entity);
        Task Update(Category entity);
        Task Delete(Category entity);
    }
}
