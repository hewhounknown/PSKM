using FluentValidation;
using PSKM.Common.Enums;
using PSKM.Common.Interfaces.Repositories;
using PSKM.Common.Interfaces.Services;
using PSKM.Common.Models;
using PSKM.Common.Models.Appointment;
using PSKM.Common.Models.Patient;
using PSKM.Common.Utils;

namespace PSKM.Core.Services;

public class PatientService : IPatientService
{
        private readonly IPatientRepository _patientRepository;
        private readonly IValidator<PatientRequestModel> _patientValidator;

        private readonly IAppointmentRepository _appointmentRepository;

        public PatientService(
                IPatientRepository patientRepository,
                IAppointmentRepository appointmentRepository,
                IValidator<PatientRequestModel> patientValidator)
        {
                _patientRepository = patientRepository;
                _appointmentRepository = appointmentRepository;
                _patientValidator = patientValidator;
        }

        public async Task<ResponseModel<object>> RegisterPatient(PatientRequestModel patient)
        {
                var validator = await _patientValidator.ValidateAsync(patient);
                if (!validator.IsValid)
                        return ValidationHelper.FormatErrors(validator.Errors);

                return await _patientRepository.Add(patient);
        }

        public async Task<ResponseModel<List<PatientModel>>> ViewAllPatients()
        {
                return await _patientRepository.GetAll();
        }

        public async Task<ResponseModel<PatientModel>> ViewPatient(int patientId)
        {
                return await _patientRepository.GetById(patientId);
        }

        public async Task<ResponseModel<List<AppointmentResponseModel>>> GetAppointmentsByPatientId(int patientId)
        {
                return await _appointmentRepository.GetByPatientId(patientId);
        }
}
