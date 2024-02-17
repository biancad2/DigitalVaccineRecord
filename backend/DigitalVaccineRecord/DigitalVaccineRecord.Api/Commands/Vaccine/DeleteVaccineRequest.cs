using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Commands.Vaccine
{
    public class DeleteVaccineRequest : IRequest<bool>
    {
        public required Guid Id { get; set; }
    }
}
