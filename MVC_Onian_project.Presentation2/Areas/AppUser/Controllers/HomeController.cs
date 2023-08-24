using Microsoft.AspNetCore.Mvc;

namespace MVC_Onian_project.Presentation2.Areas.AppUser.Controllers
{
    

    public class HomeController : AppUserBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
