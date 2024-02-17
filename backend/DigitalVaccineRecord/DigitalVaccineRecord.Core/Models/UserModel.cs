using DigitalVaccineRecord.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalVaccineRecord.Core.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public required String FirstName { get; set; }
        public required String Surname { get; set; }
        public required String Document { get; set; }
        public DateTime BirthDate { get; set; }
        public required String NationalHealthCardNumber { get; set; }
        public required EnumGender Gender { get; set; }
        public bool IsPregnant { get; set; }
        public List<EnumProfile> Profiles { get; set; }
        public List<UserDoseModel> UserDoses { get; set; }
        public List<VaccineModel> Vaccines { get; set; }
        public List<UserVaccineModel> UserVaccines { get; set; }
    }
}
