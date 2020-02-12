using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.Services.Interfce;
using TodoApp.Application.ViewModel;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Interface;

namespace TodoApp.Application.Services
{
    public class FileService : BaseService, IFileService
    {
        private readonly IFileRepository _repo;
        private readonly IMapper _mapper;


        public FileService(IUnitOfWork uow, IMapper mapper)
        {
            _repo = uow.FileRepository;
            _mapper = mapper;
            this.UoW = uow;
        }

        public FileModel Add(FileModel entity)
        {
            try
            {
                _repo.Add(_mapper.Map<File>(entity));

                UoW.Commit();
                return entity;
            }
            catch (Exception)
            {
                UoW.RollBack();
                return null;
            }
        }

        public FileModel Delete(Guid id)
        {
            try
            {
                File category = _mapper.Map<File>(GetById(id));
                if (category != null)
                {
                    _repo.Delete(category);

                    this.UoW.Commit();
                    return _mapper.Map<FileModel>(category);
                }
            }
            catch (Exception)
            {
                this.UoW.RollBack();
                return null;
            }

            return null;
        }

        public async Task<QueryResult<FileModel>> GetAll(UserParamsModel userParams)
        {
            var result = new QueryResult<FileModel>();
            var subCategories = await _repo.GetAll(_mapper.Map<UserParams>(userParams));

            List<FileModel> categoryModels = _mapper.Map<List<File>, List<FileModel>>(subCategories.Items);

            result.Items = categoryModels;
            result.TotalItems = subCategories.TotalItems;
            result.CurrentPage = subCategories.CurrentPage;
            result.TotalPage = subCategories.TotalPage;

            return result;
        }
        public async Task<QueryResult<FileModel>> GetBySubCategoryId(Guid Id, UserParamsModel userParams)
        {
            var result = new QueryResult<FileModel>();
            var entities = await _repo.GetBySubCategoryId(Id, _mapper.Map<UserParams>(userParams));
            List<FileModel> models = _mapper.Map<List<File>, List<FileModel>>(entities.Items);

            result.Items = models;
            result.TotalItems = entities.TotalItems;
            result.CurrentPage = entities.CurrentPage;
            result.TotalPage = entities.TotalPage;

            return result;
        }

        public FileModel GetById(Guid id)
        {
            var entity = _repo.GetById(id);
            return _mapper.Map<FileModel>(entity);
        }

        public FileModel Update(FileModel entity)
        {
            if (entity != null)
            {
                try
                {
                    File category = _mapper.Map<File>(entity);
                    _repo.Update(category);

                    UoW.Commit();
                    return entity;
                }
                catch (Exception)
                {
                    UoW.RollBack();
                    return null;
                }
            }
            return null;
        }
    }
}
