using MVC_ONION_PROJECT.DOMAIN.CORE.Interfaces;
using MVC_ONION_PROJECT.DOMAIN.ENTITIES;
using MVC_ONION_PROJECT.INFRASTRUCTURE.DATAACCESS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ONION_PROJECT.INFRASTRUCTURE.Repositories.Interfaces
{
    public interface IAdminRepository : IAsyncRepository, IAsyncFindableRepository<Admin>, IAsyncInsertableRepository<Admin>, IAsyncUpdateableRepository<Admin>, ITransactionRepository, IAsyncDeletableRepository<Admin>, IAsyncQueryableRepository<Admin>
    {
        Task<Admin?> GetByIdentityId(string identityId);
    }
}
