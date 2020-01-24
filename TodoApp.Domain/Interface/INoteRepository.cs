using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Interface
{
    public interface INoteRepository: IGenericRepository<Note>
    {
        Task<QueryResult<Note>> GetAll(UserParams userParams);
        Task<Note> GetById(Guid id);
        Task<QueryResult<Note>> GetBySubCategoryId(Guid Id, UserParams userParams);
    }
}
