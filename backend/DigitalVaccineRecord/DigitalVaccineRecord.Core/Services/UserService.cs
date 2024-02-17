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
        public readonly IVaccineRepository _vaccineRepository;
        public readonly IUserDoseRepository _userDoseRepository;

        public UserService(IUserRepository userRepository, IVaccineRepository vaccineRepository, IUserDoseRepository userDoseRepository)
        {
            _userRepository = userRepository;
            _vaccineRepository = vaccineRepository;
            _userDoseRepository = userDoseRepository;
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
            var user = _userRepository.Get(id);
            var vaccines = _vaccineRepository.GetAllAsync().Result;
            user.UserVaccines = vaccines.Select(v => new UserVaccineModel()
            {
                Vaccine = v,
                UserDoses = user.UserDoses.Where(ud => ud.Dose.Vaccine.Id == v.Id).ToList()
            }).ToList();
            return user;
        }

        public async Task<List<UserModel>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.ToList();
        }


        public List<UserModel> GetUsers(EnumProfile? profile)
        {
            return _userRepository.GetUsers(profile).ToList();
        }

        public UserDoseModel AddUserDose(UserDoseModel userDose)
        {
            var user = Get(userDose.UserId);

            if (user.UserDoses.FirstOrDefault(d => d.DoseId == userDose.DoseId) != null)
                throw new Exception("Dose ja adicionada");

            var vaccine = _vaccineRepository.GetByDose(userDose.DoseId);
            var lastDoseAdded = user.UserDoses.LastOrDefault(d => d.Dose.VaccineId == vaccine.Id)?.Dose;

            var dose = vaccine.Doses.First(d => d.Id == userDose.DoseId);

            if (lastDoseAdded != null && lastDoseAdded.Number >= dose.Number)
                throw new Exception("Verifique a dose adicionada");

            _userDoseRepository.Add(userDose);
            return userDose;
        }
    }
}
