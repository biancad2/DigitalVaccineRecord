using DigitalVaccineRecord.Api.Commands.Vaccine;
using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Commands.Doses
{
    public class UpdateDoseCommand : IRequest<DoseModel>
    {
        public required Guid Id { get; set; }
        public required double FromAge { get; set; }
        public required double ToAge { get; set; }
        public required int Number { get; set; }
        public required Guid VaccineId { get; set; }
    }
    public static class UpdateDoseCommandExt
    {
        public static DoseModel ConvertRequestToDoseModel(this UpdateDoseCommand request)
        {
            return new DoseModel()
            {
                Id = request.Id,
                FromAge = request.FromAge,
                ToAge = request.ToAge,
                Number = request.Number,
                VaccineId = request.VaccineId
            };
        }
    }
}
