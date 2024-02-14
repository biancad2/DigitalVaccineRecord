using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Commands.User
{
    public class GetAllUserRequest : IRequest<List<UserModel>>
    {
    }
}
