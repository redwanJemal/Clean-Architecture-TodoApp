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
    public class FileRepository : GenericRepository<File>, IFileRepository
    {
        private readonly DbSet<File> _files;


        public FileRepository(TodoAppDbContext context): base(context)
        {
            _files = context.Files;
        }

        public async Task<QueryResult<File>> GetAll(UserParams userParams)
        {
            var query = _files.AsQueryable();

            var result = await PagedList<File>.ApplyPaging(query, userParams.PageNumber, userParams.PageSize);

            return result;
        }

        public async Task<File>GetById(Guid id)
        {
            var files = await _files.FirstOrDefaultAsync(c => c.Id == id);

            return files;
        }

        public async Task<QueryResult<File>> GetBySubCategoryId(Guid Id, UserParams userParams)
        {
            var query = _files.
                Where(s => s.SubCategoryId == Id).AsQueryable();

            var result = await PagedList<File>.ApplyPaging(query, userParams.PageNumber, userParams.PageSize);

            return result;
        }
    }
}
