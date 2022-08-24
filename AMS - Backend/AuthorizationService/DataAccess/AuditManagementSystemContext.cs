using System;
using AuthorizationService.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AuthorizationService.DataAccess
{
    public partial class AuditManagementSystemContext : DbContext
    {
        public AuditManagementSystemContext()
        {
        }

        public AuditManagementSystemContext(DbContextOptions<AuditManagementSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Audit> Audit { get; set; }
        public virtual DbSet<Userdetails> Userdetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = tcp:kdh.database.windows.net, 1433; Initial Catalog = AMS; Persist Security Info = False; User ID = kavya; Password = R@punzel050; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Userdetails>().HasData(new Userdetails
            {
                Userid = 1,
                Email = "kavya@gmail.com",
                Password = "abc@123"
            });
        }

    }
}
