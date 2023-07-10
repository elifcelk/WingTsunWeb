using Application.Admin.DTOs.Announcement;
using Application.Admin.DTOs.School;
using Application.Admin.Features.AnnouncementFeatures.Commands;
using Application.Admin.Features.AnnouncementFeatures.Queries;
using Application.Admin.Features.SchoolFeatures.Commands;
using Application.Admin.Models;
using Application.Features.NewsFeatures.Queries;
using Microsoft.AspNetCore.Mvc;
using WingTsunAdmin.Infrastructure;

namespace WingTsunAdmin.Controllers
{
    public class AnnouncementController : BaseController
    {
        private readonly IConfiguration configuration;
        public AnnouncementController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpGet("announcement/list")]
        public async Task<IActionResult> Index()
        {
            var model = await Mediator.Send(new GetAllAnnouncementsForAdminQuery());
            ViewBag.WebUrl = configuration.GetSection("Urls:WEB_URL").Value;
            return View(model);
        }

        [HttpGet("announcement/create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(AnnouncementDTO model)
        {
            var files = HttpContext.Request.Form.Files;

            if (files != null && files.Count > 0)
            {
                var file = HttpContext.Request.Form.Files[0];
                var configPath = configuration.GetSection("Urls:ADMIN_PATH").Value;
                var path = Path.Combine(configPath, "wwwroot\\images\\announcement", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                model.MainImage = "images/announcement/" + file.FileName;
            }

            var response = await Mediator.Send(new AddAnnouncementCommand(model));
            return Ok(response);

        }

        [HttpPost]
        public async Task<ActionResult> Delete(ChangeModel model)
        {
            var response = await Mediator.Send(new DeleteAnnouncementCommand(model));
            return Ok(response);

        }
        public async Task<ActionResult> Detail(Guid id)
        {
            var model = await Mediator.Send(new GetAnnouncementDetailForAdminQuery(id));
            ViewBag.WebUrl = configuration.GetSection("Urls:WEB_URL").Value;
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Update(AnnouncementDTO model)
        {
            var files = HttpContext.Request.Form.Files;

            if (files != null && files.Count > 0)
            {
                var file = HttpContext.Request.Form.Files[0];
                var configPath = configuration.GetSection("Urls:ADMIN_PATH").Value;
                var path = Path.Combine(configPath, "wwwroot\\images\\announcement", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                model.MainImage = "images/announcement/" + file.FileName;
            }

            var response = await Mediator.Send(new UpdateAnnouncementCommand(model));
            return Ok(response);

        }
    }
}
