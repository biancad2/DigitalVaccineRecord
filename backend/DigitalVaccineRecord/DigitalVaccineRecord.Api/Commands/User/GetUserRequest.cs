using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Commands.User
{
    public class GetUserRequest : IRequest<UserModel>
    {
        public required Guid Id { get; set; }
    }

    //public static class GetUserRequestExt
    //{
    //    public static UserModel ConvertRequestToUserModel(this GetUserRequest request)
    //    {
    //        return new UserModel()
    //        {
    //            Id = request.Id,
    //            Document = request.Document,
    //            FirstName = request.FirstName,
    //            Surname = request.Surname,
    //            Gender = request.Gender,
    //            NationalHealthCardNumber = request.NationalHealthCardNumber
    //        };
    //    }
    //}
}
