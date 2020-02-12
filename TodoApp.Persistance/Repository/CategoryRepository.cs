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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly DbSet<Category> _categories;
        //private readonly TodoAppDbContext _context;

        public CategoryRepository(TodoAppDbContext context):base(context)
        {
            _categories = context.Categories;
        }
        public async Task<Category> GetById(Guid id)
        {
            var category = await _categories.Include(c => c.SubCategories).FirstOrDefaultAsync(c => c.Id == id);
            return category;
        }
        public async Task<QueryResult<Category>> GetAll(UserParams userParams)
        {
            var query = _categories
               .Include(c => c.SubCategories)
               .AsQueryable();
            var categories = _categories.Include(c => c.SubCategories);

            var result = await PagedList<Category>.ApplyPaging(query, userParams.PageNumber, userParams.PageSize);

            return result;
        }
    }
}

