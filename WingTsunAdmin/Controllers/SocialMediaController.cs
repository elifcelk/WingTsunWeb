using Application.Admin.DTOs.Contact;
using Application.Admin.DTOs.SocialMedia;
using Application.Admin.Features.ContactFeatures.Commands;
using Application.Admin.Features.ContactFeatures.Queries;
using Application.Admin.Features.SocialMediaFeatures.Commands;
using Application.Admin.Features.SocialMediaFeatures.Queries;
using Application.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using WingTsunAdmin.Infrastructure;

namespace WingTsunAdmin.Controllers
{
    public class SocialMediaController : BaseController
    {
        private readonly IConfiguration configuration;
        public SocialMediaController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpGet("socialmedia/list")]
        public async Task<IActionResult> Index()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Admin");
            }
            var model = await Mediator.Send(new GetAllSocialMediaForAdminQuery());
            return View(model);
        }

        [HttpGet("socialmedia/create")]
        public ActionResult Create()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(SocialMediaDTO model)
        {
            var response = await Mediator.Send(new AddSocialMediaCommand(model));
            return Ok(response);

        }

        [HttpPost]
        public async Task<ActionResult> Delete(ChangeModel model)
        {
            var response = await Mediator.Send(new DeleteSocialMediaCommand(model));
            return Ok(response);

        }
    }
}
