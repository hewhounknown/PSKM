using PSKM.Core.Services;
using PSKM.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using PSKM.Common.Interfaces.Repositories;
using PSKM.Common.Interfaces.Services;
using FluentValidation;
using PSKM.Common.Models.Patient;
using PSKM.Common.Utils;
using PSKM.Common.Models.Doctor;
using PSKM.Common.Models.Appointment;

namespace PSKM.Core.Extensions;

public static class DependencyInjection
{
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
                services.AddAppServices();
                services.AddRepoServices();
                services.AddRequestValidator();
                return services;
        }

        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
                services.AddScoped<IPatientService, PatientService>();
                services.AddScoped<ISpecialistService, SpecialistService>();
                services.AddScoped<IDoctorService, DoctorService>();
                services.AddScoped<IAppointmentService, AppointmentService>();
                return services;
        }

        public static IServiceCollection AddRepoServices(this IServiceCollection services)
        {
                services.AddScoped<IPatientRepository, PatientRepository>();
                services.AddScoped<ISpecialistRepository, SpecialistRepository>();
                services.AddScoped<IDoctorRepository, DoctorRepository>();
                services.AddScoped<IAppointmentRepository, AppointmentRepository>();
                return services;
        }

        public static IServiceCollection AddRequestValidator(this IServiceCollection services)
        {
                services.AddScoped<IValidator<PatientRequestModel>, PatientValidator>();
                services.AddScoped<IValidator<DoctorRequestModel>, DoctorValidator>();
                services.AddScoped<IValidator<AppointmentRequestModel>, AppointmentValidator>();
                services.AddScoped<IValidator<AppointmentUpdateRequestModel>, AppointmentUpdateValidator>();
                return services;
        }
}
