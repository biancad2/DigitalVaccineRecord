using DigitalVaccineRecord.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalVaccineRecord.Core.Models
{
    public class UserVaccineModel
    {
        public VaccineModel Vaccine { get; set; }
        public List<UserDoseModel> UserDoses { get; set; }
    }
}
