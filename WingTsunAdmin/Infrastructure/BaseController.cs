using Application.Admin.Models.Admin;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WingTsunAdmin.Infrastructure
{
    public class BaseController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        //protected LoginModel CurrentUser => HttpContext.Session.Get<LoginModel>("currentUser");

        //public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        //{
        //    if (CurrentUser == null)
        //    {
        //        ViewBag.CurrentUser = CurrentUser;
        //    }
        //    return base.OnActionExecutionAsync(context, next);
        //}

    }
}
