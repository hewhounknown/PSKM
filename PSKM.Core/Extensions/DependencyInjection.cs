using PSKM.Core.Services;
using PSKM.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using PSKM.Common.Interfaces.Patient;
using PSKM.Common.Interfaces.Specialist;

namespace PSKM.Core.Extensions;

public static class DependencyInjection
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
                services.AddScoped<ISpecialistService, SpecialistService>();
                return services;
        }

        public static IServiceCollection AddRepoServices(this IServiceCollection services)
        {
                services.AddScoped<IPatientRepository, PatientRepository>();
                services.AddScoped<ISpecialistRepository, SpecialistRepository>();
                return services;
        }
}
