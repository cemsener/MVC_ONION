using MVC_ONION_PROJECT.DOMAIN.CORE.BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ONION_PROJECT.DOMAIN.ENTITIES
{
    public class Category: AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
