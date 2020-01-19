using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Interface
{
    public interface ILinkRepository
    {
        Task<QueryResult<Link>> GetAll(UserParams userParams);
        Task<QueryResult<Link>> GetBySubCategoryId(Guid Id, UserParams userParams);
        Task<Link> GetById(Guid id);
        Task Add(Link entity);
        Task Update(Link entity);
        Task Delete(Link entity);
    }
}
