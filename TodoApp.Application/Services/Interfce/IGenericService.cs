using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.ViewModel;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Services
{
    public interface IGenericService<T>
    {
        Task<List<T>> GetAll();
        Task<QueryResult<T>> GetAll(UserParamsModel userParams);
        Task<T> GetById(Guid id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(Guid id);
    }
}
