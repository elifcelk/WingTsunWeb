using Application.Extensions;
using Application.Interfaces;
using Application.Utils;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            this._encryptionProvider = new EncryptUtil();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseEncryption(this._encryptionProvider);
            modelBuilder.UseCaseSensitiveFilter();
            modelBuilder.UseSoftDeleteFilter();

            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Entity<School>(entity =>
            {
                entity.ToTable("Schools");
                entity.HasKey(e => e.Id).HasName("PK_School_Id");

                entity.Property(p => p.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()").IsRequired().ValueGeneratedOnAdd();
                entity.Property(p => p.Name).HasColumnType("character varying").HasMaxLength(100);
                entity.Property(p => p.CityName).HasColumnType("character varying").HasMaxLength(50);
                entity.Property(p => p.DistrictName).HasColumnType("character varying").HasMaxLength(50);
                entity.Property(p => p.Address).HasColumnType("character varying").HasMaxLength(500);
                entity.Property(p => p.ContactNumber).HasColumnType("character varying").HasMaxLength(20);
                entity.Property(p => p.PhotoPath).HasColumnType("character varying").HasMaxLength(500);
                entity.Property(p => p.InstructorName).HasColumnType("character varying").HasMaxLength(50);
                entity.Property(p => p.InstructorStatus).HasColumnType("character varying").HasMaxLength(30);
                entity.Property(p => p.InstructorResume).HasColumnType("character varying").HasMaxLength(500);
                entity.Property(p => p.TimeTable).HasColumnType("character varying").HasMaxLength(500);

                entity.Property(p => p.CreatedTime).HasColumnType("timestamp without time zone").HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Announcement>(entity =>
            {
                entity.ToTable("Announcements");
                entity.HasKey(e => e.Id).HasName("PK_Announcement_Id");

                entity.Property(p => p.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()").IsRequired().ValueGeneratedOnAdd();
                entity.Property(p => p.Title).HasColumnType("character varying").HasMaxLength(100);


                entity.Property(p => p.CreatedTime).HasColumnType("timestamp without time zone").HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Slider>(entity =>
            {
                entity.ToTable("Sliders");
                entity.HasKey(e => e.Id).HasName("PK_Slider_Id");

                entity.Property(p => p.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()").IsRequired().ValueGeneratedOnAdd();
                entity.Property(p => p.Title).HasColumnType("character varying");
                entity.Property(p => p.Description).HasColumnType("character varying");


                entity.Property(p => p.CreatedTime).HasColumnType("timestamp without time zone").HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.ToTable("Videos");
                entity.HasKey(e => e.Id).HasName("PK_Video_Id");

                entity.Property(p => p.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()").IsRequired().ValueGeneratedOnAdd();


                entity.Property(p => p.CreatedTime).HasColumnType("timestamp without time zone").HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Gallery>(entity =>
            {
                entity.ToTable("Galleries");
                entity.HasKey(e => e.Id).HasName("PK_Gallery_Id");

                entity.Property(p => p.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()").IsRequired().ValueGeneratedOnAdd();


                entity.Property(p => p.CreatedTime).HasColumnType("timestamp without time zone").HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            });

            base.OnModelCreating(modelBuilder);


        }

        public DbSet<School> Schools { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Announcement> Announcements { get ; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Gallery> Galleries { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
