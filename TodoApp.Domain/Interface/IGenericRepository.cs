using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Interface
{
    public interface IGenericRepository<TEntity>
    {
        //Task<TEntity> Query(string qlQuery);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);
    }
}
