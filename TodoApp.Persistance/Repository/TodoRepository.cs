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
    public class TodoRepository : GenericRepository<Todo>, ITodoRepository
    {
        public readonly DbSet<Todo> _todos;

        public TodoRepository(TodoAppDbContext context): base(context)
        {
            _todos = context.Todos;
        }

        public async Task<QueryResult<Todo>> GetAll(UserParams userParams)
        {
            var query = _todos.AsQueryable();

            var result = await PagedList<Todo>.ApplyPaging(query, userParams.PageNumber, userParams.PageSize);

            return result;
        }

        public async Task<Todo> GetById(Guid id)
        {
            var category = await _todos.FirstOrDefaultAsync(c => c.Id == id);

            return category;
        }

        public async Task<QueryResult<Todo>> GetBySubCategoryId(Guid Id, UserParams userParams)
        {
            var query = _todos.
                Where(s => s.SubCategoryId == Id).AsQueryable();

            var result = await PagedList<Todo>.ApplyPaging(query, userParams.PageNumber, userParams.PageSize);

            return result;
        }
    }
}
