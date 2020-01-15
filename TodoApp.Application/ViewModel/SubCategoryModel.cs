using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Application.ViewModel
{
    public class SubCategoryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
    }
}
