using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.ViewModel;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Interface;

namespace TodoApp.Application.Services
{
    public class SubCategoryService : BaseService, ISubCategoryService
    {
        private readonly ISubCategoryRepository _repo;
        private readonly IMapper _mapper;


        public SubCategoryService(IUnitOfWork uow, IMapper mapper)
        {
            _repo = uow.SubCategoryRepository;
            _mapper = mapper;
            this.UoW = uow;
        }

        public SubCategoryModel Add(SubCategoryModel entity)
        {
            try
            {
                _repo.Add(_mapper.Map<SubCategory>(entity));

                UoW.Commit();
                return entity;
            }
            catch (Exception)
            {
                UoW.RollBack();
                return null;
            }
        }

        public SubCategoryModel Delete(Guid id)
        {
            try
            {
                SubCategory subCategory = _mapper.Map<SubCategory>(GetById(id));
                if (subCategory != null)
                {
                    _repo.Delete(subCategory);

                    this.UoW.Commit();
                    return _mapper.Map<SubCategoryModel>(subCategory);
                }
            }
            catch (Exception)
            {
                this.UoW.RollBack();
                return null;
            }

            return null;
        }

        public async Task<QueryResult<SubCategoryModel>> GetAll(UserParamsModel userParams)
        {
            var result = new QueryResult<SubCategoryModel>();
            var subCategories = await _repo.GetAll(_mapper.Map<UserParams>(userParams));

            List<SubCategoryModel> categoryModels = _mapper.Map<List<SubCategory>, List<SubCategoryModel>>(subCategories.Items);

            result.Items = categoryModels;
            result.TotalItems = subCategories.TotalItems;
            result.CurrentPage = subCategories.CurrentPage;
            result.TotalPage = subCategories.TotalPage;

            return result;
        }
        public async Task<QueryResult<SubCategoryModel>> GetByCategoryId(Guid Id, UserParamsModel userParams)
        {
            var result = new QueryResult<SubCategoryModel>();
            var subCategories = await _repo.GetByCategoryId(Id, _mapper.Map<UserParams>(userParams));
            List<SubCategoryModel> categoryModels = _mapper.Map<List<SubCategory>, List<SubCategoryModel>>(subCategories.Items);

            result.Items = categoryModels;
            result.TotalItems = subCategories.TotalItems;
            result.CurrentPage = subCategories.CurrentPage;
            result.TotalPage = subCategories.TotalPage;

            return result;
        }

        public async Task<SubCategoryModel> GetById(Guid id)
        {
            var subCategory = await _repo.GetById(id);
            return _mapper.Map<SubCategoryModel>(subCategory);
        }

        public SubCategoryModel Update(SubCategoryModel entity)
        {

            if (entity != null)
            {
                try
                {
                    SubCategory subCategory = _mapper.Map<SubCategory>(entity);
                    _repo.Update(subCategory);

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
