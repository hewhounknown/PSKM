using FluentValidation;
using PSKM.Common.Enums;
using PSKM.Common.Interfaces.Repositories;
using PSKM.Common.Interfaces.Services;
using PSKM.Common.Models;
using PSKM.Common.Models.Appointment;
using PSKM.Common.Utils;

namespace PSKM.Core.Services;

public class AppointmentService : IAppointmentService
{
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IValidator<AppointmentRequestModel> _apptCreateValidator;
        private readonly IValidator<AppointmentUpdateRequestModel> _apptUpdateValidator;

        public AppointmentService(
                IAppointmentRepository appointmentRepository,
                IValidator<AppointmentRequestModel> apptCreateValidator,
                IValidator<AppointmentUpdateRequestModel> apptUpdateValidator
                )
        {
                _appointmentRepository = appointmentRepository;
                _apptCreateValidator = apptCreateValidator;
                _apptUpdateValidator = apptUpdateValidator;
        }

        public async Task<ResponseModel<object>> AddAppointment(AppointmentRequestModel appointment)
        {
                var validator = await _apptCreateValidator.ValidateAsync(appointment);
                if (!validator.IsValid)
                {
                        return ValidationHelper.FormatErrors(validator.Errors);
                }

                return await _appointmentRepository.Add(appointment);
        }

        public async Task<ResponseModel<object>> DeleteAppointment(int id)
        {
                return await _appointmentRepository.Delete(id);
        }

        public async Task<ResponseModel<List<AppointmentResponseModel>>> GetAllAppointments()
        {
                return await _appointmentRepository.GetAll();
        }

        public async Task<ResponseModel<AppointmentResponseModel>> GetAppointmentById(int id)
        {
                return await _appointmentRepository.GetById(id);
        }

        public async Task<ResponseModel<object>> UpdateAppointment(int id, AppointmentUpdateRequestModel appointment)
        {
                var validator = await _apptUpdateValidator.ValidateAsync(appointment);
                if (!validator.IsValid)
                        return ValidationHelper.FormatErrors(validator.Errors);

                return await _appointmentRepository.Update(id, appointment);
        }

        public async Task<ResponseModel<List<AppointmentResponseModel>>> GetAppointmentsByDoctorId(int doctorId)
        {
                return await _appointmentRepository.GetByDoctorId(doctorId);
        }

        public async Task<ResponseModel<List<AppointmentResponseModel>>> GetAppointmentsByPatientId(int patientId)
        {
                return await _appointmentRepository.GetByPatientId(patientId);
        }
}
