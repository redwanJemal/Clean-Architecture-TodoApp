using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.ViewModel;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Services
{
    public interface ICategoryService
    {
        Task<QueryResult<CategoryModel>> GetAll(UserParamsModel userParams);
        Task<CategoryDetailModel> GetById(Guid id);
        Task Add(CategoryModel entity);
        Task Update(CategoryModel entity);
        Task Delete(Guid id);
    }
}
