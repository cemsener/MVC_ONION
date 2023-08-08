using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVC_ONION_PROJECT.APPLICATION.DTo_s.Authors;
using MVC_ONION_PROJECT.APPLICATION.Services.AuthorService;
using MVC_ONION_PROJECT.PRESENTATION.Models.AuthorVMs;

namespace MVC_ONION_PROJECT.PRESENTATION.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }   

        public async Task<IActionResult> Index()
        {
            var result = await _authorService.GetAllAsync();
            var authorList = _mapper.Map<List<AuthorListVM>>(result.Data);
            return View(authorList);
        }


        public async Task<IActionResult> Create()
        {
            AuthorCreateVM authorCreateVM = new AuthorCreateVM()
            {
                DateofBirth = DateTime.Now,
            };
            return View(authorCreateVM);
        }

        [HttpPost]

        public async Task<IActionResult> Create(AuthorCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var addResult = await _authorService.AddAsync(_mapper.Map<AuthorCreateDTo>(model));

            if (!addResult.IsSuccess)
            {
                Console.WriteLine(addResult.Message);
                return View(model);
            }

            Console.WriteLine(addResult);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _authorService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                Console.WriteLine(result.Message);
                return RedirectToAction(nameof(Index));
            }

            Console.WriteLine(result.Message);
            return RedirectToAction(nameof(Index));
        }

    }
}
