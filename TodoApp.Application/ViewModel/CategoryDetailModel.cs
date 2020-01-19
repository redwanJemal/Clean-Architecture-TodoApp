using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Application.ViewModel
{
    public class CategoryDetailModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<SubCategoryModel> SubCategories { get; set; }
    }
}
