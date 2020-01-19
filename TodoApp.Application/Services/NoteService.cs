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
    public class NoteService: INoteService
    {
        private readonly INoteRepository _repo;
        private readonly IMapper _mapper;


        public NoteService(INoteRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task Add(NoteModel entity)
        {
            var newEntity = _mapper.Map<Note>(entity);
            await _repo.Add(newEntity);
        }

        public async Task Delete(Guid id)
        {
            var entity = await _repo.GetById(id);
            await _repo.Delete(entity);
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

        public async Task<NoteModel> GetById(Guid id)
        {
            var entity = await _repo.GetById(id);
            return _mapper.Map<NoteModel>(entity);
        }

        public async Task Update(NoteModel entity)
        {
            await _repo.Update(_mapper.Map<Note>(entity));
        }
    }
}
