using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Commands.Vaccine
{
    public class GetVaccineRequest : IRequest<VaccineModel>
    {
        public required Guid Id { get; set; }
    }
}
