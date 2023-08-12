using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_ONION_PROJECT.APPLICATION.DTo_s.Books;
using MVC_ONION_PROJECT.APPLICATION.Services.AuthorService;
using MVC_ONION_PROJECT.APPLICATION.Services.BookService;
using MVC_ONION_PROJECT.PRESENTATION.Models.BookVMs;

namespace MVC_ONION_PROJECT.PRESENTATION.Controllers
{
    public class BookController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;

        public BookController(IMapper mapper, IAuthorService authorService, IBookService bookService)
        {
            _mapper = mapper;
            _authorService = authorService;
            _bookService = bookService;
        }


        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllAsync();

            if (!books.IsSuccess)
            {
                return View(_mapper.Map<List<BookListVM>>(books.Data));
            }

            return View(_mapper.Map<List<BookListVM>>(books.Data));
        }

              
        public async Task<IActionResult> Details(Guid id)
        {
            
            var result = await _bookService.GetByIdAsync(id);
            //var resultDTo = _mapper.Map<BookDetailDTo>(result.Data);
            if (!result.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<BookDetailVM>(result.Data));
        }

        
        public async Task<IActionResult> Create()
        {
            BookCreateVM vm = new BookCreateVM()
            {
                AuthorList = await GetAuthorsAsync()
            };
            return View(vm);
        }

       
        [HttpPost]
        
        public async Task<IActionResult> Create(BookCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var addResult = await _bookService.AddAsync(_mapper.Map<BookCreateDTo>(model));
            
            if (!addResult.IsSuccess)
            {
                Console.WriteLine(addResult.Message);
                return View(model);
            }

            Console.WriteLine(addResult.Message);
            return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> Update(Guid id)
        {
            BookUpdateVM vm = new BookUpdateVM()
            {
                AuthorList = await GetAuthorsAsync()
            };
            var result = await _bookService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                Console.WriteLine(result.Message);
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map(result.Data,vm));
        }

        
        [HttpPost]
        
        public async Task<IActionResult> Update(BookUpdateVM bookUpdateVM)
        {
            if (!ModelState.IsValid)
            {
                return View(bookUpdateVM);
            }

            var result = await _bookService.UpdateAsync(_mapper.Map<BookUpdateDTo>(bookUpdateVM));

            if (!result.IsSuccess)
            {
                Console.WriteLine(result.Message);
                return RedirectToAction(nameof(Index));
            }

            Console.WriteLine(result.Message);
            return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _bookService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                Console.WriteLine(result.Message);
                return RedirectToAction(nameof(Index));
            }
            Console.WriteLine(result.Message);
            return RedirectToAction(nameof(Index));
        }

        private async Task<SelectList> GetAuthorsAsync()
        {
            var authors = await _authorService.GetAllAsync();
            return new SelectList(authors.Data.Select(x=> new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name + " " + x.Surname
            }), "Value", "Text");
        }

        
    }
}
