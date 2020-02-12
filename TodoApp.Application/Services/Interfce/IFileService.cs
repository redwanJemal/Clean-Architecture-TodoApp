using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.ViewModel;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Services.Interfce
{
    public interface IFileService
    {
        Task<QueryResult<FileModel>> GetAll(UserParamsModel userParams);
        FileModel GetById(Guid id);
        FileModel Add(FileModel entity);
        FileModel Update(FileModel entity);
        FileModel Delete(Guid id);
        Task<QueryResult<FileModel>> GetBySubCategoryId(Guid Id, UserParamsModel userParams);
    }
}
