using Application.Features.GalleryFeatures.Queries;
using Application.Features.SchoolsFeatures.Queries;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WingTsunWeb.Infrastructure;

namespace WingTsunWeb.Controllers
{
    public class GalleryController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            List<GalleryModel> model = await Mediator.Send(new GetGalleryQuery());

            return View(model);
        }
    }
}
