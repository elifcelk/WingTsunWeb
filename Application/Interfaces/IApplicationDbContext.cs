using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<School> Schools { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }


        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
