using Application.Features.SchoolsFeatures.Queries;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WingTsunWeb.Infrastructure;

namespace WingTsunWeb.Controllers;

public class SchoolsController : BaseController
{
    [HttpGet("/okullarimiz")]
    public async Task<IActionResult> Index()
    {
        List<SchoolModel> model = await Mediator.Send(new GetAllSchoolsQuery());

        return View(model);
    }

    [HttpGet("/okullarimiz/detay/{schoolId}")]
    public async Task<IActionResult> Detail(Guid schoolId)
    {
        SchoolDetailModel model = await Mediator.Send(new GetSchoolDetailQuery(schoolId));
        return View(model);
    }
}
