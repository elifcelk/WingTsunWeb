using Application.Admin.DTOs.About;
using Application.Admin.DTOs.Announcement;
using Application.Admin.DTOs.Contact;
using Application.Admin.Features.AboutFeatures.Commands;
using Application.Admin.Features.AboutFeatures.Queries;
using Application.Admin.Features.AnnouncementFeatures.Commands;
using Application.Admin.Features.AnnouncementFeatures.Queries;
using Application.Admin.Features.ContactFeatures.Commands;
using Application.Admin.Features.ContactFeatures.Queries;
using Application.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WingTsunAdmin.Infrastructure;

namespace WingTsunAdmin.Controllers
{
    public class AboutController : BaseController
    {
        private readonly IConfiguration configuration;
        public AboutController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpGet("about/list")]
        public async Task<IActionResult> Index()
        {
            var model = await Mediator.Send(new GetAllAboutForAdminQuery());
            return View(model);
        }

        [HttpGet("about/create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(AboutDTO model)
        {
            var response = await Mediator.Send(new AddAboutCommand(model));
            return Ok(response);

        }

        [HttpPost]
        public async Task<ActionResult> Delete(ChangeModel model)
        {
            var response = await Mediator.Send(new DeleteAboutCommand(model));
            return Ok(response);

        }

        public async Task<ActionResult> Detail(Guid id)
        {
            var model = await Mediator.Send(new GetAboutDetailForAdminQuery(id));
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Update(AboutDTO model)
        {
            var response = await Mediator.Send(new UpdateAboutCommand(model));
            return Ok(response);

        }
    }
}
