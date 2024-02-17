using AutoMapper;
using DigitalVaccineRecord.Core.Enums;
using DigitalVaccineRecord.Core.Interfaces;
using DigitalVaccineRecord.Core.Models;
using DigitalVaccineRecord.Infrastructure.Context;
using DigitalVaccineRecord.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Validation;

namespace DigitalVaccineRecord.Infrastructure.Repositories
{
    public class DoseRepository : BaseRepository, IDoseRepository
    {
        public DoseRepository(AppDbContext dbContext):base(dbContext) { }

        public void Add(DoseModel item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Edit(DoseModel item)
        {
            throw new NotImplementedException();
        }

        public DoseModel Get(Guid id)
        {
            var dose = _dbContext.Doses.Include(d => d.Vaccine).FirstOrDefault(x => x.Id == id);
            return _mapper.Map<DoseModel>(dose);
        }

        public Task<IEnumerable<DoseModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
