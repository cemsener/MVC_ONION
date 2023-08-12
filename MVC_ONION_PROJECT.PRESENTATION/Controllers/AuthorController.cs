using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_ONION_PROJECT.APPLICATION.DTo_s.Authors;
using MVC_ONION_PROJECT.APPLICATION.Services.AuthorService;
using MVC_ONION_PROJECT.PRESENTATION.Models.AuthorVMs;
using MVC_ONION_PROJECT.PRESENTATION.Models.BookVMs;

namespace MVC_ONION_PROJECT.PRESENTATION.Controllers
{
    public class AuthorController : BaseController
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyfService;

        public AuthorController(IAuthorService authorService, IMapper mapper, INotyfService notyf)
        {
            _authorService = authorService;
            _mapper = mapper;
            _notyfService = notyf;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _authorService.GetAllAsync();
            var authorList = _mapper.Map<List<AuthorListVM>>(result.Data);
            SuccessNoty("Merhabalar");
            return View(authorList);
        }

        
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _authorService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<AuthorDetailVM>(result.Data));
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


        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _authorService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                Console.WriteLine(result.Message);
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<AuthorUpdateVM>(result.Data));
        }

        
        [HttpPost]
        public async Task<IActionResult> Update(AuthorUpdateVM authorUpdateVM)
        {
            if (!ModelState.IsValid)
            {
                return View(authorUpdateVM);
            }

            var result = await _authorService.UpdateAsync(_mapper.Map<AuthorUpdateDto>(authorUpdateVM));

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
