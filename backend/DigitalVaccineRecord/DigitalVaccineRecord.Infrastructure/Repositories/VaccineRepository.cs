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
    public class VaccineRepository : BaseRepository, IVaccineRepository
    {

        public VaccineRepository(AppDbContext dbContext):base(dbContext) { }

        public VaccineModel Get(Guid id)
        {
            var vaccine = _dbContext.Find<Vaccine>(id);
            return _mapper.Map<VaccineModel>(vaccine);
        }

        public void Add(VaccineModel model)
        {
            _dbContext.Add(_mapper.Map<Vaccine>(model));
            _dbContext.SaveChanges();
        }

        public void Edit(VaccineModel model)
        {
            _dbContext.Update(_mapper.Map<Vaccine>(model));
            _dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var vaccine = _dbContext.Find<Vaccine>(id);
            _dbContext.Remove(vaccine);
            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<VaccineModel>> GetAllAsync()
        {
            //using (var context = new AppDbContext(_contextOptions)) {
                var vaccines = _dbContext.Vaccines.Include(v => v.Doses);
                return _mapper.Map<List<VaccineModel>>(vaccines.ToList());
            //}
            //using var context = new AppDbContext(_contextOptions);

        }

    }
}
