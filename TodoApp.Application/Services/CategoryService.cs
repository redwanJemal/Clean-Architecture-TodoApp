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
    public class CategoryService : IGenericService<CategoryModel>
    {
        private readonly IGenericRepository<Category> _repo;
        private readonly IMapper _mapper;


        public CategoryService(IGenericRepository<Category> categoryRepository, IMapper mapper)
        {
            _repo = categoryRepository;
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

        public async Task<List<CategoryModel>> GetAll()
        {
            var categories = await _repo.GetAll();
            List<CategoryModel> categoryModels = _mapper.Map<List<Category>, List<CategoryModel>>(categories);
            return categoryModels;
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

        public async Task<CategoryModel> GetById(Guid id)
        {
            var category = await _repo.GetById(id);
            return _mapper.Map<CategoryModel>(category);
        }

        public async Task Update(CategoryModel entity)
        {
            await _repo.Update(_mapper.Map<Category>(entity));
        }
    }
}
