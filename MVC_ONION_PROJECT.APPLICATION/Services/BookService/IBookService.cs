using MVC_ONION_PROJECT.APPLICATION.DTo_s.Books;
using MVC_ONION_PROJECT.DOMAIN.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ONION_PROJECT.APPLICATION.Services.BookService
{
    public interface IBookService
    {
        Task<IDataResult<BookDTo>> AddAsync(BookCreateDTo bookCreateDTo);
        Task<IDataResult<List<BookListDTo>>> GetAllAsync();
    }
}
