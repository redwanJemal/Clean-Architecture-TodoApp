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
    public class CategoryService: BaseService, ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;


        public CategoryService(IUnitOfWork uow, IMapper mapper)
        {
            _repo = uow.CategoryRepository;
            _mapper = mapper;
            this.UoW = uow;
        }
        public CategoryModel Add(CategoryModel entity)
        {
            try
            {
                _repo.Add(_mapper.Map<Category>(entity));

                UoW.Commit();
                return entity;
            }
            catch (Exception)
            {
                UoW.RollBack();
                return null;
            }
        }

        public CategoryModel Update(CategoryModel entity)
        {
            if (entity != null)
            {
                try
                {
                    Category category = _mapper.Map<Category>(entity);
                    _repo.Update(category);

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
        public CategoryModel Delete(Guid id)
        {
            try
            {
                Category category = _mapper.Map<Category>(GetById(id));
                if (category != null)
                {
                    _repo.Delete(category);

                    this.UoW.Commit();
                    return _mapper.Map<CategoryModel>(category);
                }
            }
            catch (Exception)
            {
                this.UoW.RollBack();
                return null;
            }

            return null;
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

    }
}
