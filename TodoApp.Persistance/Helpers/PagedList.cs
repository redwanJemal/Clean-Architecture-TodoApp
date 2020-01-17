using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;

namespace TodoApp.Persistance.Helpers
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public QueryResult<T> Items { get; set; }

        public PagedList(QueryResult<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            CurrentPage = pageNumber;
            PageSize = pageSize;
            TotalPage = (int)Math.Ceiling(count / (double)pageSize);
            Items = items;
        }
        public static async Task<QueryResult<T>> ApplyPaging(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var result = new QueryResult<T>
            {
                Items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(),
                TotalItems = count,
                CurrentPage = pageNumber,
                TotalPage = (int)Math.Ceiling(count / (double)pageSize)
            };
            return result;
        }
    }
}
