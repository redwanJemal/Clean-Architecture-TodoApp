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
    public class SubCategoryService : IGenericService<SubCategoryModel>
    {
        private readonly IGenericRepository<SubCategory> _repo;
        private readonly IMapper _mapper;


        public SubCategoryService(IGenericRepository<SubCategory> repo, IMapper mapper)
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

        public async Task<List<SubCategoryModel>> GetAll()
        {
            var subCategories = await _repo.GetAll();
            List<SubCategoryModel> subCategoryModels = _mapper.Map<List<SubCategory>, List<SubCategoryModel>>(subCategories);
            return subCategoryModels;
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
