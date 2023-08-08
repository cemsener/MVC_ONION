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

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return new ErrorResult("Kategori Bulunamadı");
            }
            await _categoryRepository.DeletableAsync(category);
            await _categoryRepository.SaveChangeAsync();
            return new SuccessResult("Kategori Silme İşlemi Başarılı");
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

        public async Task<IDataResult<CategoryDTo>> GetByIdAsync(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return new ErrorDataResult<CategoryDTo>("Kategori Bulunamadı");
            }

            return new SuccessDataResult<CategoryDTo>(_mapper.Map<CategoryDTo>(category), "Kategori Detayı Gösteriliyor");
        }

        public async Task<IDataResult<CategoryDTo>> UpdateAsync(CategoryUpdateDTo categoryUpdateDTo)
        {


            var category = await _categoryRepository.GetByIdAsync(categoryUpdateDTo.Id);
            if (category == null)
            {
                return new ErrorDataResult<CategoryDTo>("Kategroi Bulunamadı");
            }

            var categories = await _categoryRepository.GetAllAsync();

            var newCategories = categories.ToList();
            newCategories.Remove(category);

            var hasCategory = newCategories.Any(x=>x.Name == categoryUpdateDTo.Name);

            if (hasCategory)
            {
                return new ErrorDataResult<CategoryDTo>("Kategroi zaten kayıtlı");
            }


            var hasCaregory = await _categoryRepository.AnyAsync(x=>x.Name.ToLower().Equals(categoryUpdateDTo.Name.ToLower()));


            var updatedCategory =  _mapper.Map(categoryUpdateDTo, category);
            await _categoryRepository.UpdateAsync(updatedCategory);
            await _categoryRepository.SaveChangeAsync();

            return new SuccessDataResult<CategoryDTo>(_mapper.Map<CategoryDTo>(updatedCategory), "Kategori Güncelleme Başarılı");
        }
    }
}
