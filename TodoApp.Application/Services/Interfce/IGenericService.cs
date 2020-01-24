using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.ViewModel;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Services
{
    public interface IGenericService
    {
        Task<T> Add<T>(T entity) where T : class;
        Task<T> Update<T>(T entity) where T : class;
        Task<T> Delete<T>(Guid id) where T : class;
    }
}
