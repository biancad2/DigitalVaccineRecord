using DigitalVaccineRecord.Core.Enums;
using DigitalVaccineRecord.Core.Models;

namespace DigitalVaccineRecord.Core.Interfaces
{
    public interface IUserRepository : IRepository<UserModel>
    {
        IEnumerable<UserModel> GetUsers(EnumProfile? profile);
        void AddDose(UserDoseModel doseModel);
    }
}
