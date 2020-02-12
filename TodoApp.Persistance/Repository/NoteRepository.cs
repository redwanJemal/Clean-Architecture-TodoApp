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
    public class NoteRepository : GenericRepository<Note>, INoteRepository
    {
        private readonly DbSet<Note> _notes;


        public NoteRepository(TodoAppDbContext context): base(context)
        {
            _notes = context.Notes;
        }

        public async Task<QueryResult<Note>> GetAll(UserParams userParams)
        {
            var query = _notes.AsQueryable();

            var result = await PagedList<Note>.ApplyPaging(query, userParams.PageNumber, userParams.PageSize);

            return result;
        }

        public async Task<Note> GetById(Guid id)
        {
            var category = await _notes.FirstOrDefaultAsync(c => c.Id == id);

            return category;
        }

        public async Task<QueryResult<Note>> GetBySubCategoryId(Guid Id, UserParams userParams)
        {
            var query = _notes.
                Where(s => s.SubCategoryId == Id).AsQueryable();

            var result = await PagedList<Note>.ApplyPaging(query, userParams.PageNumber, userParams.PageSize);

            return result;
        }

    }
}
