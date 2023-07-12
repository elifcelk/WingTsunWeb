using Application.Features.HomeFeatures.Queries;
using Application.Features.NewsFeatures.Queries;
using Application.Features.SchoolsFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WingTsunWeb.Infrastructure;

namespace WingTsunWeb.Controllers
{
    public class HomeController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            ViewBag.GetSliders =  await Mediator.Send(new GetSlidersQuery());
            ViewBag.GetSchools = await Mediator.Send(new GetSchoolForHomeQuery());
            ViewBag.GetAnnouncements = await Mediator.Send(new GetAllAnnouncementsQuery());
            ViewBag.GetVideos = await Mediator.Send(new GetVideosQuery());
            return View();
        }
        public async Task<IActionResult> Contact()
        {
            var model = await Mediator.Send(new GetAllContactQuery());
            return View(model);
        }
        public async Task<IActionResult> About()
        {
            var model = await Mediator.Send(new GetAllAboutQuery());
            return View(model);
        }
    }
}
