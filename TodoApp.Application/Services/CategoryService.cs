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
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;


        public CategoryService(IGenericRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task Add(CategoryModel entity)
        {
            var newCategory = _mapper.Map<Category>(entity);
            await _categoryRepository.Add(newCategory);
        }

        public async Task Delete(Guid id)
        {
            var category = await _categoryRepository.GetById(id);
            await _categoryRepository.Delete(category);
        }

        public async Task<List<CategoryModel>> GetAll()
        {
            var categories = await _categoryRepository.GetAll();
            List<CategoryModel> categoryModels = _mapper.Map<List<Category>, List<CategoryModel>>(categories);
            return categoryModels;
        }

        public async Task<CategoryModel> GetById(Guid id)
        {
            var category = await _categoryRepository.GetById(id);
            return _mapper.Map<CategoryModel>(category);
        }

        public async Task Update(CategoryModel entity)
        {
            await _categoryRepository.Update(_mapper.Map<Category>(entity));
        }
    }
}
