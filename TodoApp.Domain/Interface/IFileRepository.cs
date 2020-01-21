using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Interface
{
    public interface IFileRepository : IGenericRepository
    {
        Task<QueryResult<File>> GetAll(UserParams userParams);
        Task<QueryResult<File>> GetBySubCategoryId(Guid Id, UserParams userParams);
        Task<File> GetById(Guid id);
    }
}
