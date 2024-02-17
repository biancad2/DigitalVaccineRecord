using DigitalVaccineRecord.Core.Interfaces;
using DigitalVaccineRecord.Core.Models;
using DigitalVaccineRecord.Infrastructure.Context;
using DigitalVaccineRecord.Infrastructure.Entities;

namespace DigitalVaccineRecord.Infrastructure.Repositories
{
    public class UserDoseRepository : BaseRepository, IUserDoseRepository
    {
        public UserDoseRepository(AppDbContext dbContext):base(dbContext) { }

        public void Add(UserDoseModel model)
        {
            _dbContext.UserDoses.Add(_mapper.Map<UserDose>(model));
            _dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Edit(UserDoseModel item)
        {
            throw new NotImplementedException();
        }

        public UserDoseModel Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDoseModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
