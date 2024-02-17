using DigitalVaccineRecord.Core.Enums;
using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Commands.Vaccine
{
    public class UpdateVaccineRequest : IRequest<VaccineModel>
    {
        public required Guid Id { get; set; }
        public EnumVaccineType Type { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required List<DoseModel> Doses { get; set; }
    }

    public static class UpdateVaccineRequestExt
    {
        public static VaccineModel ConvertRequestToVaccineModel(this UpdateVaccineRequest request)
        {
            return new VaccineModel()
            {
                Id = request.Id,
                Description = request.Description,
                Type = request.Type,
                Name = request.Name,
                Doses = request.Doses
            };
        }
    }
}
