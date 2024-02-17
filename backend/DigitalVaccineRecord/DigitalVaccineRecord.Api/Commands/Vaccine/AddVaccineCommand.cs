using DigitalVaccineRecord.Api.Commands.Doses;
using DigitalVaccineRecord.Core.Enums;
using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Commands.Vaccine
{
    public class AddVaccineCommand : IRequest<VaccineModel>
    {
        public EnumVaccineType Type { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public List<AddDoseCommand> Doses { get; set; }
    }

    public static class AddVaccineCommandExt
    {
        public static VaccineModel ConvertRequestToVaccineModel(this AddVaccineCommand request)
        {
            var id = Guid.NewGuid();

            var vaccine = new VaccineModel()
            {
                Id = id,
                Description = request.Description,
                Type = request.Type,
                Name = request.Name,  
                Doses = new List<DoseModel>()
            };
            foreach (var item in request.Doses)
            {
                var doseModel = item.ConvertRequestToVaccineModel(id);
                doseModel.Id = Guid.NewGuid();
                vaccine.Doses.Add(doseModel);

            }
            return vaccine;
        }
    }
}
