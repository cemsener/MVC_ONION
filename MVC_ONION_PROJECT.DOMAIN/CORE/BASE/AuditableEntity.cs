using MVC_ONION_PROJECT.DOMAIN.CORE.Interfaces;
using MVC_ONION_PROJECT.DOMAIN.ENUMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ONION_PROJECT.DOMAIN.CORE.BASE
{
    public class AuditableEntity : ISoftDeleteableEntity
    {
        public string? DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid Id { get; set; }
        public Status Status { get; set; }
    }
}
