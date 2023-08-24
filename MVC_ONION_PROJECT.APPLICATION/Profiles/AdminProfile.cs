using AutoMapper;
using MVC_ONION_PROJECT.APPLICATION.DTo_s.AdminDTO_s;
using MVC_ONION_PROJECT.DOMAIN.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ONION_PROJECT.APPLICATION.Profiles
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<Admin, AdminListDTo>();
            CreateMap<AdminCreateDTo, Admin>();
            CreateMap<Admin, AdminDTo>();
        }
    }
}

