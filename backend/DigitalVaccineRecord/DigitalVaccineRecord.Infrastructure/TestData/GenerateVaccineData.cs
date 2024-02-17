using DigitalVaccineRecord.Core.Enums;
using DigitalVaccineRecord.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalVaccineRecord.Infrastructure.TestData
{
    public static class GenerateVaccineData
    {
        public static IEnumerable<Vaccine> GenerateListOfVaccines()
        {
            var list = new List<Vaccine>
            {
                GenerateBCG(),
                GenerateHepatitisB(),
                GenerateDTaP(),
                GeneratePoliovirus()
            };
            return list;
        }
        internal static Vaccine GenerateBCG()
        {
            var vaccine = new Vaccine()
            {
                Id = Guid.NewGuid(),
                Description = "Evita Formas graves de tuberculose",
                Name = "BCG - ID",
                Type = EnumVaccineType.National,
                Doses = new List<Dose>() 
            };

            vaccine.Doses.Add(new Dose()
            {
                Id = Guid.NewGuid(),
                FromAge = 0,
                ToAge = 4,
                Number = 1,
                Vaccine = vaccine,
                VaccineId = vaccine.Id
            });
            return vaccine;
        }        
        
        internal static Vaccine GenerateHepatitisB()
        {
            var vaccine = new Vaccine()
            {
                Id = Guid.NewGuid(),
                Description = "Hepatite B",
                Name = "Hepatite B",
                Type = EnumVaccineType.National,
                Doses = new List<Dose>() 
            };

            vaccine.Doses.Add(new Dose()
            {
                Id = Guid.NewGuid(),
                FromAge = 0,
                ToAge = ConverMonthToYear(1),
                Number = 1,
                Vaccine = vaccine,
                VaccineId = vaccine.Id
            });            
            
            vaccine.Doses.Add(new Dose()
            {
                Id = Guid.NewGuid(),
                FromAge = ConverMonthToYear(1),
                ToAge = ConverMonthToYear(2),
                Number = 2,
                Vaccine = vaccine,
                VaccineId = vaccine.Id
            });
            
            vaccine.Doses.Add(new Dose()
            {
                Id = Guid.NewGuid(),
                FromAge = ConverMonthToYear(6),
                ToAge = ConverMonthToYear(18),
                Number = 3,
                Vaccine = vaccine,
                VaccineId = vaccine.Id
            });
            return vaccine;
        }
        
        internal static Vaccine GeneratePoliovirus()
        {
            var vaccine = new Vaccine()
            {
                Id = Guid.NewGuid(),
                Description = "Poliomielite (paralisia infantil)",
                Name = "VOP",
                Type = EnumVaccineType.National,
                Doses = new List<Dose>() 
            };

            vaccine.Doses.Add(new Dose()
            {
                Id = Guid.NewGuid(),
                FromAge = ConverMonthToYear(2),
                ToAge = ConverMonthToYear(2),
                Number = 1,
                Vaccine = vaccine,
                VaccineId = vaccine.Id
            });            
            
            vaccine.Doses.Add(new Dose()
            {
                Id = Guid.NewGuid(),
                FromAge = ConverMonthToYear(4),
                ToAge = ConverMonthToYear(4),
                Number = 2,
                Vaccine = vaccine,
                VaccineId = vaccine.Id
            });
            
            vaccine.Doses.Add(new Dose()
            {
                Id = Guid.NewGuid(),
                FromAge = ConverMonthToYear(6),
                ToAge = ConverMonthToYear(18),
                Number = 3,
                Vaccine = vaccine,
                VaccineId = vaccine.Id
            });            
            
            vaccine.Doses.Add(new Dose()
            {
                Id = Guid.NewGuid(),
                FromAge = 4,
                ToAge = 6,
                Number = 4,
                Vaccine = vaccine,
                VaccineId = vaccine.Id
            });
            return vaccine;
        } 
        
        internal static Vaccine GenerateDTaP()
        {
            var vaccine = new Vaccine()
            {
                Id = Guid.NewGuid(),
                Description = "Difteria, tétano, coqueluche, meningite e outras infecções causadas pelo Haemophilus influenzaetipo b\r\n",
                Name = "Tetravalente",
                Type = EnumVaccineType.National,
                Doses = new List<Dose>() 
            };

            vaccine.Doses.Add(new Dose()
            {
                Id = Guid.NewGuid(),
                FromAge = 0,
                ToAge = ConverMonthToYear(1),
                Number = 1,
                Vaccine = vaccine,
                VaccineId = vaccine.Id
            });            
            
            vaccine.Doses.Add(new Dose()
            {
                Id = Guid.NewGuid(),
                FromAge = ConverMonthToYear(1),
                ToAge = ConverMonthToYear(2),
                Number = 2,
                Vaccine = vaccine,
                VaccineId = vaccine.Id
            });
            
            vaccine.Doses.Add(new Dose()
            {
                Id = Guid.NewGuid(),
                FromAge = ConverMonthToYear(2),
                ToAge = ConverMonthToYear(4),
                Number = 3,
                Vaccine = vaccine,
                VaccineId = vaccine.Id
            });     
            return vaccine;
        }


        private static double ConverMonthToYear(int month) {
            return Math.Round((double)month / 12, 2);
        }

    }
}
