using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ONION_PROJECT.DOMAIN.CORE.Interfaces
{
    public interface ICreatableEntity:IEntity
    {
        string CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }

    }
}
