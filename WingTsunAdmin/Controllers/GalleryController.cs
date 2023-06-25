using Application.Admin.DTOs.Gallery;
using Application.Admin.DTOs.Slider;
using Application.Admin.Features.GalleryFeatures.Commands;
using Application.Admin.Features.GalleryFeatures.Queries;
using Application.Admin.Features.SliderFeatures.Commands;
using Application.Admin.Features.SliderFeatures.Queries;
using Application.Admin.Models.Slider;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WingTsunAdmin.Infrastructure;

namespace WingTsunAdmin.Controllers
{
    public class GalleryController : BaseController
    {
        private readonly IConfiguration configuration;
        public GalleryController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpGet("gallery/list")]
        public async Task<IActionResult> Index()
        {
            var model = await Mediator.Send(new GetAllGalleryQuery());
            ViewBag.WebUrl = configuration.GetSection("Urls:WEB_URL").Value;
            return View(model);
        }
        [HttpGet("gallery/create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(GalleryDTO model)
        {
            var files = HttpContext.Request.Form.Files;

            if (files != null && files.Count > 0)
            {
                var file = HttpContext.Request.Form.Files[0];
                var configPath = configuration.GetSection("Urls:ADMIN_PATH").Value;
                var path = Path.Combine(configPath, "wwwroot\\images\\gallery", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                model.PhotoPath = "/images/gallery/" + file.FileName;
            }
            else
            {
                return Ok(false);
            }

            var response = await Mediator.Send(new AddGalleryCommand(model.PhotoPath));
            return Ok(response);

        }

        [HttpPost]
        public async Task<ActionResult> ChangeStatus(ChangeModel model)
        {
            var response = await Mediator.Send(new ChangePhotoStatusCommand(model));
            return Ok(response);

        }
    }
}
