using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVC_Onian_project.Presentation2.Areas.Admin.Models.AdminVMs;
using MVC_ONION_PROJECT.APPLICATION.DTo_s.AdminDTO_s;
using MVC_ONION_PROJECT.APPLICATION.Services.AdminService;

namespace MVC_Onian_project.Presentation2.Areas.Admin.Controllers
{
    public class AdminController : AdminBaseController
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;

        public AdminController(IAdminService adminService, IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _adminService.GetAllAsync();
            var adminList = _mapper.Map<IEnumerable<AdminAdminListVM>>(result.Data);
            return View(adminList);
        }

        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminAdminCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var adminDto = _mapper.Map<AdminCreateDTo>(model);
            var addAdminResult = await _adminService.AddAsync(adminDto);
            if (addAdminResult.IsSuccess)
            {
                Console.WriteLine($"{model.FirstName} {model.LastName} admin olarak eklendi");
                return RedirectToAction(nameof(Index));

            }
            Console.WriteLine("Admin Eklemede Hata Oluştu" + addAdminResult.Message);
            return View(model);
        }
    }
}
