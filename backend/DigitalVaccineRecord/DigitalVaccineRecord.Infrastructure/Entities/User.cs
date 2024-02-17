using DigitalVaccineRecord.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalVaccineRecord.Infrastructure.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(100)]
        public required String FirstName { get; set; }        
        [StringLength(100)]
        public required String Surname { get; set; }
        [StringLength(14)]
        public required String Document { get; set; }
        public DateTime BirthDate { get; set; }
        [StringLength(15)]
        public required String NationalHealthCardNumber { get; set; }
        public required EnumGender Gender { get; set; }
        public bool IsPregnant { get; set; }
        public List<EnumProfile> Profiles { get; set; }
        //public virtual ICollection<UserDose> UserDoses { get; set; }
    }
}
