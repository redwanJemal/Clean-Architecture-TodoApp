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
        public List<TodoModel> Todos { get; set; }
        public List<NoteModel> Notes { get; set; }
        public List<LinkModel> Linkes { get; set; }
        public List<FileModel> Files { get; set; }
        public SubCategoryModel()
        {
            Todos = new List<TodoModel>();
            Notes = new List<NoteModel>();
            Linkes = new List<LinkModel>();
            Files = new List<FileModel>();
        }
    }
}
