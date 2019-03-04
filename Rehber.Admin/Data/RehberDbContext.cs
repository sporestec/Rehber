using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Rehber.Admin.Data
{
    public partial class RehberDbContext : DbContext
    {
        public RehberDbContext()
        {
        }

        public RehberDbContext(DbContextOptions<RehberDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Units> Units { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=RehberDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Units>(entity =>
            {
                entity.HasKey(e => e.UnitId);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.HasIndex(e => e.UnitId);

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UnitId);
            });
        }
    }
}
