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
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(UserModel model)
        {
            _userRepository.Add(model);
        }

        public void Delete(Guid id)
        {
            _userRepository.Delete(id);
        }

        public void Edit(UserModel model)
        {
            _userRepository.Edit(model);
        }

        public UserModel Get(Guid id)
        {
            return _userRepository.Get(id);
        }

        public List<UserModel> GetAll()
        {
            return _userRepository.GetAll().ToList();
        }


        public List<UserModel> GetUsers(EnumProfile? profile)
        {
            return _userRepository.GetUsers(profile).ToList();
        }
    }
}
