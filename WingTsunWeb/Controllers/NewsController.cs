using Application.Features.NewsFeatures.Queries;
using Application.Features.SchoolsFeatures.Queries;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using WingTsunWeb.Infrastructure;

namespace WingTsunWeb.Controllers;

public class NewsController : BaseController
{
    [HttpGet("/duyurular")]
    public async Task<IActionResult> Index()
    {
        List<AnnouncementModel> model = await Mediator.Send(new GetAllAnnouncementsQuery());

        return View(model);
    }

    [HttpGet("/duyurular/detay/{announcementId}")]
    public async Task<IActionResult> Detail(Guid announcementId)
    {
        AnnouncementDetailModel model = await Mediator.Send(new GetAnnouncementDetailQuery(announcementId));
        return View(model);
    }
}
