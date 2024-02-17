using AutoMapper;
using DigitalVaccineRecord.Core.Enums;
using DigitalVaccineRecord.Core.Models;
using DigitalVaccineRecord.Infrastructure.Context;
using DigitalVaccineRecord.Infrastructure.Entities;
using DigitalVaccineRecord.Infrastructure.TestData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DigitalVaccineRecord.Infrastructure.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _dbContext;
        protected readonly IMapper _mapper;

        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Dose, DoseModel>();
                cfg.CreateMap<DoseModel, Dose>();
                cfg.CreateMap<Vaccine, VaccineModel>();
                cfg.CreateMap<VaccineModel, Vaccine>();
                cfg.CreateMap<User, UserModel>();
                cfg.CreateMap<UserModel, User>();
                cfg.CreateMap<UserDoseModel, UserDose>();
                cfg.CreateMap<UserDose, UserDoseModel>();
            });
            _mapper = configuration.CreateMapper();

            AddTestData(_dbContext);

        }
        private static void AddTestData(AppDbContext context)
        {
            if (context.Users.Count() > 0)
                return;

            context.Users.AddRange(GenerateUserData.GenerateListOfUsers());
            context.Vaccines.AddRange(GenerateVaccineData.GenerateListOfVaccines());

            context.SaveChanges();

            context.UserDoses.AddRange(GenerateUserDoseData.GenerateListOfDosesForUser(context.Users.FirstOrDefault(), context.Doses.FirstOrDefault()));
            context.SaveChanges();
        }
    }
}
