using DigitalVaccineRecord.Core.Enums;
using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Notifications
{
    public class UserUpdatedNotification : INotification
    {
        public UserUpdatedNotification(UserModel model) { 
            this.Id= model.Id;  
            FirstName = model.FirstName;
            Surname = model.Surname;
            Document= model.Document;
            BirthDate = model.BirthDate;
            NationalHealthCardNumber = model.NationalHealthCardNumber;
            Gender  = model.Gender;
            IsPregnant = model.IsPregnant;
            Profiles = model.Profiles.ToList();
        }    
        public Guid Id { get; set; }
        public String FirstName { get; set; }
        public String Surname { get; set; }
        public String Document { get; set; }
        public DateTime BirthDate { get; set; }
        public String NationalHealthCardNumber { get; set; }
        public EnumGender Gender { get; set; }
        public bool IsPregnant { get; set; }
        public List<EnumProfile> Profiles { get; set; }
    }
}
