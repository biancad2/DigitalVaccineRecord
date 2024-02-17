using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Commands.Vaccine
{
    public class GetAllVaccinesCommand : IRequest<List<VaccineModel>>
    {
    }
}
