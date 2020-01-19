using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Interface;
using TodoApp.Persistance.Helpers;

namespace TodoApp.Persistance.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TodoAppDbContext _context;

        public CategoryRepository(TodoAppDbContext context)
        {
            _context = context;
        }
        public async Task Add(Category entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Category entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Category> GetById(Guid id)
        {
            var category = await _context.Categories.Include(c => c.SubCategories).FirstOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task Update(Category entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<QueryResult<Category>> GetAll(UserParams userParams)
        {
            var query = _context.Categories
               .Include(c => c.SubCategories)
               .AsQueryable();
            var categories = _context.Categories.Include(c => c.SubCategories);

            var result = await PagedList<Category>.ApplyPaging(query, userParams.PageNumber, userParams.PageSize);

            return result;
        }
    }
}

