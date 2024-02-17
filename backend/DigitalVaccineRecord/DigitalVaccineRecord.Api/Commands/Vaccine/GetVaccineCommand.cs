using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Commands.Vaccine
{
    public class GetVaccineCommand : IRequest<VaccineModel>
    {
        public required Guid Id { get; set; }
    }
}
