using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.ViewModel;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Services
{
    public interface ISubCategoryService
    {
        Task<QueryResult<SubCategoryModel>> GetAll(UserParamsModel userParams);
        Task<SubCategoryModel> GetById(Guid id);
        Task Add(SubCategoryModel entity);
        Task Update(SubCategoryModel entity);
        Task Delete(Guid id);
        Task<QueryResult<SubCategoryModel>> GetByCategoryId(Guid Id, UserParamsModel userParams);
    }
}
