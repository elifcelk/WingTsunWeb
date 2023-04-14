using Microsoft.AspNetCore.Mvc;

namespace WingTsunAdmin.Controllers
{
    public class SchoolController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
