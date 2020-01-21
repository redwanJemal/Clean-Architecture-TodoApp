using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Interface
{
    public interface ISubCategoryRepository: IGenericRepository
    {
        Task<QueryResult<SubCategory>> GetAll(UserParams userParams);
        Task<QueryResult<SubCategory>> GetByCategoryId(Guid Id, UserParams userParams);
        Task<SubCategory> GetById(Guid id);
    }
}
