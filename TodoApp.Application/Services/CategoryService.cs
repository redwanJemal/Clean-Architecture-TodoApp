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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;


        public CategoryService(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task Add(CategoryModel entity)
        {
            var newCategory = _mapper.Map<Category>(entity);
            await _repo.Add(newCategory);
        }

        public async Task Delete(Guid id)
        {
            var category = await _repo.GetById(id);
            await _repo.Delete(category);
        }

        public async Task<QueryResult<CategoryModel>> GetAll(UserParamsModel userParams)
        {
            var result = new QueryResult<CategoryModel>();
            var categories = await _repo.GetAll(_mapper.Map<UserParams>(userParams));

            List<CategoryModel> categoryModels = _mapper.Map<List<Category>, List<CategoryModel>>(categories.Items);

            result.Items = categoryModels;
            result.TotalItems = categories.TotalItems;
            result.CurrentPage = categories.CurrentPage;
            result.TotalPage = categories.TotalPage;

            return result;
        }

        public async Task<CategoryDetailModel> GetById(Guid id)
        {
            var category = await _repo.GetById(id);
            return _mapper.Map<CategoryDetailModel>(category);
        }

        public async Task Update(CategoryModel entity)
        {
            await _repo.Update(_mapper.Map<Category>(entity));
        }
    }
}
