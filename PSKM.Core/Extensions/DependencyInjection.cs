using PSKM.Core.Services;
using PSKM.Data.Repositories;
using PSKM.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

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
                return services;
        }

        public static IServiceCollection AddRepoServices(this IServiceCollection services)
        {
                services.AddScoped<IPatientRepository, PatientRepository>();
                return services;
        }
}
