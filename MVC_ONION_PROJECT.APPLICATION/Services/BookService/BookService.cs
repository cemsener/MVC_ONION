using AutoMapper;
using MVC_ONION_PROJECT.APPLICATION.DTo_s.Books;
using MVC_ONION_PROJECT.DOMAIN.ENTITIES;
using MVC_ONION_PROJECT.DOMAIN.Utilities.Results;
using MVC_ONION_PROJECT.DOMAIN.Utilities.Results.Concretes;
using MVC_ONION_PROJECT.INFRASTRUCTURE.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ONION_PROJECT.APPLICATION.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<BookDTo>> AddAsync(BookCreateDTo bookCreateDTo)
        {
            var book = _mapper.Map<Book>(bookCreateDTo);
            await _bookRepository.AddAsync(book);
            await _bookRepository.SaveChangeAsync();

            return new SuccessDataResult<BookDTo>(_mapper.Map<BookDTo>(book), "Kİtap Ekleme Başarılı");
        }

        public async Task<IDataResult<List<BookListDTo>>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();

            if (books.Count() <= 0)
            {
                return new ErrorDataResult<List<BookListDTo>>("Sistemde kitap bulunamadı.");
            }

            return new SuccessDataResult<List<BookListDTo>>(_mapper.Map<List<BookListDTo>>(books), "Kitap Listeleme Başarılı");

        }
    }
}
