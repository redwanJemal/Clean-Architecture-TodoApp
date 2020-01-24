using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Interface
{
    public interface ISubCategoryRepository: IGenericRepository<SubCategory>
    {
        Task<QueryResult<SubCategory>> GetAll(UserParams userParams);
        Task<SubCategory> GetById(Guid id);
        Task<QueryResult<SubCategory>> GetByCategoryId(Guid Id, UserParams userParams);
    }
}
