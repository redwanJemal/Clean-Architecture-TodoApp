using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Interface;

namespace TodoApp.Persistance.Repository.Common
{
    public class GenericRepository : IGenericRepository
    {
        private readonly TodoAppDbContext _context;

        public GenericRepository(TodoAppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add<T>(T entity) where T : class
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update<T>(T entity) where T : class
        {
            _context.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
