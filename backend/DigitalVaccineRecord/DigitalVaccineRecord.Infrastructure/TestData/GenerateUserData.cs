using DigitalVaccineRecord.Core.Enums;
using DigitalVaccineRecord.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalVaccineRecord.Infrastructure.TestData
{
    internal static class GenerateUserData
    {
        internal static IEnumerable<User> GenerateListOfUsers()
        {
            var list = new List<User>
            {
                GeneratePatient(),
                GenerateNurse()
            };  
            return list;
        }
        internal static User GeneratePatient()
        {
            return new User
            {
                Id = Guid.NewGuid(),
                BirthDate = new DateTime(1990, 02, 14),
                Document = "702.425.100-00",
                FirstName = "Bianca",
                Surname = "Paciente",
                NationalHealthCardNumber = "0000 1234 5678 9012",
                Gender = EnumGender.Female,
                IsPregnant = false,
                Profiles = new List<EnumProfile>() { EnumProfile.Patient }
            };
        } 
        
        internal static User GenerateNurse()
        {
            return new User
            {
                Id = Guid.NewGuid(),
                BirthDate = new DateTime(1990, 02, 14),
                Document = "702.425.100-01",
                FirstName = "Bianca",
                Surname = "Enfermeira",
                NationalHealthCardNumber = "0000 1234 5678 9015",
                Gender = EnumGender.Female,
                IsPregnant = false,
                Profiles = new List<EnumProfile>() { EnumProfile.Nurse, EnumProfile.Patient }
            };
        }
    }
}
