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
    public class SubCategoryRepository : GenericRepository<SubCategory>, ISubCategoryRepository
    {
        public readonly DbSet<SubCategory> _subCategories;

        public SubCategoryRepository(TodoAppDbContext context): base(context)
        {
            _subCategories = context.SubCategories;
        }

        public async Task<QueryResult<SubCategory>> GetAll(UserParams userParams)
        {
            var query = _subCategories.AsQueryable();

            var result = await PagedList<SubCategory>.ApplyPaging(query, userParams.PageNumber, userParams.PageSize);

            return result;
        }

        public async Task<SubCategory> GetById(Guid id)
        {
            var category = await _subCategories
                .Include(s => s.Notes)
                .Include(s => s.Todos)
                .Include(s => s.Linkes)
                .Include(s => s.Files).FirstOrDefaultAsync(c => c.Id == id);
            
            return category;
        }

        public async Task<QueryResult<SubCategory>> GetByCategoryId(Guid Id, UserParams userParams)
        {
            var query = _subCategories.
                Where(s => s.CategoryId == Id)
                .Include(s => s.Notes)
                .Include(s => s.Todos).AsQueryable();

            var result = await PagedList<SubCategory>.ApplyPaging(query, userParams.PageNumber, userParams.PageSize);

            return result;
        }
    }
}

