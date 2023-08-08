using AutoMapper;
using MVC_ONION_PROJECT.APPLICATION.DTo_s.Authors;
using MVC_ONION_PROJECT.APPLICATION.DTo_s.Categories;
using MVC_ONION_PROJECT.DOMAIN.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ONION_PROJECT.APPLICATION.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            #region Category Profiles
            CreateMap<Category, CategoryListDTo>();
            CreateMap<Category, CategoryDTo>();
            CreateMap<CategoryCreateDTo, Category>();
            CreateMap<CategoryUpdateDTo, Category>();
            #endregion

            #region Author Profiles
            CreateMap<AuthorCreateDTo, Author>();
            CreateMap<Author, AuthorDTo>();
            CreateMap<Author, AuthorListDTo>();
            #endregion


        }
    }
}
