using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalVaccineRecord.Core.Models
{
    public class UserDoseModel
    {
        public Guid Id { get; set; }
        public Guid DoseId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public string NurseSignature { get; set; }
        public UserModel User { get; set; }
        public DoseModel Dose { get; set; }
    }
}
