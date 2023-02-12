using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<School> Schools { get; set; }

        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
