using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace MVC_ONION_PROJECT.PRESENTATION.Controllers
{
    public class BaseController : Controller
    {
        public INotyfService _notyfService => HttpContext.RequestServices.GetService(typeof (INotyfService)) as INotyfService;

        protected void SuccessNoty(string message)
        {
            _notyfService.Success(message);
        }

        protected void ErrorNoty(string message)
        {
            _notyfService.Error(message);
        }

    }
}
