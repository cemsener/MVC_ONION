using Microsoft.AspNetCore.Mvc;

namespace MVC_Onian_project.Presentation2.Areas.Admin.Controllers
{
    

    public class HomeController : AdminBaseController
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
