using Application.Admin.DTOs.School;
using Application.Admin.DTOs.Slider;
using Application.Admin.Features.GalleryFeatures.Commands;
using Application.Admin.Features.GalleryFeatures.Queries;
using Application.Admin.Features.SchoolFeatures.Commands;
using Application.Admin.Features.SchoolFeatures.Queries;
using Application.Admin.Features.SliderFeatures.Commands;
using Application.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WingTsunAdmin.Infrastructure;

namespace WingTsunAdmin.Controllers
{
    public class SchoolController : BaseController
    {
        private readonly IConfiguration configuration;
        public SchoolController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpGet("school/list")]
        public async Task<IActionResult> Index()
        {
            var model = await Mediator.Send(new GetAllSchoolsQuery());
            ViewBag.WebUrl = configuration.GetSection("Urls:WEB_URL").Value;
            return View(model);
        }

        [HttpGet("school/create")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(SchoolDTO model)
        {
            var files = HttpContext.Request.Form.Files;

            if (files != null && files.Count > 0)
            {
                var file = HttpContext.Request.Form.Files[0];
                var configPath = configuration.GetSection("Urls:ADMIN_PATH").Value;
                var path = Path.Combine(configPath, "wwwroot\\images\\school", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                model.PhotoPath = "/images/school/" + file.FileName;
            }

            var response = await Mediator.Send(new AddSchoolCommand(model));
            return Ok(response);

        }

        [HttpPost]
        public async Task<ActionResult> Delete(ChangeModel model)
        {
            var response = await Mediator.Send(new DeleteSchoolCommand(model));
            return Ok(response);

        }
        public async Task<ActionResult> Detail(Guid id)
        {
            var model = await Mediator.Send(new GetSchoolDetailQuery(id));
            ViewBag.WebUrl = configuration.GetSection("Urls:WEB_URL").Value;
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Update(SchoolDTO model)
        {
            var files = HttpContext.Request.Form.Files;

            if (files != null && files.Count > 0)
            {
                var file = HttpContext.Request.Form.Files[0];
                var configPath = configuration.GetSection("Urls:ADMIN_PATH").Value;
                var path = Path.Combine(configPath, "wwwroot\\images\\school", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                model.PhotoPath = "/images/school/" + file.FileName;
            }

            var response = await Mediator.Send(new UpdateSchoolCommand(model));
            return Ok(response);

        }

    }
}
