using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Interface
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; set; }
        ISubCategoryRepository SubCategoryRepository { get; set; }
        ITodoRepository TodoRepository { get; set; }
        INoteRepository NoteRepository { get; set; }
        ILinkRepository LinkRepository { get; set; }
        IFileRepository FileRepository { get; set; }

        void Commit();
        void RollBack();
    }
}
