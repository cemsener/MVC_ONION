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

       
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: CategoryController/Create
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

        
        public ActionResult Update(int id)
        {
            return View();
        }

        
        [HttpPost]
        
        public ActionResult Update(int id, IFormCollection collection)
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

        
        public ActionResult Delete(int id)
        {
            return View();
        }

        
        [HttpPost]
        
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
