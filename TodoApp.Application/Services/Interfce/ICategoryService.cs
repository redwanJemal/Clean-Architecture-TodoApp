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
        CategoryModel Add(CategoryModel entity);
        CategoryModel Update(CategoryModel entity);
        CategoryModel Delete(Guid id);
    }
}
