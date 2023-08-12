using AutoMapper;
using MVC_ONION_PROJECT.APPLICATION.DTo_s.Authors;
using MVC_ONION_PROJECT.APPLICATION.DTo_s.Books;
using MVC_ONION_PROJECT.APPLICATION.DTo_s.Categories;
using MVC_ONION_PROJECT.PRESENTATION.Models.AuthorVMs;
using MVC_ONION_PROJECT.PRESENTATION.Models.BookVMs;
using MVC_ONION_PROJECT.PRESENTATION.Models.CategoryVMs;
using System.Drawing;

namespace MVC_ONION_PROJECT.PRESENTATION.Profiles
{
    public class Profile : AutoMapper.Profile
    {
        public Profile()
        {
            #region Category Profiles
            CreateMap<CategoryListDTo, CategoryListVM>();
            CreateMap<CategoryCreateVM, CategoryCreateDTo>();
            CreateMap<CategoryDTo, CategoryDetailVM>();
            CreateMap<CategoryDTo, CategoryUpdateVM>();
            CreateMap<CategoryUpdateVM, CategoryUpdateDTo>();
            #endregion

            #region Author Profiles
            CreateMap<AuthorCreateVM, AuthorCreateDTo>();
            CreateMap<AuthorListDTo, AuthorListVM>().ForMember(dest=>dest.FullName, config=>config.MapFrom(x=>x.Name + " " + x.Surname));
            CreateMap<AuthorDTo, AuthorDetailVM>();
            CreateMap<AuthorDTo, AuthorUpdateVM>();
            CreateMap<AuthorUpdateVM, AuthorUpdateDto>();
            #endregion

            #region Book Profiles
            CreateMap<BookCreateVM, BookCreateDTo>();
            CreateMap<BookListDTo, BookListVM>();
            CreateMap<BookDTo, BookDetailVM>();
            CreateMap<BookDTo, BookUpdateVM>();
            CreateMap<BookUpdateVM, BookUpdateDTo>();
            CreateMap<BookDTo, BookDetailDTo>();
            CreateMap<BookDetailDTo, BookDetailVM>();
            CreateMap<BookDetailDTo, BookUpdateVM>();
            #endregion

            
        }
    }
}
