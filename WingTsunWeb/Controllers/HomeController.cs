﻿using Microsoft.AspNetCore.Mvc;

namespace WingTsunWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}