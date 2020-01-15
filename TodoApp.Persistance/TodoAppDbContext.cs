using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Domain.Entities;

namespace TodoApp.Persistance
{
    public class TodoAppDbContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<File> Files { get; set; }

        public TodoAppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
