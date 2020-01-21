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
    public class TodoRepository : GenericRepository, ITodoRepository
    {
        private readonly TodoAppDbContext _context;

        public TodoRepository(TodoAppDbContext context): base(context)
        {
            _context = context;
        }

        public async Task<QueryResult<Todo>> GetAll(UserParams userParams)
        {
            var query = _context.Todos.AsQueryable();

            var result = await PagedList<Todo>.ApplyPaging(query, userParams.PageNumber, userParams.PageSize);

            return result;
        }

        public async Task<Todo> GetById(Guid id)
        {
            var category = await _context.Todos.FirstOrDefaultAsync(c => c.Id == id);

            return category;
        }

        public async Task<QueryResult<Todo>> GetBySubCategoryId(Guid Id, UserParams userParams)
        {
            var query = _context.Todos.
                Where(s => s.SubCategoryId == Id).AsQueryable();

            var result = await PagedList<Todo>.ApplyPaging(query, userParams.PageNumber, userParams.PageSize);

            return result;
        }
    }
}
