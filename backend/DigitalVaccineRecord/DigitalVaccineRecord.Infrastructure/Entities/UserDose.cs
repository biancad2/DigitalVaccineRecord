using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalVaccineRecord.Infrastructure.Entities
{
    public class UserDose
    {
        public Guid Id { get; set; }
        public Guid DoseId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public string NurseSignature { get; set; }

        [ForeignKey("UserId")]
        public virtual required User User { get; set; }
        [ForeignKey("DoseId")]
        public virtual required Dose Dose { get; set; }
    }
}
