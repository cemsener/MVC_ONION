using AutoMapper;
using MVC_ONION_PROJECT.APPLICATION.DTo_s.Categories;
using MVC_ONION_PROJECT.DOMAIN.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ONION_PROJECT.APPLICATION.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryListDTo>();
            CreateMap<Category, CategoryDTo>();
            CreateMap<CategoryCreateDTo, Category>();
            CreateMap<CategoryUpdateDTo, Category>();
        }
    }
}
