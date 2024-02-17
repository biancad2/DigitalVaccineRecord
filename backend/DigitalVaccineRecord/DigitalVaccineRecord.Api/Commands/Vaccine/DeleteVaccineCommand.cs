using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Commands.Vaccine
{
    public class DeleteVaccineCommand : IRequest<bool>
    {
        public required Guid Id { get; set; }
    }
}
