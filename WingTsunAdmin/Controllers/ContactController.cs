using Application.Admin.DTOs.Announcement;
using Application.Admin.DTOs.Contact;
using Application.Admin.Features.AnnouncementFeatures.Commands;
using Application.Admin.Features.AnnouncementFeatures.Queries;
using Application.Admin.Features.ContactFeatures.Commands;
using Application.Admin.Features.ContactFeatures.Queries;
using Application.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using WingTsunAdmin.Infrastructure;

namespace WingTsunAdmin.Controllers
{
    public class ContactController : BaseController
    {
        private readonly IConfiguration configuration;
        public ContactController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpGet("contact/list")]
        public async Task<IActionResult> Index()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Admin");
            }
            var model = await Mediator.Send(new GetAllContactForAdminQuery());
            return View(model);
        }

        [HttpGet("contact/create")]
        public ActionResult Create()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ContactDTO model)
        {
            var response = await Mediator.Send(new AddContactCommand(model));
            return Ok(response);

        }

        [HttpPost]
        public async Task<ActionResult> Delete(ChangeModel model)
        {
            var response = await Mediator.Send(new DeleteContactCommand(model));
            return Ok(response);

        }
    }
}
