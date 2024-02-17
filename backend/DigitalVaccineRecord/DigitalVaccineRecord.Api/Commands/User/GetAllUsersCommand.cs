using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Commands.User
{
    public class GetAllUsersCommand : IRequest<List<UserModel>>
    {
    }
}
