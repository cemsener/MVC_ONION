using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_ONION_PROJECT.APPLICATION.DTo_s.Categories;
using MVC_ONION_PROJECT.APPLICATION.Services.CategoryService;
using MVC_ONION_PROJECT.PRESENTATION.Models.CategoryVMs;

namespace MVC_ONION_PROJECT.PRESENTATION.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }


        
        public async Task<IActionResult> Index()
        {
            var result = await _categoryService.GetAllAsync();
            if (!result.IsSuccess)
            {
                return View(_mapper.Map<List<CategoryListVM>>(result.Data));
            }
            
            return View(_mapper.Map<List<CategoryListVM>>(result.Data));
        }

       
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _categoryService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<CategoryDetailVM>(result.Data));
        }

        
        public async Task<IActionResult> Create()
        {
            return View();
        }

        
        [HttpPost]
        
        public async Task<IActionResult> Create(CategoryCreateVM categoryCreateVM)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryCreateVM);
            }

            var addresult = await _categoryService.AddAsync(_mapper.Map<CategoryCreateDTo>(categoryCreateVM));
            if (!addresult.IsSuccess)
            {
                return View(categoryCreateVM);
            }

            return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _categoryService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                Console.WriteLine(result.Message);
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<CategoryUpdateVM>(result.Data));
        }

        
        [HttpPost]
        
        public async Task<IActionResult> Update(CategoryUpdateVM categoryUpdateVM)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryUpdateVM);
            }
            var result = await _categoryService.UpdateAsync(_mapper.Map<CategoryUpdateDTo>(categoryUpdateVM));

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
            var result = await _categoryService.DeleteAsync(id);
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
