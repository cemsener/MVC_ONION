using MVC_ONION_PROJECT.APPLICATION.DTo_s.Categories;
using MVC_ONION_PROJECT.DOMAIN.Utilities.Results;
using MVC_ONION_PROJECT.DOMAIN.Utilities.Results.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ONION_PROJECT.APPLICATION.Services.CategoryService
{
    public interface ICategoryService
    {
        /// <summary>
        /// Kategorileri DTo olarak getirir
        /// </summary>
        /// <returns>Liste tipinde CategoryListDTo döner</returns>
        Task<IDataResult<List<CategoryListDTo>>> GetAllAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryCreateDTo"></param>
        /// <returns></returns>
        Task<IDataResult<CategoryDTo>> AddAsync(CategoryCreateDTo categoryCreateDTo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IDataResult<CategoryDTo>> GetByIdAsync(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IResult>DeleteAsync(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryUpdateDTo"></param>
        /// <returns></returns>
        Task<IDataResult<CategoryDTo>> UpdateAsync(CategoryUpdateDTo categoryUpdateDTo);
    }
}
