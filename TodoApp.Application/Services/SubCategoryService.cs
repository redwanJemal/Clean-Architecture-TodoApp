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
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _repo;
        private readonly IMapper _mapper;


        public SubCategoryService(ISubCategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task Add(SubCategoryModel entity)
        {
            var newCategory = _mapper.Map<SubCategory>(entity);
            await _repo.Add(newCategory);
        }

        public async Task Delete(Guid id)
        {
            var category = await _repo.GetById(id);
            await _repo.Delete(category);
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

        public async Task Update(SubCategoryModel entity)
        {
            await _repo.Update(_mapper.Map<SubCategory>(entity));
        }
    }
}
