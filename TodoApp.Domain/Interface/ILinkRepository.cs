using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Interface
{
    public interface ILinkRepository : IGenericRepository<Link>
    {
        Task<QueryResult<Link>> GetAll(UserParams userParams);
        Task<Link> GetById(Guid id);
        Task<QueryResult<Link>> GetBySubCategoryId(Guid Id, UserParams userParams);
    }
}
