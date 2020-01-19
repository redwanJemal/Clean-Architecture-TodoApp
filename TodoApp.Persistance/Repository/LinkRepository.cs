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
    public class LinkRepository : ILinkRepository
    {
        private readonly TodoAppDbContext _context;

        public LinkRepository(TodoAppDbContext context)
        {
            _context = context;
        }
        public async Task Add(Link entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Link entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<QueryResult<Link>> GetAll(UserParams userParams)
        {
            var query = _context.Links.AsQueryable();

            var result = await PagedList<Link>.ApplyPaging(query, userParams.PageNumber, userParams.PageSize);

            return result;
        }

        public async Task<Link>GetById(Guid id)
        {
            var category = await _context.Links.FirstOrDefaultAsync(c => c.Id == id);

            return category;
        }

        public async Task<QueryResult<Link>> GetBySubCategoryId(Guid Id, UserParams userParams)
        {
            var query = _context.Links.
                Where(s => s.SubCategoryId == Id).AsQueryable();

            var result = await PagedList<Link>.ApplyPaging(query, userParams.PageNumber, userParams.PageSize);

            return result;
        }

        public async Task Update(Link entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
