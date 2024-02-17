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
        //protected readonly DbContextOptions<AppDbContext> _contextOptions;


        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;

           // _contextOptions = new DbContextOptionsBuilder<AppDbContext>()
           //.UseInMemoryDatabase("LocalDb")
           //.ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
           //.Options;

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Dose, DoseModel>();
                cfg.CreateMap<DoseModel, Dose>();
                cfg.CreateMap<Vaccine, VaccineModel>();
                //.Include<Dose, DoseModel>();
                cfg.CreateMap<VaccineModel, Vaccine>();
                cfg.CreateMap<User, UserModel>();
                cfg.CreateMap<UserModel, User>();
            });
            _mapper = configuration.CreateMapper();

            AddTestData(_dbContext);

        }
        private static void AddTestData(AppDbContext context)
        {
            //using (var context = new AppDbContext(opt))
            //{
            if (context.Users.Count() > 0)
                return;
            context.Users.AddRange(GenerateUserData.GenerateListOfUsers());
            context.Vaccines.AddRange(GenerateVaccineData.GenerateListOfVaccines());
            context.SaveChanges();
            //}

        }
    }
}
