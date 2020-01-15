using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Interface;

namespace TodoApp.Persistance.Repository
{
    public class SubCategoryRepository : IGenericRepository<SubCategory>
    {
        private readonly TodoAppDbContext _context;

        public SubCategoryRepository(TodoAppDbContext context)
        {
            _context = context;
        }
        public async Task Add(SubCategory entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(SubCategory entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SubCategory>> GetAll()
        {
            var categories = await _context.SubCategories.ToListAsync();
            return categories;
        }

        public async Task<SubCategory> GetById(Guid id)
        {
            var category = await _context.SubCategories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
                return null;
            return category;
        }

        public async Task Update(SubCategory entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

