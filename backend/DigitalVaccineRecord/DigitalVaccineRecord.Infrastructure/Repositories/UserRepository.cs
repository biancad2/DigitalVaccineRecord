using DigitalVaccineRecord.Core.Enums;
using DigitalVaccineRecord.Core.Interfaces;
using DigitalVaccineRecord.Core.Models;
using DigitalVaccineRecord.Infrastructure.Context;
using DigitalVaccineRecord.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalVaccineRecord.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext dbContext):base(dbContext) { }

        public UserModel Get(Guid id)
        {
            var user = _dbContext.Users.Include(u => u.UserDoses)
                        .ThenInclude(d => d.Dose)
                        .ThenInclude(v => v.Vaccine)
                        .FirstOrDefault(u => u.Id == id);
            return _mapper.Map<UserModel>(user);
        }

        public void Add(UserModel model)
        {
            _dbContext.Add(_mapper.Map<User>(model));
            _dbContext.SaveChanges();
        }

        public void Edit(UserModel model)
        {
            _dbContext.Update(_mapper.Map<User>(model));
            _dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var user = _dbContext.Find<User>(id);
            _dbContext.Remove(user);
            _dbContext.SaveChanges();
        }

        public IEnumerable<UserModel> GetUsers(EnumProfile? profile)
        {
            if(profile.HasValue)
            {
                var users = _dbContext.Users.Where(u => u.Profiles.ToList().Contains(profile.Value));
                return _mapper.Map<IEnumerable<UserModel>>(users);
            }

            return _mapper.Map<IEnumerable<UserModel>>(_dbContext.Users);
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<UserModel>>(_dbContext.Users.ToList());
        }        
        
        public void AddDose(UserDoseModel doseModel)
        {
            _dbContext.UserDoses.Add(_mapper.Map<UserDose>(doseModel));
            _dbContext.SaveChanges();
        }
    }
}
