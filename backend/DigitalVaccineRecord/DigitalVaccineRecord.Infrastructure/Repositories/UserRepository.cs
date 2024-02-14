using AutoMapper;
using DigitalVaccineRecord.Core.Enums;
using DigitalVaccineRecord.Core.Interfaces;
using DigitalVaccineRecord.Core.Models;
using DigitalVaccineRecord.Infrastructure.Context;
using DigitalVaccineRecord.Infrastructure.Entities;
using System.Data.Entity.Validation;

namespace DigitalVaccineRecord.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserModel>();
                cfg.CreateMap<UserModel, User>();
            });
            _mapper = configuration.CreateMapper();
        }

        public UserModel Get(Guid id)
        {
            var user = _dbContext.Find<User>(id);
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

        public IEnumerable<UserModel> GetAll()
        {
            return _mapper.Map<IEnumerable<UserModel>>(_dbContext.Users.ToList());
        }


    }
}
