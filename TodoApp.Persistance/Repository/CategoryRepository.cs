using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Interface;
using TodoApp.Persistance.Helpers;
using TodoApp.Persistance.Repository.Common;

namespace TodoApp.Persistance.Repository
{
    public class CategoryRepository : GenericRepository, ICategoryRepository
    {
        private readonly TodoAppDbContext _context;

        public CategoryRepository(TodoAppDbContext context): base(context)
        {
            _context = context;
        }
        public async Task<Category> GetById(Guid id)
        {
            var category = await _context.Categories.Include(c => c.SubCategories).FirstOrDefaultAsync(c => c.Id == id);
            return category;
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

