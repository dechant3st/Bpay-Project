using Bpay_Project.DB.Entities;
using Bpay_Project.DB.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bpay_Project.DB
{
    public class AppDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Barangay> Barangay { get; set; }
        public DbSet<LookupCategory> LookupCategories { get; set; }
        public DbSet<LookupSubcategory> LookupSubcategories { get; set; }
        public DbSet<MFC> MFC { get; set; }
        public DbSet<DocumentAttachment> DocumentAttachments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.SetTableName();
        }
    }
}
