using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.ViewModel;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Services.Interfce
{
    public interface INoteService
    {
        Task<QueryResult<NoteModel>> GetAll(UserParamsModel userParams);
        Task<NoteModel> GetById(Guid id);
        NoteModel Add(NoteModel entity);
        NoteModel Update(NoteModel entity);
        NoteModel Delete(Guid id);
        Task<QueryResult<NoteModel>> GetBySubCategoryId(Guid Id, UserParamsModel userParams);
    }
}
