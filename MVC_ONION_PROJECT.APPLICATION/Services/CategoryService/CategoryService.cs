using MVC_ONION_PROJECT.APPLICATION.DTo_s.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_ONION_PROJECT.INFRASTRUCTURE.Repositories.Interfaces;
using AutoMapper;
using MVC_ONION_PROJECT.DOMAIN.Utilities.Results;
using MVC_ONION_PROJECT.DOMAIN.Utilities.Results.Concretes;
using MVC_ONION_PROJECT.DOMAIN.ENTITIES;

namespace MVC_ONION_PROJECT.APPLICATION.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<CategoryDTo>> AddAsync(CategoryCreateDTo categoryCreateDTo)
        {
            var hasCategory = await _categoryRepository.AnyAsync(x=>x.Name.ToLower().Equals(categoryCreateDTo.Name.ToLower()));
            if (hasCategory)
            {
                return new ErrorDataResult<CategoryDTo>("Kategori zaten kayıtlı.");
            }

            var category = _mapper.Map<Category>(categoryCreateDTo);
            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveChangeAsync();
        
            return new SuccessDataResult<CategoryDTo>(_mapper.Map<CategoryDTo>(category), "Kategori Eklendi.");
        }

        public async Task<IDataResult<List<CategoryListDTo>>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            if (categories.Count() <= 0)
            {
                return new ErrorDataResult<List<CategoryListDTo>>("Sistemde Category Bulunmuyor.");
            }

            return new SuccessDataResult<List<CategoryListDTo>>(_mapper.Map<List<CategoryListDTo>>(categories), "Category Listeleme Başarılı");
        }
            
    }
}
