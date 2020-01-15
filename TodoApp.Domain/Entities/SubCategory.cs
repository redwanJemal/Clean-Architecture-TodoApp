using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Domain.Entities
{
    public class SubCategory
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public List<Todo> Todos { get; set; }
        public List<Note> Notes { get; set; }
        public List<Link> Linkes { get; set; }
        public List<File> Files { get; set; }
        public SubCategory()
        {
            Todos = new List<Todo>();
            Notes = new List<Note>();
            Linkes = new List<Link>();
            Files = new List<File>();
        }
    }
}
