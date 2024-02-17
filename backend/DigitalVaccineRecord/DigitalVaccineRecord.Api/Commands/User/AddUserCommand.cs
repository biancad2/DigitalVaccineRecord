using DigitalVaccineRecord.Core.Enums;
using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Commands.User
{
    public class AddUserCommand : IRequest<UserModel>
    {
        public required String FirstName { get; set; }
        public required String Surname { get; set; }
        public required String Document { get; set; }
        public DateTime BirthDate { get; set; }
        public required String NationalHealthCardNumber { get; set; }
        public required EnumGender Gender { get; set; }
        public bool IsPregnant { get; set; }
        public List<EnumProfile> Profiles { get; set; }
    }

    public static class AddUserCommandExt
    {
        public static UserModel ConvertRequestToUserModel(this AddUserCommand request)
        {
            return new UserModel()
            {
                Id = Guid.NewGuid(),
                Document = request.Document,
                FirstName = request.FirstName,
                Surname = request.Surname,
                Gender = request.Gender,
                NationalHealthCardNumber = request.NationalHealthCardNumber,
                Profiles = request.Profiles,
                BirthDate = request.BirthDate,
                IsPregnant = request.IsPregnant
            };
        }
    }
}
