using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC_ONION_PROJECT.DOMAIN.CORE.BASE;
using MVC_ONION_PROJECT.DOMAIN.ENUMS;
using MVC_ONION_PROJECT.INFRASTRUCTURE.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ONION_PROJECT.APPLICATION.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IAdminRepository _adminRepository;

        public AccountService(UserManager<IdentityUser> userManager, IAdminRepository adminRepository)
        {
            _userManager = userManager;
            _adminRepository = adminRepository;
        }

        public async Task<bool> AnyAsync(Expression<Func<IdentityUser, bool>> expression)
        {
            return await _userManager.Users.AnyAsync(expression);
        }

        public async Task<IdentityResult> CreateUserAsync(IdentityUser user, Roles role)
        {
            var result = await _userManager.CreateAsync(user, "Password.1");
            if (!result.Succeeded)
            {
                return result;
            }

            return await _userManager.AddToRoleAsync(user, role.ToString());
        }

        public async Task<IdentityResult> DeleteUserAsync(string identityId)
        {
            var user = await _userManager.FindByIdAsync(identityId);
            if (user is null)
            {
                return IdentityResult.Failed(new IdentityError()
                {
                    Code = "Kullanıcı Bulunamadı",
                    Description = "Kullanıcı Bulunamadı"
                });
            }
            return await _userManager.DeleteAsync(user);
        }

        public async Task<IdentityUser?> FindByIdAsync(string identityId)
        {
            return await _userManager.FindByIdAsync(identityId);
        }

        public async Task<Guid> GetUserIdAsync(string identityId, string role)
        {
            BaseUser? user = role switch //farklı bir switch case yapısı
            {
                "Admin" => await _adminRepository.GetByIdentityId(identityId),
                //"AppUser" => await 
                _ => null
            };
            return user is null ? Guid.NewGuid() : user.Id;
        }

       
    }
}
