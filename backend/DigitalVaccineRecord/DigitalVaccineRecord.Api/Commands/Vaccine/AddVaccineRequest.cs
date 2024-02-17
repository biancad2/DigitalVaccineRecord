using DigitalVaccineRecord.Core.Enums;
using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Commands.Vaccine
{
    public class AddVaccineRequest : IRequest<VaccineModel>
    {
        public EnumVaccineType Type { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required List<DoseModel> Doses { get; set; }
    }

    public static class AddVaccineRequestExt
    {
        public static VaccineModel ConvertRequestToVaccineModel(this AddVaccineRequest request)
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
                item.Vaccine = vaccine;
                //item.VaccineId = id;
                item.Id = Guid.NewGuid();
                vaccine.Doses.Add(item);
            }
            return vaccine;
        }
    }
}
