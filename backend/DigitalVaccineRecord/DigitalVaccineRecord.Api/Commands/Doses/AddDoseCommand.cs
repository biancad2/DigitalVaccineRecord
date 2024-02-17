using DigitalVaccineRecord.Api.Commands.Vaccine;
using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Commands.Doses
{
    public class AddDoseCommand : IRequest<DoseModel>
    {
        public required double FromAge { get; set; }
        public required double ToAge { get; set; }
        public required int Number { get; set; }
    }
    public static class AddDoseCommandExt
    {
        public static DoseModel ConvertRequestToVaccineModel(this AddDoseCommand request, Guid vaccineId)
        {
            return new DoseModel()
            {
                FromAge = request.FromAge,
                ToAge = request.ToAge,
                Number = request.Number,
                VaccineId = vaccineId
            };
        }
    }
}
