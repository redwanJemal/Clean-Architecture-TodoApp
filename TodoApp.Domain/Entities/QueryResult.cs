using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Domain.Entities
{
    public class QueryResult<T>
    {
        public int TotalItems { get; set; }
        public List<T> Items { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
    }
}
