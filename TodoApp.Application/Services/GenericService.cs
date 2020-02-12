using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Application.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        public GenericService()
        {
                
        }
        public TEntity Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
