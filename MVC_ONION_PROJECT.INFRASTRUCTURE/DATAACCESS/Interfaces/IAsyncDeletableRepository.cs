using MVC_ONION_PROJECT.DOMAIN.CORE.BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ONION_PROJECT.INFRASTRUCTURE.DATAACCESS.Interfaces
{
    public interface IAsyncDeletableRepository<TEntity> : IAsyncRepository where TEntity : BaseEntity
    {
        Task DeletableAsync(TEntity entity);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);
            
    }
}
