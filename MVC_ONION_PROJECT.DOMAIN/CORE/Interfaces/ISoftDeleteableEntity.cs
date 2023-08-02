using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ONION_PROJECT.DOMAIN.CORE.Interfaces
{
    public interface ISoftDeleteableEntity:IEntity, ICreatableEntity, IUpdateableEntity
    {
        string? DeletedBy { get; set; }
        DateTime? DeletedDate { get; set; }

    }
}

