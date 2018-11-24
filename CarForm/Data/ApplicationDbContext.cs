using System;
using System.Collections.Generic;
using System.Text;
using CarForm.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarForm.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<CarMark> CarMarks { get; set; }
        public DbSet<Feature> Features { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VehicleFeature>().HasKey(vf => new { vf.VehicleId, vf.FeatureId });
        }

    }
}
