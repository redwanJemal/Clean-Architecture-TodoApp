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
    public class LinkService : BaseService, ILinkService
    {
        private readonly ILinkRepository _repo;
        private readonly IMapper _mapper;


        public LinkService(IUnitOfWork uow, IMapper mapper)
        {
            _repo = uow.LinkRepository;
            _mapper = mapper;
            this.UoW = uow;
        }

        public LinkModel Add(LinkModel entity)
        {
            try
            {
                _repo.Add(_mapper.Map<Link>(entity));

                UoW.Commit();
                return entity;
            }
            catch (Exception)
            {
                UoW.RollBack();
                return null;
            }
        }

        public LinkModel Delete(Guid id)
        {
            try
            {
                Link link = _mapper.Map<Link>(GetById(id));
                if (link != null)
                {
                    _repo.Delete(link);

                    this.UoW.Commit();
                    return _mapper.Map<LinkModel>(link);
                }
            }
            catch (Exception)
            {
                this.UoW.RollBack();
                return null;
            }

            return null;
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

        public LinkModel Update(LinkModel entity)
        {
            if (entity != null)
            {
                try
                {
                    Link link = _mapper.Map<Link>(entity);
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
