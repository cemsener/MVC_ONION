using AutoMapper;
using MVC_ONION_PROJECT.APPLICATION.DTo_s.Categories;
using MVC_ONION_PROJECT.PRESENTATION.Models.CategoryVMs;

namespace MVC_ONION_PROJECT.PRESENTATION.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryListDTo, CategoryListVM>();
            CreateMap<CategoryCreateVM, CategoryCreateDTo>();
            CreateMap<CategoryDTo, CategoryDetailVM>();
            CreateMap<CategoryDTo, CategoryUpdateVM>();
            CreateMap<CategoryUpdateVM, CategoryUpdateDTo>();
        }
    }
}
