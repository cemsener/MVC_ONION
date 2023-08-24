using AutoMapper;
using MVC_Onian_project.Presentation2.Areas.Admin.Models.AdminVMs;
using MVC_ONION_PROJECT.APPLICATION.DTo_s.AdminDTO_s;

namespace MVC_Onian_project.Presentation2.Profiles
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<AdminListDTo, AdminAdminListVM>();
            CreateMap<AdminAdminCreateVM, AdminCreateDTo>();
        }
    }
}
