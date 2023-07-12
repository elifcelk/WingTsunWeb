using Application.Admin.Features.AdminFeatures.Queries;
using Application.Admin.Models.Admin;
using Application.Wrappers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCaching;
using System.Security.Claims;
using WingTsunAdmin.Infrastructure;

namespace WingTsunAdmin.Controllers
{
    public class AdminController : BaseController
    {
        public IActionResult Login(string returnUrl = null)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            TempData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        //public async Task<IActionResult> SignIn([FromBody] AdminUserLoginQuery adminUserLoginQuery)
        //{
        //    var response = await Mediator.Send<Response<LoginModel>>(adminUserLoginQuery);
        //    if (response.Succeeded)
        //    {
        //        await HttpContext.Session.LoadAsync();
        //        if (response.Message != null)
        //        {
        //            response.Succeeded = false;
        //            response.Message = $"Lütfen tekrar deneyin.";
        //        }
        //        else
        //        {
        //            HttpContext.Session.Set("currentUser", response.Data);
        //            var claims = new List<Claim>
        //            {
        //                new Claim(ClaimTypes.Name, response.Data.UserName),

        //            };
        //            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //            var authProperties = new AuthenticationProperties
        //            {
        //                AllowRefresh = true,
        //            };
        //            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
        //            await HttpContext.Session.CommitAsync();
        //        }

        //        await HttpContext.Session.CommitAsync();
        //    }
        //    return Ok(response);
        //}

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            await HttpContext.Session.CommitAsync();
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            return RedirectToAction("Login", "Admin");
        }
    }
}
