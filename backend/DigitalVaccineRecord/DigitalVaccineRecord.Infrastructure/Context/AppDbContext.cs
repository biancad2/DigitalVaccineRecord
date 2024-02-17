using DigitalVaccineRecord.Core.Enums;
using DigitalVaccineRecord.Infrastructure.Entities;
using DigitalVaccineRecord.Infrastructure.TestData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalVaccineRecord.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "LocalDb");         
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }



        public DbSet<User> Users { get; set; }
        public DbSet<Dose> Doses { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<UserDose> UserDoses { get; set; }
    }
}
