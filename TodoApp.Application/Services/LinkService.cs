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
    public class LinkService : ILinkService
    {
        private readonly ILinkRepository _repo;
        private readonly IMapper _mapper;


        public LinkService(ILinkRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task Add(LinkModel entity)
        {
            var newEntity = _mapper.Map<Link>(entity);
            await _repo.Add(newEntity);
        }

        public async Task Delete(Guid id)
        {
            var entity = await _repo.GetById(id);
            await _repo.Delete(entity);
        }

        public async Task<QueryResult<LinkModel>> GetAll(UserParamsModel userParams)
        {
            var result = new QueryResult<LinkModel>();
            var subCategories = await _repo.GetAll(_mapper.Map<UserParams>(userParams));

            List<LinkModel> categoryModels = _mapper.Map<List<Link>, List<LinkModel>>(subCategories.Items);

            result.Items = categoryModels;
            result.TotalItems = subCategories.TotalItems;
            result.CurrentPage = subCategories.CurrentPage;
            result.TotalPage = subCategories.TotalPage;

            return result;
        }
        public async Task<QueryResult<LinkModel>> GetBySubCategoryId(Guid Id, UserParamsModel userParams)
        {
            var result = new QueryResult<LinkModel>();
            var entities = await _repo.GetBySubCategoryId(Id, _mapper.Map<UserParams>(userParams));
            List<LinkModel> models = _mapper.Map<List<Link>, List<LinkModel>>(entities.Items);

            result.Items = models;
            result.TotalItems = entities.TotalItems;
            result.CurrentPage = entities.CurrentPage;
            result.TotalPage = entities.TotalPage;

            return result;
        }

        public async Task<LinkModel> GetById(Guid id)
        {
            var entity = await _repo.GetById(id);
            return _mapper.Map<LinkModel>(entity);
        }

        public async Task Update(LinkModel entity)
        {
            await _repo.Update(_mapper.Map<Link>(entity));
        }
    }
}
