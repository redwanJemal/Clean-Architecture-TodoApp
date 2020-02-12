using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.ViewModel;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Services
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(Guid id);
    }
}
