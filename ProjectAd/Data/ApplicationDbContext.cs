using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectAd.Models;

namespace ProjectAd.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    // Configure Student & StudentAddress entity
        //    modelBuilder.Entity<Ad>()
        //                .HasOptional(s => s.Address) // Mark Address property optional in Student entity
        //                .WithRequired(ad => ad.Student); // mark Student property as required in StudentAddress entity. Cannot save StudentAddress without Student
        //}

        public DbSet<Ad> Ads { get; set; }
        public DbSet<Target> Targets { get; set; }
    }
}
