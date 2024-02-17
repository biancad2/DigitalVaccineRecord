using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Commands.User
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public required Guid Id { get; set; }
    }
}
