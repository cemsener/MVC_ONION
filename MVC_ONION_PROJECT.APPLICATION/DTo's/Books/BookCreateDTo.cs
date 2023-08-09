using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ONION_PROJECT.APPLICATION.DTo_s.Books
{
    public class BookCreateDTo
    {
        public string Name { get; set; }
        public DateTime PublicationDate { get; set; }
        public Guid AuthorId { get; set; }
    }
}
