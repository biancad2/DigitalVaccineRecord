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
            if (this.Users?.Count() == 0)
                AddTestData(this);
        }

        private static void AddTestData(AppDbContext context)
        {
            context.Users.AddRange(GenerateUserData.GenerateListOfUsers());
            context.SaveChanges();
        }

        //private static IEnumerable<User> GenerateUsers() { 
        //    var list = new List<User>();

        //    var patient = new User
        //    {
        //        Id = Guid.NewGuid(),
        //        BirthDate = new DateTime(1990, 02, 14),
        //        Document = "702.425.100-00",
        //        FirstName = "Bianca",
        //        Surname = "Barreto",
        //        NationalHealthCardNumber = "0000 1234 5678 9012",
        //        Gender = EnumGender.Female,
        //        IsPregnant = false,
        //        Profiles = new EnumProfile[] { EnumProfile.Patient }
        //    }; 
            
        //    var nurse = new User
        //    {
        //        Id = Guid.NewGuid(),
        //        BirthDate = new DateTime(1990, 02, 14),
        //        Document = "702.425.100-00",
        //        FirstName = "Bianca",
        //        Surname = "Barreto",
        //        NationalHealthCardNumber = "0000 1234 5678 9012",
        //        Gender = EnumGender.Female,
        //        IsPregnant = false,
        //        Profiles = new EnumProfile[] { EnumProfile.Nurse, EnumProfile.Patient }
        //    };

        //    list.Add(patient);
        //    list.Add(nurse);
        //    return list;
        //}

        public DbSet<User> Users { get; set; }
    }
}
