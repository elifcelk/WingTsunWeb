using Microsoft.AspNetCore.Mvc;

namespace WingTsunAdmin.Controllers
{
    public class VideoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
