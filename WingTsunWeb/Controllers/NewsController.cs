using Microsoft.AspNetCore.Mvc;

namespace WingTsunWeb.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
