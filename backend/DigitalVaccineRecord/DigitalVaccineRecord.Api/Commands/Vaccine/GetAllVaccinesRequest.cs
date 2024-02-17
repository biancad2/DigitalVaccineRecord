using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Commands.Vaccine
{
    public class GetAllVaccinesRequest : IRequest<List<VaccineModel>>
    {
    }
}
