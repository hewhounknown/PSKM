using PSKM.Core.Services;
using PSKM.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using PSKM.Common.Interfaces.Patient;
using PSKM.Common.Interfaces.Specialist;
using PSKM.Common.Interfaces.Doctor;

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
                services.AddScoped<IDoctorService, DoctorService>();
                return services;
        }

        public static IServiceCollection AddRepoServices(this IServiceCollection services)
        {
                services.AddScoped<IPatientRepository, PatientRepository>();
                services.AddScoped<ISpecialistRepository, SpecialistRepository>();
                services.AddScoped<IDoctorRepository, DoctorRepository>();
                return services;
        }
}
