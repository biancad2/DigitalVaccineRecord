using DigitalVaccineRecord.Core.Interfaces;
using DigitalVaccineRecord.Core.Services;
using DigitalVaccineRecord.Infrastructure.Repositories;

namespace DigitalVaccineRecord.Api.Configuration
{
    public static class DependencyInjection
    {
        public static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        } 
        
        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
