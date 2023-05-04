﻿using Application.Admin.DTOs.Slider;
using Application.Admin.Features.SliderFeatures.Commands;
using Application.Features.GalleryFeatures.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using WingTsunAdmin.Infrastructure;
using static System.Net.Mime.MediaTypeNames;

namespace WingTsunAdmin.Controllers
{
    public class SliderController :BaseController
    {
        private readonly IConfiguration configuration;
        public SliderController(IConfiguration configuration)
        {
            this.configuration = configuration; 
        }
        [HttpGet("slider/list")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("slider/create")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(SliderDTO model)
        {
            var files = HttpContext.Request.Form.Files;

            if (files != null && files.Count > 0)
            {
                var file = HttpContext.Request.Form.Files[0];
                var configPath = configuration.GetSection("Urls:WEB_PATH").Value;
                var path = Path.Combine(configPath, "wwwroot\\images\\slider", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                model.ImageURL = "/images/slider/" + file.FileName;
            }
            
            var response = await Mediator.Send(new AddSliderCommand(model));
            return Ok(response);

        }

        //public async static Task<Image> ResizeImage(this IFormFile file, int width, int height)
        //{
        //    using (var memoryStream = new MemoryStream())
        //    {
        //        await file.CopyToAsync(memoryStream);
        //        using (var img = Image.FromStream(memoryStream))
        //        {
        //            return img.Resize(width, height);
        //        }
        //    }
        //}
    }
}