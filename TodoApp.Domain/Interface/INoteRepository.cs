using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Interface
{
    public interface INoteRepository
    {
        Task<QueryResult<Note>> GetAll(UserParams userParams);
        Task<QueryResult<Note>> GetBySubCategoryId(Guid Id, UserParams userParams);
        Task<Note> GetById(Guid id);
        Task Add(Note entity);
        Task Update(Note entity);
        Task Delete(Note entity);
    }
}
