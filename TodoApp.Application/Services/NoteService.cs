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
    public class NoteService : BaseService, INoteService
    {
        private readonly INoteRepository _repo;
        private readonly IMapper _mapper;


        public NoteService(IUnitOfWork uow, IMapper mapper)
        {
            _repo = uow.NoteRepository;
            _mapper = mapper;
            this.UoW = uow;
        }

        public NoteModel Add(NoteModel entity)
        {
            var newEntity = _mapper.Map<Note>(entity);
            return _mapper.Map<NoteModel>(_repo.Add(newEntity));
        }

        public NoteModel Delete(Guid id)
        {
            try
            {
                Note link = _mapper.Map<Note>(GetById(id));
                if (link != null)
                {
                    _repo.Delete(link);

                    this.UoW.Commit();
                    return _mapper.Map<NoteModel>(link);
                }
            }
            catch (Exception)
            {
                this.UoW.RollBack();
                return null;
            }

            return null;
        }

        public async Task<QueryResult<NoteModel>> GetAll(UserParamsModel userParams)
        {
            var result = new QueryResult<NoteModel>();
            var subCategories = await _repo.GetAll(_mapper.Map<UserParams>(userParams));

            List<NoteModel> categoryModels = _mapper.Map<List<Note>, List<NoteModel>>(subCategories.Items);

            result.Items = categoryModels;
            result.TotalItems = subCategories.TotalItems;
            result.CurrentPage = subCategories.CurrentPage;
            result.TotalPage = subCategories.TotalPage;

            return result;
        }
        public async Task<QueryResult<NoteModel>> GetBySubCategoryId(Guid Id, UserParamsModel userParams)
        {
            var result = new QueryResult<NoteModel>();
            var entities = await _repo.GetBySubCategoryId(Id, _mapper.Map<UserParams>(userParams));
            List<NoteModel> models = _mapper.Map<List<Note>, List<NoteModel>>(entities.Items);

            result.Items = models;
            result.TotalItems = entities.TotalItems;
            result.CurrentPage = entities.CurrentPage;
            result.TotalPage = entities.TotalPage;

            return result;
        }

        public NoteModel GetById(Guid id)
        {
            var entity = _repo.GetById(id);
            return _mapper.Map<NoteModel>(entity);
        }

        public NoteModel Update(NoteModel entity)
        {
            if (entity != null)
            {
                try
                {
                    Note link = _mapper.Map<Note>(entity);
                    _repo.Update(link);

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
