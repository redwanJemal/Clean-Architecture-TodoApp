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
    public class LinkRepository : GenericRepository<Link>, ILinkRepository
    {
        private readonly DbSet<Link> _links;

        public LinkRepository(TodoAppDbContext context): base(context)
        {
            _links = context.Links;
        }

        public async Task<QueryResult<Link>> GetAll(UserParams userParams)
        {
            var query = _links.AsQueryable();

            var result = await PagedList<Link>.ApplyPaging(query, userParams.PageNumber, userParams.PageSize);

            return result;
        }

        public async Task<Link>GetById(Guid id)
        {
            var category = await _links.FirstOrDefaultAsync(c => c.Id == id);

            return category;
        }

        public async Task<QueryResult<Link>> GetBySubCategoryId(Guid Id, UserParams userParams)
        {
            var query = _links.
                Where(s => s.SubCategoryId == Id).AsQueryable();

            var result = await PagedList<Link>.ApplyPaging(query, userParams.PageNumber, userParams.PageSize);

            return result;
        }
    }
}
