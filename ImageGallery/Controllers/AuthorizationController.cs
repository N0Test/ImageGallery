using Microsoft.AspNetCore.Mvc;

namespace ImageGallery.Controllers
{
    public class AuthorizationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
