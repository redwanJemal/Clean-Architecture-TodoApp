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
    public class FileRepository : GenericRepository, IFileRepository
    {
        private readonly TodoAppDbContext _context;

        public FileRepository(TodoAppDbContext context): base(context)
        {
            _context = context;
        }

        public async Task<QueryResult<File>> GetAll(UserParams userParams)
        {
            var query = _context.Files.AsQueryable();

            var result = await PagedList<File>.ApplyPaging(query, userParams.PageNumber, userParams.PageSize);

            return result;
        }

        public async Task<File>GetById(Guid id)
        {
            var category = await _context.Files.FirstOrDefaultAsync(c => c.Id == id);

            return category;
        }

        public async Task<QueryResult<File>> GetBySubCategoryId(Guid Id, UserParams userParams)
        {
            var query = _context.Files.
                Where(s => s.SubCategoryId == Id).AsQueryable();

            var result = await PagedList<File>.ApplyPaging(query, userParams.PageNumber, userParams.PageSize);

            return result;
        }
    }
}
