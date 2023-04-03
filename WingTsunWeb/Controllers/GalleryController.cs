using Microsoft.AspNetCore.Mvc;

namespace WingTsunWeb.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
