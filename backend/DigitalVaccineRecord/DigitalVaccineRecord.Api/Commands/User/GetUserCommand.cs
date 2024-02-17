using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Commands.User
{
    public class GetUserCommand : IRequest<UserModel>
    {
        public required Guid Id { get; set; }
    }
}
