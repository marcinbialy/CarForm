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
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CarMark> CarMarks { get; set; }
        public DbSet<Feature> Features { get; set; }
    }
}
