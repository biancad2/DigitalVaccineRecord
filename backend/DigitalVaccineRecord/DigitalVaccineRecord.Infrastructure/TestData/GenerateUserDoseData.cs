using DigitalVaccineRecord.Core.Enums;
using DigitalVaccineRecord.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalVaccineRecord.Infrastructure.TestData
{
    public static class GenerateUserDoseData
    {
        public static IEnumerable<UserDose> GenerateListOfDosesForUser(User user, Dose dose)
        {
            var list = new List<UserDose>
            {
               new UserDose()
               {
                   Id = Guid.NewGuid(),
                   Date = new DateTime(2023, 04, 10),
                   DoseId = dose.Id,
                   UserId = user.Id,
                   NurseSignature = "Enfermeira 1"
               }
            };
            return list;
        }
    }
}
