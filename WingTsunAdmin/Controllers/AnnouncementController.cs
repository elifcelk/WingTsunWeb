﻿using Microsoft.AspNetCore.Mvc;

namespace WingTsunAdmin.Controllers
{
    public class AnnouncementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
