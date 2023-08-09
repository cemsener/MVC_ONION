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

            return View(_mapper.Map<List<BookListVM>>(books.Data));
        }

        
        public ActionResult Details(int id)
        {
            return View();
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
            var addResult = await _bookService.AddAsync(_mapper.Map<BookCreateDTo>(model));
            
            if (!addResult.IsSuccess)
            {
                Console.WriteLine(addResult.Message);
                return View(model);
            }

            Console.WriteLine(addResult.Message);
            return RedirectToAction(nameof(Index));
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
