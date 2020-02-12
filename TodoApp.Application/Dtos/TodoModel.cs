using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Domain.Common;

namespace TodoApp.Application.ViewModel
{
    public class TodoModel
    {
        public Guid Id { get; set; }
        public Guid SubCategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Status TodoStatus { get; set; }
    }
}
