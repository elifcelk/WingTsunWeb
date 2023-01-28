using Microsoft.AspNetCore.Mvc;

namespace WingTsunWeb.Controllers
{
    public class SchoolsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
