using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ONION_PROJECT.APPLICATION.DTo_s.Authors
{
    public class AuthorDTo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateofBirth { get; set; }
    }
}
