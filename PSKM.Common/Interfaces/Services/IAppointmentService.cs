using PSKM.Common.Models;
using PSKM.Common.Models.Appointment;

namespace PSKM.Common.Interfaces.Services;

public interface IAppointmentService
{
        Task<ResponseModel<object>> AddAppointment(AppointmentRequestModel appointment);
        Task<ResponseModel<List<AppointmentResponseModel>>> GetAllAppointments();
        Task<ResponseModel<AppointmentResponseModel>> GetAppointmentById(int id);
        Task<ResponseModel<object>> UpdateAppointment(int id, AppointmentUpdateRequestModel appointment);
        Task<ResponseModel<object>> DeleteAppointment(int id);
}
