﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ONION_PROJECT.APPLICATION.DTo_s.Books
{
    public class BookDetailDTo
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
    }
}
