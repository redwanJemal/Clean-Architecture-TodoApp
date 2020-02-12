using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Interface;
using TodoApp.Persistance.Repository;

namespace TodoApp.Persistance
{
    public class TodoAppDbContext: DbContext, IUnitOfWork
    {
        public DbSet<Category> Categories { get; set; }
        public ICategoryRepository CategoryRepository { get ; set; }


        public DbSet<SubCategory> SubCategories { get; set; }
        public ISubCategoryRepository SubCategoryRepository { get; set; }

        public DbSet<Todo> Todos { get; set; }
        public ITodoRepository TodoRepository { get; set; }

        public DbSet<Note> Notes { get; set; }
        public INoteRepository NoteRepository { get; set; }

        public DbSet<Link> Links { get; set; }
        public ILinkRepository LinkRepository { get; set; }

        public DbSet<File> Files { get; set; }
        public IFileRepository FileRepository { get; set; }

        TodoAppDbContext context;

        public TodoAppDbContext(DbContextOptions options) : base(options)
        {
            context = this;
            CategoryRepository = new CategoryRepository(context);
            SubCategoryRepository = new SubCategoryRepository(context);
            TodoRepository = new TodoRepository(context);
            NoteRepository = new NoteRepository(context);
            LinkRepository = new LinkRepository(context);
            FileRepository = new FileRepository(context);
        }

        public void Commit()
        {
            this.SaveChanges();
        }
        public void RollBack()
        {
            context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }
    }
}
