﻿using Microsoft.Extensions.DependencyInjection;
using MVC_ONION_PROJECT.APPLICATION.Services.AccountService;
using MVC_ONION_PROJECT.APPLICATION.Services.AdminService;
using MVC_ONION_PROJECT.APPLICATION.Services.AuthorService;
using MVC_ONION_PROJECT.APPLICATION.Services.BookService;
using MVC_ONION_PROJECT.APPLICATION.Services.CategoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ONION_PROJECT.APPLICATION.Extension
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IAccountService, AccountService>();
            return services;
        }
    }
}
