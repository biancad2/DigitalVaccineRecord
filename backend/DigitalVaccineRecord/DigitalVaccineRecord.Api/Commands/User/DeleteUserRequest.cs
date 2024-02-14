using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Commands.User
{
    public class DeleteUserRequest : IRequest<bool>
    {
        public required Guid Id { get; set; }
    }
}
