using Microsoft.AspNetCore.Mvc;

namespace WingTsunAdmin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
