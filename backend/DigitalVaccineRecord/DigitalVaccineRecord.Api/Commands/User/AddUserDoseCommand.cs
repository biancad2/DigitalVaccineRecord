using DigitalVaccineRecord.Core.Enums;
using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Commands.User
{
    public class AddUserDoseCommand : IRequest<UserDoseModel>
    {
        public required DateTime Date { get; set; }
        public required String NurseSignature { get; set; }
        public required Guid UserId { get; set; }
        public required Guid DoseId { get; set; }
    }

    public static class AddUserDoseCommandExt
    {
        public static UserDoseModel ConvertRequestToUserDoseModel(this AddUserDoseCommand request)
        {
            return new UserDoseModel()
            {
                Id = Guid.NewGuid(),
                DoseId = request.DoseId,
                UserId = request.UserId,
                Date = request.Date,
                NurseSignature = request.NurseSignature
            };
        }
    }
}
