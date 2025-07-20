using PSKM.Common.Enums;
using PSKM.Common.Interfaces.Repositories;
using PSKM.Common.Interfaces.Services;
using PSKM.Common.Models;
using PSKM.Common.Models.Appointment;

namespace PSKM.Core.Services;

public class AppointmentService : IAppointmentService
{
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
                _appointmentRepository = appointmentRepository;
        }

        public async Task<EnumResult> AddAppointment(AppointmentRequestModel appointment)
        {
                return await _appointmentRepository.Add(appointment);
        }

        public async Task<EnumResult> DeleteAppointment(int id)
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

        public Task<EnumResult> UpdateAppointment(int id, AppointmentUpdateRequestModel appointment)
        {
                return _appointmentRepository.Update(id, appointment);
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
