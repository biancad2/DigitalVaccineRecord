using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DigitalVaccineRecord.Core.Models
{
    public class DoseModel
    {
        public Guid Id { get; set; }
        public required double FromAge { get; set; }
        public required double ToAge { get; set; }
        public required int Number { get; set; }
        public Guid VaccineId { get; set; }
        public VaccineModel? Vaccine { get; set; }
    }
}
