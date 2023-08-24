using MVC_ONION_PROJECT.APPLICATION.DTo_s.AdminDTO_s;
using MVC_ONION_PROJECT.DOMAIN.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ONION_PROJECT.APPLICATION.Services.AdminService
{
    public interface IAdminService
    {
        Task<IDataResult<List<AdminListDTo>>> GetAllAsync();
        Task<IDataResult<AdminDTo>> AddAsync(AdminCreateDTo adminCreateDTo);
    }
}
