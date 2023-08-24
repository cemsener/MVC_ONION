using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MVC_ONION_PROJECT.APPLICATION.DTo_s.AdminDTO_s;
using MVC_ONION_PROJECT.APPLICATION.Services.AccountService;
using MVC_ONION_PROJECT.DOMAIN.ENTITIES;
using MVC_ONION_PROJECT.DOMAIN.ENUMS;
using MVC_ONION_PROJECT.DOMAIN.Utilities.Results;
using MVC_ONION_PROJECT.DOMAIN.Utilities.Results.Concretes;
using MVC_ONION_PROJECT.INFRASTRUCTURE.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVC_ONION_PROJECT.APPLICATION.Services.AdminService
{
    public class AdminService : IAdminService
    {

        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;

        public AdminService(IAdminRepository adminRepository, IMapper mapper, IAccountService accountService)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
            _accountService = accountService;
        }
        public async Task<IDataResult<List<AdminListDTo>>> GetAllAsync()
        {
            var admins = await _adminRepository.GetAllAsync();
            var adminListDTo = _mapper.Map<List<AdminListDTo>>(admins);
            return new SuccessDataResult<List<AdminListDTo>>(adminListDTo, "Admin Listeleme Başarılı");
        }

        public async Task<IDataResult<AdminDTo>> AddAsync(AdminCreateDTo adminCreateDTo)
        {
            if (await _accountService.AnyAsync(x => x.Email == adminCreateDTo.Email))
            {
                return new ErrorDataResult<AdminDTo>("Email adresi kullanılıyor");
            }

            IdentityUser identityUser = new IdentityUser()
            {
                Email = adminCreateDTo.Email,
                EmailConfirmed = true,
                UserName = adminCreateDTo.Email
            };

            DataResult<AdminDTo> result = new ErrorDataResult<AdminDTo>();

            var strategy = await _adminRepository.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async() =>
            {
                var transactionScope = await _adminRepository.BeginTransactionAsync().ConfigureAwait(false);

                try
                {
                    var identityResult = await _accountService.CreateUserAsync(identityUser, Roles.Admin);
                    if (!identityResult.Succeeded)
                    {
                        result = new ErrorDataResult<AdminDTo>(identityResult.ToString());
                        transactionScope.Rollback();
                        return;
                    }

                    var admin = _mapper.Map<Admin>(adminCreateDTo);
                    admin.IdentityId = identityUser.Id;
                    await _adminRepository.AddAsync(admin);
                    await _adminRepository.SaveChangeAsync();
                    result = new SuccessDataResult<AdminDTo>(_mapper.Map<AdminDTo>(admin), "Admin Ekleme Başarılı");
                    transactionScope.Commit();

                }
                catch (Exception ex)
                {
                    result = new ErrorDataResult<AdminDTo>($"Ekleme Başarısız - {ex.Message}");
                    transactionScope.Rollback();
                    
                }
                finally
                {
                    transactionScope.Dispose();
                }
                

            });
            return result;

        }
    }
}
