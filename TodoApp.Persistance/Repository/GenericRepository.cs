using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Domain.Interface;

namespace TodoApp.Persistance.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private TodoAppDbContext _db;
        internal DbSet<TEntity> dbSet;
        public GenericRepository(TodoAppDbContext context)
        {
            _db = context;
            dbSet = this._db.Set<TEntity>();
        }
        public TEntity Add(TEntity entity)
        {
            return dbSet.Add(entity).Entity;
        }

        public TEntity Delete(TEntity entity)
        {
            dbSet.Remove(entity);
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return entity;
        }

    }
}
