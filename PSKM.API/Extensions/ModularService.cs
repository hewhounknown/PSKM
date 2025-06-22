using PSKM.API.Services;
using PSKM.Data.Repositories;
using PSKM.Domain.Interfaces;

namespace PSKM.API.Extensions;

public static class ModularService
{
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
                services.AddAppServices();
                services.AddRepoServices();
                return services;
        }

        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
                services.AddScoped<IPatientService, PatientService>();
                return services;
        }

        public static IServiceCollection AddRepoServices(this IServiceCollection services)
        {
                services.AddScoped<IPatientRepository, PatientRepository>();
                return services;
        }
}
