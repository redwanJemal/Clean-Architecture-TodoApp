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
    public class NoteRepository : INoteRepository
    {
        private readonly TodoAppDbContext _context;

        public NoteRepository(TodoAppDbContext context)
        {
            _context = context;
        }
        public async Task Add(Note entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Note entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<QueryResult<Note>> GetAll(UserParams userParams)
        {
            var query = _context.Notes.AsQueryable();

            var result = await PagedList<Note>.ApplyPaging(query, userParams.PageNumber, userParams.PageSize);

            return result;
        }

        public async Task<Note> GetById(Guid id)
        {
            var category = await _context.Notes.FirstOrDefaultAsync(c => c.Id == id);

            return category;
        }

        public async Task<QueryResult<Note>> GetBySubCategoryId(Guid Id, UserParams userParams)
        {
            var query = _context.Notes.
                Where(s => s.SubCategoryId == Id).AsQueryable();

            var result = await PagedList<Note>.ApplyPaging(query, userParams.PageNumber, userParams.PageSize);

            return result;
        }

        public async Task Update(Note entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
