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

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                return new ErrorResult("Kitap Bulunamadı");
            }
            await _bookRepository.DeletableAsync(book);
            await _bookRepository.SaveChangeAsync();
            return new SuccessResult("Kitap Silme İşlemi Başarılı");
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

        public async Task<IDataResult<BookDetailDTo>> GetByIdAsync(Guid id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                return new ErrorDataResult<BookDetailDTo>("Kitap Bulunamadı");
            }
            return new SuccessDataResult<BookDetailDTo>(_mapper.Map<BookDetailDTo>(book), "Kitap Detayları Gösteriliyor");
        }

        public async Task<IDataResult<BookDTo>> UpdateAsync(BookUpdateDTo bookUpdateDTo)
        {
            var book = await _bookRepository.GetByIdAsync(bookUpdateDTo.Id);
            if (book == null)
            {
                return new ErrorDataResult<BookDTo>("Kitap bulunamadı.");
            }
            var books = await _bookRepository.GetAllAsync();

            var newBooks = books.ToList();
            newBooks.Remove(book);

            var hasBook = newBooks.Any(x=>x.Name == bookUpdateDTo.Name);

            if (hasBook)
            {
                return new ErrorDataResult<BookDTo>("Kitap Zaten Kayıtlı");
            }

            var updatedBook = _mapper.Map(bookUpdateDTo, book);
            await _bookRepository.UpdateAsync(updatedBook);
            await _bookRepository.SaveChangeAsync();

            return new SuccessDataResult<BookDTo>(_mapper.Map<BookDTo>(updatedBook), "Kitap Güncelleme Başarılı");
        }

    }
}
