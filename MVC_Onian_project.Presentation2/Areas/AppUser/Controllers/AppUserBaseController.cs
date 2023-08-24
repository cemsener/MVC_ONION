using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Onian_project.Presentation2.Areas.AppUser.Controllers
{
    [Area("AppUser")]
    [Authorize(Roles = "AdppUser")]
    public class AppUserBaseController : Controller
    {
        
    }
}
