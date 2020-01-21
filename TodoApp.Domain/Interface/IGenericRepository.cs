using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Interface
{
    public interface IGenericRepository
    {
        Task<bool> Add<T>(T entity) where T: class;
        Task<bool> Update<T>(T entity) where T : class;
        Task<bool> Delete<T>(T entity) where T : class;
    }
}
