using DigitalVaccineRecord.Core.Enums;
using DigitalVaccineRecord.Core.Interfaces;
using DigitalVaccineRecord.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DigitalVaccineRecord.Core.Services
{
    public class VaccineService : IVaccineService
    {
        public readonly IVaccineRepository _vaccineRepository;
        public VaccineService(IVaccineRepository vaccineRepository)
        {
            _vaccineRepository = vaccineRepository;
        }

        public void Add(VaccineModel model)
        {
            _vaccineRepository.Add(model);
        }

        public void Delete(Guid id)
        {
            _vaccineRepository.Delete(id);
        }

        public void Edit(VaccineModel model)
        {
            _vaccineRepository.Edit(model);
        }

        public VaccineModel Get(Guid id)
        {
            return _vaccineRepository.Get(id);
        }

        public async Task<List<VaccineModel>> GetAllAsync()
        {
            var vaccines = await _vaccineRepository.GetAllAsync();
            foreach(var vaccine in vaccines)
            {
                vaccine.Doses = vaccine.Doses.OrderBy(d => d.Number).ToList();
            }
            return vaccines.ToList();
        }
    }
}
