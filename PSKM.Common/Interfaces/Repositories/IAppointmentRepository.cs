using PSKM.Common.Models;
using PSKM.Common.Models.Appointment;

namespace PSKM.Common.Interfaces.Repositories;

public interface IAppointmentRepository
{
        Task<ResponseModel<object>> Add(AppointmentRequestModel appointment);
        Task<ResponseModel<List<AppointmentResponseModel>>> GetAll();
        Task<ResponseModel<AppointmentResponseModel>> GetById(int id);
        Task<ResponseModel<object>> Update(int id, AppointmentUpdateRequestModel appointment);
        Task<ResponseModel<object>> Delete(int id);

        Task<ResponseModel<List<AppointmentResponseModel>>> GetByDoctorId(int doctorId);
        Task<ResponseModel<List<AppointmentResponseModel>>> GetByPatientId(int patientId);
}
