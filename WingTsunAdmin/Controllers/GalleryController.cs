using Microsoft.AspNetCore.Mvc;

namespace WingTsunAdmin.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
