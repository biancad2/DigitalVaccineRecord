using DigitalVaccineRecord.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalVaccineRecord.Infrastructure.Entities
{
    public class Vaccine
    {
        [Key]
        public Guid Id { get; set; }
        public required EnumVaccineType Type {  get; set; }
        public required string Name {  get; set; }
        public required string Description { get; set; }
        public virtual List<Dose> Doses {  get; set; } 
    }
}
