using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Domain.Common;

namespace TodoApp.Domain.Entities
{
    public class Note : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
