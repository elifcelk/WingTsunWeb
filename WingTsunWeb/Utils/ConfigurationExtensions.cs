using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using WingTsunWeb.Infrastructure;

namespace WingTsunWeb.Utils
{
    public static class ConfigurationExtensions
    {
        public static IApplicationBuilder UseCustomConfiguration(this IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();
            }
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
