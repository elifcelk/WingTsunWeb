using Application;
using Application.Admin;
using Microsoft.AspNetCore.Authentication.Cookies;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplicationAdmin(builder.Configuration);


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "WingTsunAdmin.Session";
    options.Cookie.MaxAge = TimeSpan.FromHours(4);
    options.IOTimeout = TimeSpan.FromHours(4);
    options.IdleTimeout = TimeSpan.FromHours(4);
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Admin/Login";
    options.Cookie.Name = "WingTsunAdmin.Identity";
    options.Cookie.MaxAge = TimeSpan.FromHours(4);
    options.ExpireTimeSpan = TimeSpan.FromHours(4);
});

var app = builder.Build();
app.UseSession();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=Login}/{id?}");



app.Run();
