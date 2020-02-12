using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Application.ViewModel
{
    public class FileModel
    {
        public Guid Id { get; set; }
        public Guid SubCategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
