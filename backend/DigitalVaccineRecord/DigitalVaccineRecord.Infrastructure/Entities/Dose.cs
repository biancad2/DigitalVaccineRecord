using DigitalVaccineRecord.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalVaccineRecord.Infrastructure.Entities
{
    public class Dose
    {
        [Key]
        public Guid Id { get; set; }
        public required double FromAge { get; set; }
        public required double ToAge { get; set; }
        public required int Number { get; set; }
        //public required Guid VaccineId { get; set; }

        //[ForeignKey("VaccineId")]
        public virtual Vaccine Vaccine { get; set; }
    }
}
