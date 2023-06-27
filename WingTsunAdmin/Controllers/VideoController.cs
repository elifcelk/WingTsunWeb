﻿using Application.Admin.DTOs.Video;
using Application.Admin.Features.VideoFeatures.Commands;
using Application.Admin.Features.VideoFeatures.Queries;
using Application.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using WingTsunAdmin.Infrastructure;

namespace WingTsunAdmin.Controllers
{
    public class VideoController : BaseController
    {
        [HttpGet("video/list")]
        public async Task<IActionResult> Index()
        {
            var model = await Mediator.Send(new GetAllVideosQuery());
            return View(model);
        }

        [HttpGet("video/create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(VideoDTO model)
        {
            var response = await Mediator.Send(new AddVideoCommand(model.VideoUrl));
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> ChangeStatus(ChangeModel model)
        {
            var response = await Mediator.Send(new ChangeVideoStatusCommand(model));
            return Ok(response);

        }
    }
}
